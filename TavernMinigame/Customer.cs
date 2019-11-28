using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TavernMinigame
{
    public class Customer : Entity
    {
        public SpeechBubble SpeechBubble;
        public int Count => _orders.Count;
        private readonly List<Order> _orders;

        public enum CustomerType { GunslingerMan, GunslingerWoman, LawsMan, LawsWoman, NativeGirl, NativeMan, OutlawMan, OutlawWoman, TownsMan, TownsWoman }
        public readonly CustomerType Type;

        public Customer(TavernGame game) : base(game)
        {
            ZIndex = 1;
            if (game is TavernGame tGame)
            {
                _orders = tGame.GetOrder(Game.Rnd.Next(1, 4));

                var types = Enum.GetNames(typeof(CustomerType));
                Type = (CustomerType)tGame.Rnd.Next(0, types.Length);

                AddComponent(new PositionComponent()
                {
                    Y = 800
                });
                AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/Customer/{Type.ToString().ToLower()}.png", UriKind.Relative)))
                {
                    Width = 500
                });

                SpeechBubble = new SpeechBubble(this, tGame);
            }
        }

        public void AddEntities()
        {
            Game.AddEntity(SpeechBubble);
            Game.AddEntity(this);
            _orders.ForEach(o => Game.AddEntity(o));
        }
        public void RemoveEntities()
        {
            _orders.ForEach(o => Game.RemoveEntity(o));
            Game.RemoveEntity(this);
            Game.RemoveEntity(SpeechBubble);
        }

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

        public void UpdatePosition(float index)
        {
            float x = (float)Game.Width - 500 * (index + 1) - 20;
            GetComponent<PositionComponent>().X = x;
            SpeechBubble.GetComponent<PositionComponent>().X = x;
            UpdateOrderPosition();
        }

        public void UpdateOrderPosition()
        {
            Vector2 position = SpeechBubble.GetComponent<PositionComponent>().Position;
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

        public bool HasOrder(Order order) => _orders.Any(o => o.Type == order.Type);
        public bool HasOrder(Order.OrderType order) => _orders.Any(o => o.Type == order);

        public Order GetOrder(Order.OrderType orderType) => _orders.Where(o => o.Type == orderType).First();
    }
}
