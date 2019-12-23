using System.Collections.Generic;
using TypTop.Logic;
using System.Linq;
using TypTop.Repository;
using TypTop.Shared;
using Newtonsoft.Json;

namespace TypTop.GameGui
{
    public class LevelStore
    {
        public GameLoader GameLoader { get; private set;}
        internal TypTop.GameWindow.GameWindow gameWindow;
        public LevelStore(TypTop.GameWindow.GameWindow gameWindow, WordProvider wordProvider)
        {
            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            var tavernWorld = unitOfWork.Worlds.GetWhere(w => w.Index == 0).Single();

            /*
            Dictionary<string, object> Properties = new Dictionary<string, object>()
                        {
                            {"Seconds", 120}
                        };
            unitOfWork.Levels.Add(new Database.Level
            {
                WinCondition = (int)WinConditionType.ScoreCondition,

                ThresholdOneStar = 250,
                ThresholdTwoStars = 500,
                ThresholdThreeStars = 750,

                WorldId = tavernWorld.WorldId,
                Index = 0,
                WordProvider = JsonConvert.SerializeObject(wordProvider),

                Variables = JsonConvert.SerializeObject(Properties)

            });
            unitOfWork.Complete();
            */

            var levelEen = unitOfWork.Levels.GetWhere(l => l.Index == 0).Single();

            GameLoader = new GameLoader(gameWindow, new List<World>()
            {
                new World(tavernWorld.Button, tavernWorld.Background ,new List<Level>()
                {
                    // level 1, with values from database
                    new Level()
                    {
                        WinCondition = (WinConditionType)levelEen.WinCondition,

                        ThresholdOneStar = levelEen.ThresholdOneStar,
                        ThresholdTwoStars = levelEen.ThresholdTwoStars,
                        ThresholdThreeStars = levelEen.ThresholdThreeStars,

                        WordProvider = JsonConvert.DeserializeObject<WordProvider>(levelEen.WordProvider),

                        Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(levelEen.Variables)
                    },

                    //level 2, short queue
                    new Level()
                    {
                        WinCondition = WinConditionType.TimeCondition,

                        ThresholdOneStar = 150,
                        ThresholdTwoStars = 90,
                        ThresholdThreeStars = 60,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Queue", 15}
                        }
                    },

                    //level 3, 
                    new Level()
                    {
                        WinCondition = WinConditionType.LifeCondition,

                        ThresholdOneStar = 1,
                        ThresholdTwoStars = 2,
                        ThresholdThreeStars = 3,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 6},
                            {"Seconds", 120},
                            {"ShowSatisfaction", true},
                            {
                                "SatisfactionTiming", new Dictionary<int, int>
                                {
                                    {1, 4000},
                                    {2, 4000},
                                    {3, 4000},
                                    {4, 4000},
                                    {5, 4000},
                                }
                            }
                        }
                    },

                    //level 4, medium queue
                    new Level()
                    {
                        WinCondition = WinConditionType.TimeCondition,

                        ThresholdOneStar = 300,
                        ThresholdTwoStars = 180,
                        ThresholdThreeStars = 120,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Queue", 30}
                        }
                    },



                    new Level()
                    {
                        WinCondition = WinConditionType.LifeCondition,

                        ThresholdOneStar = 1,
                        ThresholdTwoStars = 2,
                        ThresholdThreeStars = 3,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 6},
                            {"Seconds", 120},
                            {"ShowSatisfaction", true},
                            {
                                "SatisfactionTiming", new Dictionary<int, int>
                                {
                                    {1, 4000},
                                    {2, 4000},
                                    {3, 4000},
                                    {4, 4000},
                                    {5, 4000},
                                }
                            }
                        }
                    }
                }, WorldId.Tavern, tavernWorld.HoverButton),

                new World("spaceButton.png", "spaceLevelBackground.jpeg", new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 6},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 800f}
                        }
                    }
                }, WorldId.Space,"spaceButton_hover.png"),

                new World("jumpButton.png", "jumpLevelBackground.png", new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            { "Lives", 6 },
                            { "PlatformBreakAmount", 3 },
                            { "PlatformBreakOffset", 1 },
                            { "PlatformSolidRatio", 0.5 }
                        }
                    }
                }, WorldId.Jump, "jumpButton_hover.png")
            });
        }
    }
}
