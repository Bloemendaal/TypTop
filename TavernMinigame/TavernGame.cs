using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TypTop.Logic;

namespace TavernMinigame
{
    public class TavernGame : Game
    {
        public int TileAmount
        {
            get => _tiles.Count;
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

                List<int> indexes = new List<int>();
                for (int i = 0; i < value; i++)
                {
                    int index = Rnd.Next(0, max - i);
                    while (indexes.Contains(index))
                    {
                        index++;
                        if (index == value)
                        {
                            index = 0;
                        }
                    }

                    indexes.Add(index);
                }

                _tiles = new List<Tile>();
                for (int i = 0; i < indexes.Count; i++)
                {
                    Tile t = new Tile((Order.OrderType)indexes[i], (float)Width - ((i + 1) * ((float)Tile.Width + 20)), this);
                    _tiles.Add(t);
                }
            }
        }
        private List<Tile> _tiles;
        private List<Word> _words;

        private InputList _inputList;

        public List<Order> GetOrder(int amount)
        {
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            {
                result.Add(_tiles[Rnd.Next(0, TileAmount)].Order);
            }

            return result;
        }

        public TavernGame(int tileAmount, List<Word> words)
        {
            _words = words;
            _inputList = new InputList(_words);


            AddEntity(new Background(this));
            TileAmount = tileAmount;
            _tiles.ForEach(t => {
                AddEntity(t);
                AddEntity(t.Order);
            });
        }
    }
}
