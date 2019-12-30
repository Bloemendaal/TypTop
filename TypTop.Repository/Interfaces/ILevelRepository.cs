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
        public int GetIndex(int levelId);
        public WinConditionType GetWinCondition(int levelId);
        public int GetThreshholdOneStar(int levelId);
        public int GetThreshholdTwoStars(int levelId);
        public int GetThreshholdThreeStars(int levelId);
        public string GetVariables(int levelId);


        /// <summary>
        /// Adds level with given values to the database.
        /// WordProvider as JSON string ( JsonConvert.SerializeObject() ).
        /// Variables as Dictionary.
        /// WORLDID IS DATABASE ID, NOT INDEX.
        /// Use UnitOfWork.Complete() to save in db.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="index"></param>
        /// <param name="winCondition"></param>
        /// <param name="wordProvider"></param>
        /// <param name="thresholdOneStar"></param>
        /// <param name="thresholdTwoStars"></param>
        /// <param name="thresholdThreeStars"></param>
        /// <param name="variables"></param>
        public void AddLevel(int worldId, int index, WinConditionType winCondition, string wordProvider, int thresholdOneStar, int thresholdTwoStars, int thresholdThreeStars, Dictionary<string, object> variables);


    }
}
