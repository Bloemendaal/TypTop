using BasicGameEngine;
using System;
***REMOVED***
***REMOVED***
using TypTop.Logic;

namespace TavernMinigame
***REMOVED***
    public class Tile : Entity
    ***REMOVED***
        public Order Order ***REMOVED*** get; private set; ***REMOVED***
        public Word Word ***REMOVED*** get; set; ***REMOVED***

        public Tile(Order order, Game game) : base($"tile ***REMOVED***order.Type***REMOVED***", game)
        ***REMOVED***
            Order = order;
    ***REMOVED***
***REMOVED***
***REMOVED***
