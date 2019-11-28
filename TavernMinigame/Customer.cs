using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TavernMinigame
{
    public class Customer : Entity
    {
        public SpeechBubble SpeechBubble;
        private List<Order> _orders;
        public Customer(Game game) : base(game)
        {
            _orders = ((TavernGame)Game).GetOrder(Game.Rnd.Next(1, 4));
            SpeechBubble = new SpeechBubble(this, Game);
        }

        public bool HasOrder(Order order) => _orders.Any(o => o.Equals(order));
        public bool HasOrder(Order.OrderType order) => _orders.Any(o => o.Type == order);

        public Order GetOrder(Order.OrderType orderType) => _orders.Where(o => o.Type == orderType).First();
    }
}
