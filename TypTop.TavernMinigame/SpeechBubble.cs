using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class SpeechBubble : Entity
    {
        public SpeechBubble(Customer customer, Game game) : base(game)
        {
            ZIndex = 2;
            AddComponent(new PositionComponent()
            {
                X = customer.GetComponent<PositionComponent>().X,
                Y = 300
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/speechbubble.png", UriKind.Relative)))
            {
                Width = 500
            });
        }
    }
}
