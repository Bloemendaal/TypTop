using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine.WinConditions
{
    public class ScoreCondition : WinCondition
    {
        private readonly int _star1;
        private readonly int _star2;
        private readonly int _star3;

        public override bool OneStar()
        {
            return Minigame.Score.Amount >= _star1;
        }

        public override bool TwoStar()
        {
            return Minigame.Score.Amount >= _star1 + _star2;
        }

        public override bool ThreeStar()
        {
            return Minigame.Score.Amount >= _star1 + _star2 + _star3;
        }

        public ScoreCondition(int star3, int star2, int star1)
        {
            _star1 = star1;
            _star2 = star2;
            _star3 = star3;
        }
        public ScoreCondition(int star) : this(star, star, star) { }
    }
}
