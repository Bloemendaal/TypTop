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
        public int UniqueOrderTypes
        {
            get => _uniqueOrderTypes;
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

                _uniqueOrderTypes = value;

                List<int> indexes = new List<int>();
                for (int i = 0; i < _uniqueOrderTypes; i++)
                {
                    int index = Rnd.Next(0, i - indexes.Count);
                    while (indexes.Contains(index) && index < _uniqueOrderTypes)
                    {
                        index++;
                    }

                    if (index < _uniqueOrderTypes)
                    {
                        indexes.Add(index);
                    }
                }

                _orderTypes = new List<Order>();
                foreach (int item in indexes)
                {
                    Order o = new Order((Order.OrderType)item, this);
                    o.GetComponent<PositionComponent>().Position = new Vector2(200, 200);
                    _orderTypes.Add(o);
                }
            }
        }
        private int _uniqueOrderTypes;
        private List<Order> _orderTypes;

        public List<Order> GetOrder(int amount)
        {
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            {
                result.Add(_orderTypes[Rnd.Next(0, UniqueOrderTypes)]);
            }

            return result;
        }

        public TavernGame(int uniqueOrderTypes)
        {
            UniqueOrderTypes = uniqueOrderTypes;
            _orderTypes.ForEach(ot => AddEntity(ot));
        }
    }
}
