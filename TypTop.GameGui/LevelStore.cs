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
                    // level 1 with values from database
                    new Level()
                    {
                        WinCondition = (WinConditionType)levelEen.WinCondition,

                        ThresholdOneStar = levelEen.ThresholdOneStar,
                        ThresholdTwoStars = levelEen.ThresholdTwoStars,
                        ThresholdThreeStars = levelEen.ThresholdThreeStars,

                        WordProvider = JsonConvert.DeserializeObject<WordProvider>(levelEen.WordProvider),

                        Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(levelEen.Variables)
                    },

                    //level 2 short queue
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

                    //level 3 easy satisfaction 
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
                                    {1, 6000},
                                    {2, 6000},
                                    {3, 6000},
                                    {4, 6000},
                                    {5, 6000},
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

                    //level 5 medium satisfaction
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

                    //level 6 long queue
                    new Level()
                    {
                        WinCondition = WinConditionType.TimeCondition,

                        ThresholdOneStar = 450,
                        ThresholdTwoStars = 270,
                        ThresholdThreeStars = 180,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Queue", 45}
                        }
                    },

                    //level 7 hard satisfaction
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
                                    {1, 3000},
                                    {2, 3000},
                                    {3, 3000},
                                    {4, 3000},
                                    {5, 3000},
                                }
                            }
                        }
                    },

                    //level 8 very hard satisfaction
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
                                    {1, 2000},
                                    {2, 2000},
                                    {3, 2000},
                                    {4, 2000},
                                    {5, 2000},
                                }
                            }
                        }
                    }
                }, WorldId.Tavern, tavernWorld.HoverButton),

                new World("spaceButton.png", "spaceLevelBackground.jpeg", new List<Level>()
                {
                    //level 1 many lives, low line
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
                    },

                    //level 2 many lives, medium line
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
                            {"LineHeight", 600f}
                        }
                    },

                    //level 3 medium lives, low line
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 4},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 800f}
                        }
                    },

                    //level 4 medium enemies, medium line
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
                            {"LineHeight", 600f}
                        }
                    },

                    //level 5 few lives, low line
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 2},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 800f}
                        }
                    },

                    //level 6 few lives, high line
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 2},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 400f}
                        }
                    },

                    //level 7 medium lives, high line
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 4},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 400f}
                        }
                    },

                    //level 8 few enemies, high line
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        WordProvider = wordProvider,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Lives", 2},
                            {"EnemyVelocityOffset", 3f},
                            {"LineHeight", 400f}
                        }
                    }
                },
                
                WorldId.Space,"spaceButton_hover.png"),

                new World("jumpButton.png", "jumpLevelBackground.png", new List<Level>()
                {
                    //level 1 only solid platforms
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
                            { "PlatformSolidRatio", 1 }
                        }
                    },

                    //level 2 six seventh solid
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
                            { "PlatformSolidRatio", 0.86 }
                        }
                    },

                    //level 3 five seventh solid
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
                            { "PlatformSolidRatio", 0.71 }
                        }
                    },

                    //level 4 four seventh solid
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
                            { "PlatformSolidRatio", 0.57 }
                        }
                    },

                    //level 5 three seventh solid
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
                            { "PlatformSolidRatio", 0.43 }
                        }
                    },

                    //level 6 two seventh solid
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
                            { "PlatformSolidRatio", 0.29 }
                        }
                    },

                    //level 7 one seventh solid
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
                            { "PlatformSolidRatio", 0.14 }
                        }
                    },

                    //level 8 no solid platforms
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
                            { "PlatformSolidRatio", 0 }
                        }
                    }
                }, WorldId.Jump, "jumpButton_hover.png")
            });
        }
    }
}
