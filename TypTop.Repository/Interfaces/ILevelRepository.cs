using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;
using TypTop.Shared;


namespace TypTop.Repository
{
    public interface ILevelRepository : IRepository<Level>
    {

        public int GetWorldId(int levelId);
        public World GetWorld(int levelId);
        public string GetTitle(int levelId);
        public string GetDescription(int levelId);
        public int GetIndex(int levelId);
        public WinConditionType GetWinCondition(int levelId);
        public int GetThreshholdOneStar(int levelId);
        public int GetThreshholdTwoStars(int levelId);
        public int GetThreshholdThreeStars(int levelId);
        public string GetVariables(int levelId);
        public int GetRequiredLevelId(int levelId);
        public Level GetRequiredLevel(int levelId);

        public void AddLevel(int worldId, int index, WinConditionType winCondition, string wordProvider, int thresholdOneStar, int thresholdTwoStars, int thresholdThreeStars, Dictionary<string, object> variables);

    }
}
