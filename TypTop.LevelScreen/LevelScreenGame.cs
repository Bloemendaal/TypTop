using System;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameGui;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.LevelScreen
{
    public class LevelScreenGame : Game
    {
        private readonly IGameLoader _gameLoader;
        private readonly World _world;

        public LevelScreenGame(World world, IGameLoader gameLoader)
        {
            _world = world;
            _gameLoader = gameLoader;

            AddEntity(new Background(world.Background, this));

            for (var index = 0; index < world.Levels.Count; index++)
            {
                Level worldLevel = world.Levels[index];
                var button = new Button("levelOpen.png",
                    Utils.GetRectangle(index, world.Levels.Count, 5, 50f, 100f, 100f),
                    this);
                button.Data = worldLevel;
                button.Clicked += ButtonOnClicked;
                AddEntity(button);
            }

            var backButton = new Button("backButton.png", new Rect(new Point(50, 900), new Size(100, 100)), this);
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            _gameLoader.LoadMinigame(((Button) sender).Data as Level);
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            _gameLoader.LoadWorldMap();
        }
    }
}