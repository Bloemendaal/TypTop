using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class Order : Entity
    {
        public enum OrderType
        {
            Salad,
            Fries,
            Burger,
            Sandwich,
            IceCream,

            Cola,
            Milkshake,
            OrangeJuice,
            Coffee,
            Tea
        }

        public OrderType Type { get; private set; }

        public Order(OrderType type, Game game) : base(game)
        {
            ZIndex = 3;
            Type = type;
            AddComponent(new PositionComponent());
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/Order/{Type.ToString().ToLower()}.png", UriKind.Relative)))
            {
                Width = 200
            });
        }
    }
}
