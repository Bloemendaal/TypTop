using System;
using TypTop.GameEngine;
using TypTop.Logic;
using TypTop.MinigameEngine.WinConditions;
using TypTop.Shared;

namespace TypTop.MinigameEngine
{
    public abstract class Minigame : Game
    {
        /// <summary>
        /// Een instantie van Score. Wordt alleen geset indien het level score bij moet houden. Voor meer informatie, zie Class Score.
        /// </summary>
        public Score Score { get; protected set; }

        /// <summary>
        /// Een instantie van Lives. Wordt alleen geset indien het level levens bij moet houden. Voor meer informatie, zie Class Lives.
        /// </summary>
        public Lives Lives { get; protected set; }

        /// <summary>
        /// Een instantie van Count. Wordt alleen geset indien het level tijd bij moet houden of een countdown gebruikt. Voor meer informatie, zie Class Count.
        /// </summary>
        public Count Count { get; protected set; }

        /// <summary>
        /// Geeft het aantal sterren dat op dat moment door de speler behaald is. Wordt berekend aan de hand van de WinCondition.
        /// </summary>
        public int Stars
        {
            get
            {
                if (WinCondition?.ThreeStar() ?? false) return 3;
                if (WinCondition?.TwoStar() ?? false) return 2;
                if (WinCondition?.OneStar() ?? false) return 1;

                return 0;
            }
        }


        /// <summary>
        /// Een instantie van een WinCondition, gezien WinCondition abstract is. WinCondition kan niet NULL zijn.
        /// </summary>
        public readonly WinCondition WinCondition;

        /// <summary>
        /// Een instantie van delegate FinishCondition, wordt elke update uitgevoerd om te controleren of het spel afgesloten moet worden. Als deze NULL is, zal de minigame nooit uit zichzelf stoppen en moet dan altijd van buitenaf gestopt worden.
        /// </summary>
        public FinishCondition Finish { get; protected set; }
        public delegate bool FinishCondition();

        /// <summary>
        /// Wordt afgevuurd wanneer het spel beëindigd is door de minigame zelf via de Finish. Geeft FinishEventArgs mee, hierover meer onder FinishEventArgs.
        /// </summary>
        public event EventHandler<FinishEventArgs> OnFinished;

        public Minigame(Level level)
        {
            WinCondition = level.WinCondition switch
            {
                WinConditionType.LifeCondition => new LifeCondition(level.ThresholdThreeStars, level.ThresholdTwoStars, level.ThresholdOneStar),
                WinConditionType.ScoreCondition => new ScoreCondition(level.ThresholdThreeStars, level.ThresholdTwoStars, level.ThresholdOneStar),
                WinConditionType.TimeCondition => new TimeCondition(level.ThresholdThreeStars, level.ThresholdTwoStars, level.ThresholdOneStar),
                _ => throw new Exception("WinConditionType not recognized"),
            };
            WinCondition.Minigame = this;
        }

        private bool _finished = false;

        /// <summary>
        /// Deze method is hetzelfde als die van Game uit project GameEngine, het voegt alleen de controle toe of het spel beëindigd moet worden.
        /// </summary>
        /// <param name="deltaTime">
        /// Verschil in tijd.
        /// </param>
        public override void Update(float deltaTime)
        {
            if (Finish?.Invoke() ?? false)
            {
                if (_finished)
                {
                    return;
                }
                _finished = true;

                OnFinished?.Invoke(this, new FinishEventArgs()
                {
                    Lives = Lives?.Amount,
                    Count = Count?.SecondsSpent,
                    Score = Score?.Amount,
                    Stars = Stars
                });
                return;
            }

            base.Update(deltaTime);
        }
    }
}
