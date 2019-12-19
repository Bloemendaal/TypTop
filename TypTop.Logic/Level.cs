using System.Collections.Generic;
using TypTop.GameGui;
using TypTop.Shared;

namespace TypTop.Logic
{
    public class Level
    {
        public int Id { get; set; }
        public WinConditionType WinCondition { get; set; }
        public int ThresholdOneStar { get; set; }
        public int ThresholdTwoStars { get; set; }
        public int ThresholdThreeStars { get; set; }
        public World World { get; set; }
        public WordProvider WordProvider { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}