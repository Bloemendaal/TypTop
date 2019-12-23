using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TypTop.Database;
using TypTop.Shared;

namespace TypTop.Repository
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(Context context) : base(context)
        {
        }

        public void AddLevel(int worldId, int index, WinConditionType winCondition, string wordProvider, int thresholdOneStar, int thresholdTwoStars, int thresholdThreeStars, Dictionary<string, object> variables)
        {
            Add(new Level
            {
                WorldId = worldId,
                Index = index,
                WinCondition = (int)winCondition,
                WordProvider = wordProvider,
                ThresholdOneStar = thresholdOneStar,
                ThresholdTwoStars = thresholdTwoStars,
                ThresholdThreeStars = thresholdThreeStars,
                Variables =  JsonConvert.SerializeObject(variables)
            });
        }


        public string GetDescription(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetIndex(int levelId)
        {
            throw new NotImplementedException();
        }

        public Level GetRequiredLevel(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetRequiredLevelId(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetThreshholdOneStar(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetThreshholdThreeStars(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetThreshholdTwoStars(int levelId)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int levelId)
        {
            throw new NotImplementedException();
        }

        public string GetVariables(int levelId)
        {
            throw new NotImplementedException();
        }

        public WinConditionType GetWinCondition(int levelId)
        {
            throw new NotImplementedException();
        }

        public World GetWorld(int levelId)
        {
            throw new NotImplementedException();
        }

        public int GetWorldId(int levelId)
        {
            throw new NotImplementedException();
        }
    }
}
