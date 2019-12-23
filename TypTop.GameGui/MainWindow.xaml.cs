using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using TypTop.Logic;
using TypTop.MinigameEngine;
using TypTop.Repository;
using TypTop.Shared;


namespace TypTop.GameGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainWindow()
        {
            InitializeComponent();
            //AllocConsole();
            PreviewTextInput += OnPreviewTextInput;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 8,
                MinWordLength = 3
            };
            wordProvider.LoadTestWords();



            /* ADDED
            
            unitOfWork.Worlds.AddWorld("De aarde wordt aangevallen door ruimtewezens! Schiet de aliens neer door het woord over te typen dat zij meedragen. " +
                "Hoe sneller je dit doet hoe meer punten je krijgt. Maar let op, je moet woorden wel goed typen, en als je te lang wacht zullen aliens aanvallen!",
                0, 0, "spaceLevelBackground.jpeg", "spaceButton.png", "spaceButton_hover.png");

            unitOfWork.Worlds.AddWorld("Jumpboy is verdrietig, hij wil bewijzen dat hij heel hoog kan komen. Help hem om op de goeie platformen te springen. " +
                "Je kan Jumpboy laten bewegen naar een plaats door het woord goed over te typen. Hoe hoger je komt hoe meer punten je krijgt. " +
                "Maar pas op dat je niet valt! En sommige platformen kunnen doorzakken!", 
                2, 0, "jumpLevelBackground.png", "jumpButton.png", "jumpButton_hover.png");

            unitOfWork.Complete();
            var tavernWorld = unitOfWork.Worlds.GetWhere(w => w.Index == 0).Single();
            */
            
            
            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            // ADDED:
            //taverngame lvls
            /*
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

         
           
            //spacegame lvls
            unitOfWork.Levels.AddLevel(3, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 100, 200, 300, new Dictionary<string, object>()
            {
                {"Lives", 6},
                {"EnemyVelocityOffset", 3f},
                {"LineHeight", 800f}
            });
            
            //jumpgame lvls
            unitOfWork.Levels.AddLevel(4, 0, WinConditionType.ScoreCondition, JsonConvert.SerializeObject(wordProvider), 100, 200, 300, new Dictionary<string, object>()
            {
                { "Lives", 6 },
                { "PlatformBreakAmount", 3 },
                { "PlatformBreakOffset", 1 },
                { "PlatformSolidRatio", 0.5 }
            });
            unitOfWork.Complete();
            */

            // var levelEen = unitOfWork.Levels.GetWhere(l => l.Index == 0).Single();

            var dblevels = unitOfWork.Levels.GetAll();
            foreach (var lvl in dblevels)
            {
                if (!unitOfWork.Worlds.Get(lvl.WorldId).Levels.Where(l => l.LevelId.Equals(lvl.LevelId)).Any())
                {
                    unitOfWork.Worlds.Get(lvl.WorldId).Levels.Add(lvl);
                }
                
            }
            unitOfWork.Complete();

            List<Database.World> dbWorlds = unitOfWork.Worlds.GetAll().OrderBy(w => w.Index).ToList();
            List<World> worlds = new List<World>();

            foreach (var dbWorld in dbWorlds)
            {
                List<Level> levels = new List<Level>();
                foreach (var dbLevel in dbWorld.Levels)
                {
                    levels.Add(new Level()
                    {
                        WinCondition = (WinConditionType)dbLevel.WinCondition,
                        ThresholdOneStar = dbLevel.ThresholdOneStar,
                        ThresholdTwoStars = dbLevel.ThresholdTwoStars,
                        ThresholdThreeStars = dbLevel.ThresholdThreeStars,

                        WordProvider = JsonConvert.DeserializeObject<WordProvider>(dbLevel.WordProvider),

                        Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(dbLevel.Variables)
                    });
                }
                worlds.Add(new World(dbWorld.Button, dbWorld.Background, levels, (WorldId)dbWorld.Index, dbWorld.HoverButton));
            }



            var gameLoader = new GameLoader(GameWindow, worlds);
            /*
            {
                new World(tavernWorld.Button, tavernWorld.Background ,new List<Level>()
                {
                    
                    new Level() // ADDED TO DB
                    {
                        WinCondition = (WinConditionType)levelEen.WinCondition,

                        ThresholdOneStar = levelEen.ThresholdOneStar,
                        ThresholdTwoStars = levelEen.ThresholdTwoStars,
                        ThresholdThreeStars = levelEen.ThresholdThreeStars,

                        WordProvider = JsonConvert.DeserializeObject<WordProvider>(levelEen.WordProvider),

                        Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(levelEen.Variables)
                    },
                    
                    new Level() // ADDED TO DB
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
                    new Level() // ADDED TO DB
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
                    new Level() // ADDED TO DB
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
            */
            gameLoader.LoadWorldMap();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            GameWindow.OnMouseHover(e.GetPosition(GameWindow));
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            GameWindow.OnMouseDown(e.GetPosition(GameWindow));
        }

        private void OnFinishedGame(object sender, FinishEventArgs e)
        {
            GameWindow.Stop();
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            GameWindow.OnTextInput(e);
        }
    }
}
