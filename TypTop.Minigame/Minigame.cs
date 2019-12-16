using System;
using TypTop.GameEngine;
using TypTop.Logic;
using TypTop.MinigameEngine.WinConditions;

namespace TypTop.MinigameEngine
{
    public abstract class Minigame : Game
    {
        public Score Score { get; protected set; }
        public Lives Lives { get; protected set; }
        public Count Count { get; protected set; }
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

        public WinCondition WinCondition { get; private set; }
        public FinishCondition Finish { get; protected set; }
        public delegate bool FinishCondition();
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
