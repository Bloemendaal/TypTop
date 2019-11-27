***REMOVED***
***REMOVED***
using System.Numerics;
***REMOVED***
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
***REMOVED***
    public class Line : Entity
    ***REMOVED***
        private PositionComponent _positionComponent;
        public Line(Game game) : base(game)
        ***REMOVED***
            _positionComponent = new PositionComponent()
            ***REMOVED***
                Position = new Vector2(0, 900)
        ***REMOVED***;
            AddComponent(_positionComponent);
            AddComponent(new LineComponent());
    ***REMOVED***
***REMOVED***
***REMOVED***
