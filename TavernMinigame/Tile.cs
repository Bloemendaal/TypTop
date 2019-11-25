using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
***REMOVED***
***REMOVED***
using TypTop.Logic;

namespace TavernMinigame
***REMOVED***
    public class Tile : Entity
    ***REMOVED***
        public Order Order ***REMOVED*** get; private set; ***REMOVED***
        public Word Word ***REMOVED*** get; set; ***REMOVED***

        public const double Width = 200;

        public Tile(Order.OrderType orderType, float x, Game game) : base($"tile ***REMOVED***orderType***REMOVED***", game)
        ***REMOVED***
            AddComponent(new PositionComponent(x, 20));
            AddComponent(new ImageComponent(new System.Windows.Media.Imaging.BitmapImage(new Uri(@"Images/tile.png", UriKind.Relative)))
            ***REMOVED***
                Width = Width
        ***REMOVED***);

            Order = new Order(orderType, Game);

            Order.GetComponent<ImageComponent>().Width = Width - 40;
            float addWidth = 20;
            if (Order.GetComponent<ImageComponent>().Height > GetComponent<ImageComponent>().Height - 40)
            ***REMOVED***
                Order.GetComponent<ImageComponent>().Height = GetComponent<ImageComponent>().Height - 40;
                Order.GetComponent<ImageComponent>().Width = null;

                addWidth = (float)(GetComponent<ImageComponent>().Width - Order.GetComponent<ImageComponent>().Width) / 2;
        ***REMOVED***

            Order.GetComponent<PositionComponent>().Position = new System.Numerics.Vector2(x + addWidth, (float)(GetComponent<ImageComponent>().Height - Order.GetComponent<ImageComponent>().Height) / 2 + 20);
    ***REMOVED***
***REMOVED***
***REMOVED***
