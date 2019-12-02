using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine.WinConditions
{
    public class TimeCondition : WinCondition
    {
        private readonly int _star1;
        private readonly int _star2;
        private readonly int _star3;

        public override bool OneStar()
        {
            return Minigame.Count.Seconds <= _star1 + _star2 + _star3;
        }

        public override bool TwoStar()
        {
            return Minigame.Count.Seconds <= _star2 + _star3;
        }

        public override bool ThreeStar()
        {
            return Minigame.Count.Seconds <= _star3;
        }

        public TimeCondition(int star3, int star2, int star1)
        {
            _star1 = star3;
            _star2 = star2;
            _star3 = star1;
        }
        public TimeCondition(int star) : this(star, star, star) { }
    }
}
