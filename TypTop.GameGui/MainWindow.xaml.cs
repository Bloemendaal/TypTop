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

            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            //LevelAdder newLevels = new LevelAdder();
            //newLevels.AddNew();

            List<Database.World> dbWorlds = unitOfWork.Worlds.GetAll().OrderBy(w => w.Index).ToList();
            List<World> worlds = new List<World>();

            var dblevels = unitOfWork.Levels.GetAll();
            foreach (var lvl in dblevels)
            {
                if (!unitOfWork.Worlds.Get(lvl.WorldId).Levels.Where(l => l.LevelId.Equals(lvl.LevelId)).Any())
                {
                    unitOfWork.Worlds.Get(lvl.WorldId).Levels.Add(lvl);
                }

            }

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
