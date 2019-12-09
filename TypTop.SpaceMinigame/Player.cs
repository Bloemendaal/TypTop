using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.SpaceMinigame
{
    public class Player : Entity
    {
        public Player(Game game) : this(4, game) { }

        public Player(int lives, Game game) : base(game)
        {
            ZIndex = 1;

            AddComponent(new PositionComponent()
            {
                Position = new Vector2(885, 975)
            });

            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/spaceship.png", UriKind.Relative)))
            {
                Width = 100
            });
        }
    }
}
