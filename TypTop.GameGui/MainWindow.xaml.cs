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

            WordProvider wordProvider = new WordProvider()
            {
                MaxWordLength = 8,
                MinWordLength = 3
            };
            wordProvider.LoadTestWords();

            //tGame.OnFinished += OnFinishedGame;
            //sGame.OnFinished += OnFinishedGame;


            /*
            using (var unitOfWork = new UnitOfWork(new TypTop.GameGui.ContextFactory().CreateDbContext(null)))
            {
                Dictionary<string, object> Properties = new Dictionary<string, object>()
                        {
                            {"Words", wordProvider.Serve()},
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
                        };
                unitOfWork.Levels.Add(new Database.Level
                {
                    WinCondition = (int)WinConditionType.LifeCondition,

                    ThresholdOneStar = 1,
                    ThresholdTwoStars = 2,
                    ThresholdThreeStars = 3,


                    WorldId = 1,
                    Index = 1,
                    Title = "TestTitle",

                    Variables = JsonConvert.SerializeObject(Properties)

                });
                unitOfWork.Complete();
            }
            */

            using var unitOfWork = new UnitOfWork(new TypTop.GameGui.ContextFactory().CreateDbContext(null));
            var level = unitOfWork.Levels.GetWhere(l => l.Index == 1).Single();

            var gameLoader = new GameLoader(GameWindow, new List<World>()
            {
                new World("tavernButton.png", "tavernLevelBackground.png" ,new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = (WinConditionType)level.WinCondition,

                        ThresholdOneStar = 1,
                        ThresholdTwoStars = 2,
                        ThresholdThreeStars = 3,

                        Properties = JsonConvert.DeserializeObject<Dictionary<string, object>>(level.Variables)
                        
                    }
                }, WorldId.Tavern),
                new World("spaceButton.png", "levelBackground.jpeg", new List<Level>()
                {
                    new Level()
                    {
                        WinCondition = WinConditionType.ScoreCondition,
                        ThresholdOneStar = 100,
                        ThresholdTwoStars = 200,
                        ThresholdThreeStars = 300,

                        Properties = new Dictionary<string, object>()
                        {
                            {"Words", wordProvider.Serve()},
                            {"Lives", 6},
                            {"EnemyVelocityOffset", 1f},
                            {"LineHeight", 800f}
                        }
                    }
                }, WorldId.Space)
            });
            gameLoader.LoadWorldMap();
            //GameWindow.Start(sGame, new Transition(1d));
            //GameWindow.Start(new WorldScreenGame());
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
