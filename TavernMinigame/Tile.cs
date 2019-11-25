using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Logic;

namespace TavernMinigame
{
    public class Tile : Entity
    {
        public Order Order { get; private set; }
        public Word Word { get; set; }

        public const double Width = 200;

        public Tile(Order.OrderType orderType, float x, Game game) : base($"tile {orderType}", game)
        {
            AddComponent(new PositionComponent(x, 20));
            AddComponent(new ImageComponent(new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Images/tile.png", UriKind.Relative)))
            {
                Width = Width
            });

            Order = new Order(orderType, Game);

            Order.GetComponent<ImageComponent>().Width = Width - 40;
            float addWidth = 20;
            if (Order.GetComponent<ImageComponent>().Height > GetComponent<ImageComponent>().Height - 40)
            {
                Order.GetComponent<ImageComponent>().Height = GetComponent<ImageComponent>().Height - 40;
                Order.GetComponent<ImageComponent>().Width = null;

                addWidth = (float)(GetComponent<ImageComponent>().Width - Order.GetComponent<ImageComponent>().Width) / 2;
            }

            Order.GetComponent<PositionComponent>().Position = new System.Numerics.Vector2(x + addWidth, (float)(GetComponent<ImageComponent>().Height - Order.GetComponent<ImageComponent>().Height) / 2 + 20);
        }
    }
}
