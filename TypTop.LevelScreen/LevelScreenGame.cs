using System;
using System.Collections.Generic;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameGui;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.LevelScreen
{
    public class LevelScreenGame : Game
    {
        private readonly World _world;
        private readonly IGameLoader _gameLoader;

        public LevelScreenGame(World world, IGameLoader gameLoader)
        {
            _world = world;
            _gameLoader = gameLoader;

            AddEntity(new Background(world.Background, this));
            
            var backButton = new Button("backButton.png", new Rect(new Point(50, 900), new Size(100, 100)), this);
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            _gameLoader.LoadWorldMap();
        }
    }
}
