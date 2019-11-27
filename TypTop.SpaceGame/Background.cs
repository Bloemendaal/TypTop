﻿
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;

namespace TypTop.SpaceGame
{
    public class Background : Entity
    {
        public Background(Game game) : base(game)
        {
            AddComponent(new PositionComponent()
            {
                Position = new Vector2(0, 0)
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/space.jpg", UriKind.Relative)))
            {
                Width = Game.Width,
                Height = Game.Height
            });
        }
    }
}