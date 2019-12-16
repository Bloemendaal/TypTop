using System;
using System.Collections.Generic;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameGui;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.WorldScreen
{
    public class WorldScreenGame : Game
    {
        private readonly IGameLoader _gameLoader;
        private readonly IList<World> _worlds;

        public WorldScreenGame(IList<World> worlds, IGameLoader gameLoader)
        {
            _worlds = worlds;
            _gameLoader = gameLoader;
            AddEntity(new Background("main_background.png", this));


            for (var index = 0; index < worlds.Count; index++)
            {
                World world = worlds[index];

                Rect rect = Utils.GetRectangle(index, worlds.Count, 5, 150, 450, 350);

                var gameButton = new Button(world.PreviewImage, rect, this);
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
            var world = (World) ((Button) sender).Data;
            _gameLoader.LoadLevelMap(world);
        }
    }
}