using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine.WinConditions
{
    public abstract class WinCondition
    {
        /// <summary>
        /// Wordt automatisch geset door Minigame en gebruikt door de methods om te kunnen berekenen wanneer er een ster behaald is.
        /// </summary>
        public Minigame Minigame { get; set; }

        public abstract bool OneStar();
        public abstract bool TwoStar();
        public abstract bool ThreeStar();
    }
}
