using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameGui;
using TypTop.LevelScreen;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.WorldScreen
{
    public class WorldScreenGame : Game
    {
        private readonly IList<World> _worlds;
        private readonly IGameLoader _gameLoader;

        public WorldScreenGame(IList<World> worlds, IGameLoader gameLoader)
        {
            _worlds = worlds;
            _gameLoader = gameLoader;
            AddEntity(new Background("main_background.png",this));

            for (var index = 0; index < worlds.Count; index++)
            {
                World world = worlds[index];
                var gameButton = new Button(world.PreviewImage, new Rect(new Point(400 + (400 * index * 1.5) , 400), new Size(600, 500)),
                    this);
                gameButton.Data = world;
                gameButton.Clicked += WorldButtonClicked;
                AddEntity(gameButton);
            }
        }

        private Rect GetButtonPositionRectangle(int index, int total)
        {
            return default;
        }

        private void WorldButtonClicked(object sender, EventArgs e)
        {
            var world = (World)((Button) sender).Data;
            _gameLoader.LoadLevelMap(world);
        }
    }
}
