using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace TavernMinigame
{
    public class SpeechBubble : Entity
    {
        public Customer Customer;
        public SpeechBubble(Customer customer, Game game) : base(game)
        {
            ZIndex = 2;
            Customer = customer;
            AddComponent(new PositionComponent()
            {
                X = Customer.GetComponent<PositionComponent>().X,
                Y = 300
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/speechbubble.png", UriKind.Relative)))
            {
                Width = 500
            });
        }
    }
}
