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
        private List<Order> _orders;
        public Customer(Game game) : base("customer", game)
        {
            
        }

        public Order GetOrder(Order.OrderType orderType) => _orders.Where(o => o.Type == orderType).First();
    }
}
