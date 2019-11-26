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
        public int UniqueOrderTypes
        ***REMOVED***
            get => _uniqueOrderTypes;
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

                _uniqueOrderTypes = value;

                List<int> indexes = new List<int>();
                for (int i = 0; i < _uniqueOrderTypes; i++)
                ***REMOVED***
                    int index = Rnd.Next(0, i - indexes.Count);
                    while (indexes.Contains(index) && index < _uniqueOrderTypes)
                    ***REMOVED***
                        index++;
                ***REMOVED***

                    if (index < _uniqueOrderTypes)
                    ***REMOVED***
                        indexes.Add(index);
                ***REMOVED***
            ***REMOVED***

                _orderTypes = new List<Order>();
                foreach (int item in indexes)
                ***REMOVED***
                    Order o = new Order((Order.OrderType)item, this);
                    o.GetComponent<PositionComponent>().Position = new Vector2(200, 200);
                    _orderTypes.Add(o);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
        private int _uniqueOrderTypes;
        private List<Order> _orderTypes;

        public List<Order> GetOrder(int amount)
        ***REMOVED***
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            ***REMOVED***
                result.Add(_orderTypes[Rnd.Next(0, UniqueOrderTypes)]);
        ***REMOVED***

            return result;
    ***REMOVED***

        public TavernGame(int uniqueOrderTypes)
        ***REMOVED***
            UniqueOrderTypes = uniqueOrderTypes;
            _orderTypes.ForEach(ot => AddEntity(ot));
    ***REMOVED***
***REMOVED***
***REMOVED***
