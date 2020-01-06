using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TypTop.Logic;
using TypTop.Repository;
using TypTop.Shared;

namespace TypTop.GameGui
{
    public class LevelAdder
    {
        public void AddNew()
        {

            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            // also make sure to uncomment levelAdder in gamegui.mainwindow to run it.

            //unitOfWork.Worlds.AddWorld(); //see below for reference

            unitOfWork.Complete(); //save to db

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 3
            };
            wordProvider.LoadWords();
            unitOfWork.Levels.AddLevel(4, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 30, 30, 40, new Dictionary<string, object>()
            {
                { "LaneAmount", 2},
                { "Seconds", 30 },
                { "MaximumDistance", 300 }
            });
            wordProvider.MaxWordLength = 4;
            unitOfWork.Levels.AddLevel(4, 1, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 50, 30, 80, new Dictionary<string, object>()
            {
                { "LaneAmount", 3},
                { "Seconds", 30 },
                { "MaximumDistance", 300 },
                { "PlatformBreakAmount", 6 },
                { "PlatformSolidRatio", 0 }
            });
            wordProvider.MaxWordLength = 5;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(4, 2, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 150, 120, 100, new Dictionary<string, object>()
            {
                { "LaneAmount", 4},
                { "Seconds", 40 },
                { "MinimalDistance", 20 },
                { "MaximumDistance", 320 },
                { "PlatformBreakAmount", 4 },
                { "PlatformBreakOffset", 1 },
                { "PlatformSolidRatio", 0.5 }
            });
            wordProvider.MaxWordLength = 6;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(4, 3, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 300, 180, 120, new Dictionary<string, object>()
            {
                { "LaneAmount", 4},
                { "Seconds", 40 },
                { "MinimalDistance", 40 },
                { "MaximumDistance", 340 },
                { "PlatformBreakAmount", 3 },
                { "PlatformBreakOffset", 1 },
                { "PlatformSolidRatio", 0.3 }
            });
            wordProvider.MaxWordLength = 7;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(4, 4, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 400, 300, 250, new Dictionary<string, object>()
            {
                { "LaneAmount", 5},
                { "Seconds", 40 },
                { "MinimalDistance", 60 },
                { "MaximumDistance", 360 },
                { "PlatformBreakAmount", 2 },
                { "PlatformBreakOffset", 0 },
                { "PlatformSolidRatio", 0.3 }
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(4, 5, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 450, 270, 180, new Dictionary<string, object>()
            {
                { "LaneAmount", 5},
                { "MinimalDistance", 100 },
                { "MaximumDistance", 380 },
                { "PlatformBreakAmount", 0 },
                { "PlatformBreakOffset", 0 },
                { "PlatformSolidRatio", 0.85 }
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 5;
            unitOfWork.Levels.AddLevel(4, 6, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 500, 220, 150, new Dictionary<string, object>()
            {
                { "LaneAmount", 5},
                { "MinimalDistance", 200 },
                { "PlatformBreakAmount", 2 },
                { "PlatformBreakOffset", 0 },
                { "PlatformSolidRatio", 0 }
            });
            unitOfWork.Levels.AddLevel(4, 7, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 600, 220, 150, new Dictionary<string, object>()
            {
                { "LaneAmount", 6},
                { "PlatformBreakAmount", 0 },
                { "PlatformBreakOffset", 0 },
                { "PlatformSolidRatio", 0 }
            });


            unitOfWork.Complete(); //save to db

            // Add Levels to Worlds
            var dblevels = unitOfWork.Levels.GetAll();
            foreach (var lvl in dblevels)
            {
                if (!unitOfWork.Worlds.Get(lvl.WorldId).Levels.Where(l => l.LevelId.Equals(lvl.LevelId)).Any())
                {
                    unitOfWork.Worlds.Get(lvl.WorldId).Levels.Add(lvl);
                }

            }
            unitOfWork.Complete(); //save to db

        }
    }

    /*
    + STORED LEVELS AND WORLDS + ( for future reference and when we switch from database 'Test'  to 'TypTop' )

    ++ LEVELS ++
    +++ TAVERNGAME +++

         WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 3
            };
            wordProvider.LoadWords();
            unitOfWork.Levels.AddLevel(2, 0, WinConditionType.TimeCondition, JsonConvert.SerializeObject(wordProvider), 100, 100, 100, new Dictionary<string, object>()
            {
                {"Seconds", 45}
            });
            wordProvider.MaxWordLength = 4;
            unitOfWork.Levels.AddLevel(2, 1, WinConditionType.TimeCondition, JsonConvert.SerializeObject(wordProvider), 150, 90, 60, new Dictionary<string, object>()
            {
                {"Queue", 15}
            });
            wordProvider.MaxWordLength = 5;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(2, 2, WinConditionType.LifeCondition, JsonConvert.SerializeObject(wordProvider), 150, 120, 100, new Dictionary<string, object>()
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
            });
            wordProvider.MaxWordLength = 6;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(2, 3, WinConditionType.TimeCondition, JsonConvert.SerializeObject(wordProvider), 300, 180, 120, new Dictionary<string, object>()
            {
                {"Queue", 30}
            });
            wordProvider.MaxWordLength = 7;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(2, 4, WinConditionType.LifeCondition, JsonConvert.SerializeObject(wordProvider), 400, 300, 250, new Dictionary<string, object>()
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
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(2, 5, WinConditionType.TimeCondition, JsonConvert.SerializeObject(wordProvider), 450, 270, 180, new Dictionary<string, object>()
            {
                {"Queue", 45}
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 5;
            unitOfWork.Levels.AddLevel(2, 6, WinConditionType.LifeCondition, JsonConvert.SerializeObject(wordProvider), 500, 220, 150, new Dictionary<string, object>()
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
            });
            unitOfWork.Levels.AddLevel(2, 7, WinConditionType.LifeCondition, JsonConvert.SerializeObject(wordProvider), 600, 220, 150, new Dictionary<string, object>()
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
            });

    +++ SPACEGAME +++

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 3
            };
            wordProvider.LoadWords();
            unitOfWork.Levels.AddLevel(3, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 100, 200, 300, new Dictionary<string, object>()
            {
                {"Lives", 6},
                {"EnemyAmount", 10 },
                {"EnemyVelocity", 1f },
                {"EnemyVelocityOffset", 0.3f}
            });
            
            wordProvider.MaxWordLength = 4;
            unitOfWork.Levels.AddLevel(3, 1, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 150, 90, 60, new Dictionary<string, object>()
            {
                {"Lives", 5},
                {"EnemyAmount", 15 },
                {"EnemyVelocity", 1.5f },
                {"EnemyVelocityOffset", 0.4f}
            });
            wordProvider.MaxWordLength = 5;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(3, 2, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 150, 120, 100, new Dictionary<string, object>()
            {
                {"Lives", 4},
                {"EnemyAmount", 20 },
                {"EnemyVelocity", 2f },
                {"EnemyVelocityOffset", 0.5f}
            });
            wordProvider.MaxWordLength = 6;
            wordProvider.MinWordLength = 3;
            unitOfWork.Levels.AddLevel(3, 3, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 300, 180, 120, new Dictionary<string, object>()
            {
                {"Lives", 4},
                {"EnemyAmount", 25 },
                {"EnemyVelocity", 2.8f },
                {"EnemyVelocityOffset", 1f}
            });
            wordProvider.MaxWordLength = 7;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(3, 4, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 400, 300, 250, new Dictionary<string, object>()
            {
                {"Lives", 4},
                {"EnemyAmount", 30 },
                {"EnemyVelocity", 3.5f },
                {"EnemyVelocityOffset", 0.5f}
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 4;
            unitOfWork.Levels.AddLevel(3, 5, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 450, 270, 180, new Dictionary<string, object>()
            {
                {"Lives", 4},
                {"EnemyAmount", 35 },
                {"EnemyVelocity", 4f },
                {"EnemyVelocityOffset", 1.5f}
            });
            wordProvider.MaxWordLength = 8;
            wordProvider.MinWordLength = 5;
            unitOfWork.Levels.AddLevel(3, 6, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 500, 220, 150, new Dictionary<string, object>()
            {
                {"Lives", 3},
                {"EnemyAmount", 40 },
                {"EnemyVelocity", 4f },
                {"EnemyVelocityOffset", 1.5f}
            });
            unitOfWork.Levels.AddLevel(3, 7, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 600, 220, 150, new Dictionary<string, object>()
            {
                {"Lives", 3},
                {"EnemyAmount", 45 },
                {"EnemyVelocity", 5f },
                {"EnemyVelocityOffset", 1f}
            });


    +++ JUMPGAME +++

        unitOfWork.Levels.AddLevel(4, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 100, 200, 300, new Dictionary<string, object>()
            {
                { "Lives", 6 },
                { "PlatformBreakAmount", 3 },
                { "PlatformBreakOffset", 1 },
                { "PlatformSolidRatio", 0.5 }
            });

    ++ WORLDS ++
        unitOfWork.Worlds.AddWorld("De aarde wordt aangevallen door ruimtewezens! Schiet de aliens neer door het woord over te typen dat zij meedragen. " +
                "Hoe sneller je dit doet hoe meer punten je krijgt. Maar let op, je moet woorden wel goed typen, en als je te lang wacht zullen aliens aanvallen!",
                0, 0, "spaceLevelBackground.jpeg", "spaceButton.png", "spaceButton_hover.png");
        
        unitOfWork.Worlds.AddWorld("Het is druk in de Taverne in het Wilde Westen! Probeer zoveel mogelijk klanten blij te maken " +
                "door ze eten en drinken te geven.Rechtsboven zie je de menukaart, om een klant te geven wat hij / zij wil moet je het " +
                "woord van dat product typen.Hoe sneller je dit doet hoe meer punten je krijgt.Maar let op, je moet woorden wel goed typen, " +
                "en als je te lang wacht kunnen klanten boos weglopen!", 
                1, 0, "tavernLevelBackground.png", "tavernButton.png", "tavernButton_hover.png");

        unitOfWork.Worlds.AddWorld("Jumpboy is verdrietig, hij wil bewijzen dat hij heel hoog kan komen. Help hem om op de goeie platformen te springen. " +
                "Je kan Jumpboy laten bewegen naar een plaats door het woord goed over te typen. Hoe hoger je komt hoe meer punten je krijgt. " +
                "Maar pas op dat je niet valt! En sommige platformen kunnen doorzakken!", 
                2, 0, "jumpLevelBackground.png", "jumpButton.png", "jumpButton_hover.png");


    */
}
