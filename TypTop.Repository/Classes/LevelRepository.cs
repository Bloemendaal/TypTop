using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TypTop.Database;
using TypTop.Shared;

namespace TypTop.Repository
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(Context context) : base(context)
        {
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
