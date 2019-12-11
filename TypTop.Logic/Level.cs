using System.Collections.Generic;
using TypTop.GameGui;

namespace TypTop.Logic
{
    public class Level
    {
        public int Id { get; set; }
        public WinCondition WinCondition { get; set; }
        public int ThresholdOneStar { get; set; }
        public int ThresholdTwoStars { get; set; }
        public int ThresholdThreeStars { get; set; }
        public World World { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}