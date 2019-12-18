using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;
using TypTop.Shared;


namespace TypTop.Repository
{
    public interface ILevelRepository : IRepository<Level>
    {

        public int GetId();
        public int GetWorldId();
        public World GetWorld();
        public string GetTitle();
        public string GetDescription();
        public int GetIndex();
        public WinConditionType GetWinCondition();
        public int GetThreshholdOneStar();
        public int GetThreshholdTwoStars();
        public int GetThreshholdThreeStars();
        public string GetVariables();
        public int GetRequiredLevelId();
        public Level GetRequiredLevel();


    }
}
