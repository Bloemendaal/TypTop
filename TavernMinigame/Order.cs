using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
***REMOVED***
***REMOVED***
using System.Windows.Media.Imaging;

namespace TavernMinigame
***REMOVED***
    public class Order : Entity
    ***REMOVED***
        public enum OrderType
        ***REMOVED***
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
    ***REMOVED***

        public OrderType Type ***REMOVED*** get; private set; ***REMOVED***

        public Order(OrderType type, Game game) : base($"order ***REMOVED***type.ToString()***REMOVED***", game)
        ***REMOVED***
            Type = type;
            AddComponent(new PositionComponent());
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/***REMOVED***Type.ToString().ToLower()***REMOVED***.png", UriKind.Relative)))
            ***REMOVED***
                Width = 100
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
