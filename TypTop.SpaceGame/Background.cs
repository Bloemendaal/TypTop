
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Typop.SpaceGame
{
    public class Background : Entity
    {
        public Background(Game game) : base(game)
        {
            AddComponent(new PositionComponent() { Position = new System.Numerics.Vector2(0, 0) });
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"background.png", UriKind.Relative)))
            {
                Width = Game.Width,
                Height = Game.Height
            });
        }
    }
}