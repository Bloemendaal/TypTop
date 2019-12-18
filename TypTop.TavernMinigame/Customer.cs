using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class Customer : Entity
    {
        private readonly SpeechBubble _speechBubble;
        public readonly Satisfaction Satisfaction;

        /// <summary>
        /// The amount of orders left to be served.
        /// </summary>
        public int Count => _orders.Count;

        /// <summary>
        /// Original amount of orders the customer had.
        /// </summary>
        public readonly int OriginalCount;

        /// <summary>
        /// Customer's orders
        /// </summary>
        private readonly List<Order> _orders;

        /// <summary>
        /// List of all available unique customers.
        /// </summary>
        public enum CustomerType { GunslingerMan, GunslingerWoman, LawsMan, LawsWoman, NativeGirl, NativeMan, OutlawMan, OutlawWoman, TownsMan, TownsWoman }
        public readonly CustomerType Type;


        public Customer(TavernGame game) : base(game)
        {
            ZIndex = 1;
            _orders = game.GetOrder(Game.Rnd.Next(game.CustomerMinOrderAmount, game.CustomerMaxOrderAmount + 1));
            OriginalCount = Count;

            var types = Enum.GetNames(typeof(CustomerType));
            Type = (CustomerType)game.Rnd.Next(0, types.Length);

            AddComponent(new PositionComponent()
            {
                Y = 800
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/Customer/{Type.ToString().ToLower()}.png", UriKind.Relative)))
            {
                Width = 500
            });

            _speechBubble = new SpeechBubble(this, game);

            if (game.ShowSatisfaction)
            {
                Satisfaction = new Satisfaction(this, game);
            }
        }

        /// <summary>
        /// Voegt alle benodigde entities (Order’s, SpeechBubble, this) aan game toe.
        /// </summary>
        public void AddEntities()
        {
            Game.AddEntity(_speechBubble);
            Game.AddEntity(this);
            if (Satisfaction != null)
            {
                Game.AddEntity(Satisfaction);
            } 
            _orders.ForEach(o => Game.AddEntity(o));
        }

        /// <summary>
        /// Verwijdert alle entities die verwant zijn aan de Customer.
        /// </summary>
        /// <param name="score">
        /// Voegt deze score toe aan de huidige score.
        /// </param>
        public void RemoveEntities(int score = 0)
        {
            _orders.ForEach(o => Game.RemoveEntity(o));
            Game.RemoveEntity(this);
            Game.RemoveEntity(_speechBubble);
            if (Satisfaction != null)
            {
                Game.RemoveEntity(Satisfaction);
                Satisfaction.Dispose();
            }

            ((TavernGame)Game).Score.Amount += score;
        }

        /// <summary>
        /// Verwijdert een specifieke Order uit _orders. Roept UpdateOrderPosition() aan.
        /// </summary>
        /// <param name="order">
        /// Order dat verwijdert moet worden.
        /// </param>
        /// <returns>
        /// Geeft terug of het verwijderen succesvol was.
        /// </returns>
        public bool RemoveOrder(Order order)
        {
            List<Order> orders = _orders.Where(o => o.Type == order.Type).ToList();
            if (orders.Count > 0)
            {
                Order o = orders.First();
                if (o != null)
                {
                    bool removed = _orders.Remove(o);
                    Game.RemoveEntity(o);
                    if (_orders.Count > 0)
                    {
                        UpdateOrderPosition();
                    }
                    return removed;
                }
            }

            return false;
        }

        /// <summary>
        /// Werkt de posities van de Customer en de SpeechBubble bij. Roept daarna de UpdateOrderPosition() method aan.
        /// </summary>
        /// <param name="index">
        /// Index van de rij waarin de Customer staat.
        /// </param>
        public void UpdatePosition(int index)
        {
            float x = (float)Game.Width - 500 * (index + 1) - 20;
            GetComponent<PositionComponent>().X = x;
            _speechBubble.GetComponent<PositionComponent>().X = x;
            if (Satisfaction != null)
            {
                Satisfaction.GetComponent<PositionComponent>().X = x + 220;
            }
            UpdateOrderPosition();
        }

        /// <summary>
        /// Werkt de posities van de Order’s in _orders bij.
        /// </summary>
        public void UpdateOrderPosition()
        {
            Vector2 position = _speechBubble.GetComponent<PositionComponent>().Position;
            switch (Count)
            {
                case 1:
                    _orders[0].GetComponent<PositionComponent>().Position = new Vector2(position.X + 150 + (200 - (float)_orders[0].GetComponent<ImageComponent>().Width) / 2, position.Y + 140 + (200 - (float)_orders[0].GetComponent<ImageComponent>().Height) / 2);
                    break;
                case 2:
                    _orders[0].GetComponent<PositionComponent>().Position = new Vector2(position.X + 50  + (200 - (float)_orders[0].GetComponent<ImageComponent>().Width) / 2, position.Y + 140 + (200 - (float)_orders[0].GetComponent<ImageComponent>().Height) / 2);
                    _orders[1].GetComponent<PositionComponent>().Position = new Vector2(position.X + 250 + (200 - (float)_orders[1].GetComponent<ImageComponent>().Width) / 2, position.Y + 140 + (200 - (float)_orders[1].GetComponent<ImageComponent>().Height) / 2);
                    break;
                case 3:
                    _orders[0].GetComponent<PositionComponent>().Position = new Vector2(position.X + 50  + (200 - (float)_orders[0].GetComponent<ImageComponent>().Width) / 2, position.Y + 40  + (200 - (float)_orders[0].GetComponent<ImageComponent>().Height) / 2);
                    _orders[1].GetComponent<PositionComponent>().Position = new Vector2(position.X + 250 + (200 - (float)_orders[1].GetComponent<ImageComponent>().Width) / 2, position.Y + 40  + (200 - (float)_orders[1].GetComponent<ImageComponent>().Height) / 2);
                    _orders[2].GetComponent<PositionComponent>().Position = new Vector2(position.X + 150 + (200 - (float)_orders[2].GetComponent<ImageComponent>().Width) / 2, position.Y + 240 + (200 - (float)_orders[2].GetComponent<ImageComponent>().Height) / 2);
                    break;
                case 4:
                    _orders[0].GetComponent<PositionComponent>().Position = new Vector2(position.X + 50  + (200 - (float)_orders[0].GetComponent<ImageComponent>().Width) / 2, position.Y + 40  + (200 - (float)_orders[0].GetComponent<ImageComponent>().Height) / 2);
                    _orders[1].GetComponent<PositionComponent>().Position = new Vector2(position.X + 250 + (200 - (float)_orders[1].GetComponent<ImageComponent>().Width) / 2, position.Y + 40  + (200 - (float)_orders[1].GetComponent<ImageComponent>().Height) / 2);
                    _orders[2].GetComponent<PositionComponent>().Position = new Vector2(position.X + 50  + (200 - (float)_orders[2].GetComponent<ImageComponent>().Width) / 2, position.Y + 240 + (200 - (float)_orders[2].GetComponent<ImageComponent>().Height) / 2);
                    _orders[3].GetComponent<PositionComponent>().Position = new Vector2(position.X + 250 + (200 - (float)_orders[3].GetComponent<ImageComponent>().Width) / 2, position.Y + 240 + (200 - (float)_orders[3].GetComponent<ImageComponent>().Height) / 2);
                    break;
            }
        }

        /// <summary>
        /// Geeft terug of de Customer de specifieke Order heeft.
        /// </summary>
        /// <param name="order">
        /// Order dat gecontroleerd moet worden.
        /// </param>
        /// <returns>
        /// Geeft terug of de Customer de specifieke Order heeft.
        /// </returns>
        public bool HasOrder(Order order) => _orders.Any(o => o.Type == order.Type);

        /// <summary>
        /// Geeft terug of de Customer de specifieke Order heeft.
        /// </summary>
        /// <param name="order">
        /// Order dat gecontroleerd moet worden.
        /// </param>
        /// <returns>
        /// Geeft terug of de Customer de specifieke Order heeft.
        /// </returns>
        public bool HasOrder(Order.OrderType order) => _orders.Any(o => o.Type == order);

        /// <summary>
        /// Geeft een Order terug wanneer de OrderType overeenkomt. Pakt altijd de eerste van de lijst _orders als er meerdere zijn.
        /// </summary>
        /// <param name="orderType">
        /// OrderType dat gecontroleerd moet worden.
        /// </param>
        /// <returns>
        /// Geeft een Order terug wanneer de OrderType overeenkomt.
        /// </returns>
        public Order GetOrder(Order.OrderType orderType) => _orders.Where(o => o.Type == orderType).First();
    }
}
