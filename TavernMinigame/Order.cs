using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace TavernMinigame
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
            Type = type;
            AddComponent(new PositionComponent());
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/{Type.ToString().ToLower()}.png", UriKind.Relative)))
            {
                Width = 200
            });
        }

        public override bool Equals(object obj)
        {
            if (obj is Order order)
            {
                return order.Type == Type;
            }

            return false;
        }
    }
}
