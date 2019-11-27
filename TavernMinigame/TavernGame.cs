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
            get => _tiles.Count;
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

                List<int> indexes = new List<int>();
                for (int i = 0; i < value; i++)
                ***REMOVED***
                    int index = Rnd.Next(0, max - i);
                    while (indexes.Contains(index))
                    ***REMOVED***
                        index++;
                        if (index == value)
                        ***REMOVED***
                            index = 0;
                    ***REMOVED***
                ***REMOVED***

                    indexes.Add(index);
            ***REMOVED***

                _tiles = new List<Tile>();
                for (int i = 0; i < indexes.Count; i++)
                ***REMOVED***
                    Tile t = new Tile((Order.OrderType)indexes[i], (float)Width - ((i + 1) * ((float)Tile.Width + 20)), this);
                    _tiles.Add(t);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
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
            _tiles.ForEach(t => ***REMOVED***
                AddEntity(t);
                AddEntity(t.Order);
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
