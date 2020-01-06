using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TypTop.Repository
{
    public class LevelAdder
    {
        public void AddNew()
        {
            
            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            // also make sure to uncomment leveladder in gamegui.mainwindow to run it.

            //unitOfWork.Worlds.AddWorld(); //see below for reference

            unitOfWork.Complete(); //save to db


            //unitOfWork.Levels.AddLevel(); //see below for reference

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

        unitOfWork.Levels.AddLevel(2, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 250, 500, 750, new Dictionary<string, object>()
            {
                {"Seconds", 120}
            });

        unitOfWork.Levels.AddLevel(2, 1, WinConditionType.TimeCondition, JsonConvert.SerializeObject(wordProvider), 300, 180, 120, new Dictionary<string, object>()
            {
                { "Queue", 30 }
            });

        unitOfWork.Levels.AddLevel(2, 2, WinConditionType.LifeCondition, JsonConvert.SerializeObject(wordProvider), 1, 2, 3, new Dictionary<string, object>()
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
                    {5, 4000},
                    }
                }
            });

    +++ SPACEGAME +++

        unitOfWork.Levels.AddLevel(3, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 100, 200, 300, new Dictionary<string, object>()
            {
                {"Lives", 6},
                {"EnemyVelocityOffset", 3f},
                {"LineHeight", 800f}
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
