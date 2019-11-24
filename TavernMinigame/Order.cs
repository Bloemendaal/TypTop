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

        private readonly TransformComponent _transformComponent;
        public Order(OrderType type, Game game) : base($"order {type.ToString()}", game)
        {
            Type = type;
            _transformComponent = new TransformComponent();
            AddComponent(_transformComponent);
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"{Type.ToString().ToLower()}.png", UriKind.Relative))));
        }
    }
}
