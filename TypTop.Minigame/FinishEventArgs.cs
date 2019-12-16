using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.MinigameEngine
{
    public class FinishEventArgs : EventArgs
    {
        /// <summary>
        /// Het aantal levens dat nog over is. Standaardwaarde is NULL.
        /// </summary>
        public int? Lives;

        /// <summary>
        /// De behaalde score. Standaardwaarde is NULL.
        /// </summary>
        public int? Score;

        /// <summary>
        /// De tijd gespendeerd in het level in seconden. Standaardwaarde is NULL.
        /// </summary>
        public int? Count;

        /// <summary>
        /// Het aantal behaalde sterren in het level. Standaardwaarde is 0.
        /// </summary>
        public int Stars = 0;
    }
}
