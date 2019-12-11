using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine.WinConditions
{
    public abstract class WinCondition
    {
        public Minigame Minigame { get; set; }

        public abstract bool OneStar();
        public abstract bool TwoStar();
        public abstract bool ThreeStar();
    }
}
