using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.Tutorial
{
    public class Hands : Entity
    {
        public Hands(Game minigame) : base(minigame)
        {
            AddComponent(new PositionComponent((float)Game.Width / 4, 640));
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/hands.png", UriKind.Relative)))
            {
                Width = Game.Width / 2
            });
        }
    }
}
