using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
***REMOVED***
using System.Numerics;
***REMOVED***

namespace TavernMinigame
***REMOVED***
    public class TavernGame : Game
    ***REMOVED***
        public int TileAmount
        ***REMOVED***
            get => _tileAmount;
            set ***REMOVED***
                if (value < 1)
                ***REMOVED***
                    value = 1;
            ***REMOVED***

                int max = Enum.GetNames(typeof(Order.OrderType)).Length;
                if (value > max)
                ***REMOVED***
                    value = max;
            ***REMOVED***

                _tileAmount = value;

                List<int> indexes = new List<int>();
                for (int i = 0; i < _tileAmount; i++)
                ***REMOVED***
                    int index = Rnd.Next(0, i - indexes.Count);
                    while (indexes.Contains(index) && index < _tileAmount)
                    ***REMOVED***
                        index++;
                ***REMOVED***

                    if (index < _tileAmount)
                    ***REMOVED***
                        indexes.Add(index);
                ***REMOVED***
            ***REMOVED***

                _tiles = new List<Tile>();
                foreach (int item in indexes)
                ***REMOVED***
                    Order o = new Order((Order.OrderType)item, this);
                    o.GetComponent<PositionComponent>().Position = new Vector2(200, 200);
                    _tiles.Add(new Tile(o, this));
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
        private int _tileAmount;
        private List<Tile> _tiles;

        public List<Order> GetOrder(int amount)
        ***REMOVED***
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            ***REMOVED***
                result.Add(_tiles[Rnd.Next(0, TileAmount)].Order);
        ***REMOVED***

            return result;
    ***REMOVED***

        public TavernGame(int tileAmount)
        ***REMOVED***
            AddEntity(new Background(this));
            TileAmount = tileAmount;
            _tiles.ForEach(t => AddEntity(t));
    ***REMOVED***
***REMOVED***
***REMOVED***
