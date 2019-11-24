using System;
using System.Collections.Generic;
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
    }
}
