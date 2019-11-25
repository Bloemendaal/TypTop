using BasicGameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Logic;

namespace TavernMinigame
{
    public class Tile : Entity
    {
        public Order Order { get; private set; }
        public Word Word { get; set; }

        public Tile(Order order, Game game) : base($"tile {order.Type}", game)
        {
            Order = order;
        }
    }
}
