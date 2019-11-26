***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TavernMinigame
***REMOVED***
    public class Customer : Entity
    ***REMOVED***
        private List<Order> _orders;
        public Customer(Game game) : base(game)
        ***REMOVED***
            
    ***REMOVED***

        public Order GetOrder(Order.OrderType orderType) => _orders.Where(o => o.Type == orderType).First();
***REMOVED***
***REMOVED***
