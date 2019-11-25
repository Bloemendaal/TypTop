using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TavernMinigame
{
    public class TavernGame : Game
    {
        public int TileAmount
        {
            get => _tileAmount;
            set {
                if (value < 1)
                {
                    value = 1;
                }

                int max = Enum.GetNames(typeof(Order.OrderType)).Length;
                if (value > max)
                {
                    value = max;
                }

                _tileAmount = value;

                List<int> indexes = new List<int>();
                for (int i = 0; i < _tileAmount; i++)
                {
                    int index = Rnd.Next(0, i - indexes.Count);
                    while (indexes.Contains(index) && index < _tileAmount)
                    {
                        index++;
                    }

                    if (index < _tileAmount)
                    {
                        indexes.Add(index);
                    }
                }

                _tiles = new List<Tile>();
                foreach (int item in indexes)
                {
                    Order o = new Order((Order.OrderType)item, this);
                    o.GetComponent<PositionComponent>().Position = new Vector2(200, 200);
                    _tiles.Add(new Tile(o, this));
                }
            }
        }
        private int _tileAmount;
        private List<Tile> _tiles;

        public List<Order> GetOrder(int amount)
        {
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            {
                result.Add(_tiles[Rnd.Next(0, TileAmount)].Order);
            }

            return result;
        }

        public TavernGame(int tileAmount)
        {
            AddEntity(new Background(this));
            TileAmount = tileAmount;
            _tiles.ForEach(t => AddEntity(t));
        }
    }
}
