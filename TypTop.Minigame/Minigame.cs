using System;
using TypTop.GameEngine;
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

        public Minigame(WinCondition winCondition)
        {
            WinCondition = winCondition ?? throw new ArgumentNullException(nameof(winCondition));
            WinCondition.Minigame = this;
        }

        public override void Update(float deltaTime)
        {
            if (Finish?.Invoke() ?? false)
            {
                OnFinished?.Invoke(this, new FinishEventArgs()
                {
                    Lives = Lives?.Amount,
                    Count = Count.SecondsSpent,
                    Score = Score?.Amount,
                    Stars = Stars
                });
                return;
            }

            base.Update(deltaTime);
        }
    }
}
