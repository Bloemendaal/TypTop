using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class PositionComponent : Component
    ***REMOVED***
        public Vector2 Position
        ***REMOVED***
            get => _position;
            set
            ***REMOVED***
                _position = value;
        ***REMOVED***
    ***REMOVED***
        private Vector2 _position;

        public float X
        ***REMOVED***
            get => Position == null ? 0 : Position.X;
            set
            ***REMOVED***
                if (_position == null)
                ***REMOVED***
                    _position = new Vector2(value, 0);
            ***REMOVED***
                else
                ***REMOVED***
                    _position.X = value;
            ***REMOVED***
                
        ***REMOVED***
    ***REMOVED***
        public float Y
        ***REMOVED***
            get => Position == null ? 0 : Position.Y;
            set
            ***REMOVED***
                if (_position == null)
                ***REMOVED***
                    _position = new Vector2(0, value);
            ***REMOVED***
                else
                ***REMOVED***
                    _position.Y = value;
            ***REMOVED***

        ***REMOVED***
    ***REMOVED***

        public PositionComponent() : this(new Vector2(0, 0)) ***REMOVED*** ***REMOVED***
        public PositionComponent(float x, float y) : this(new Vector2(x, y)) ***REMOVED*** ***REMOVED***
        public PositionComponent(Vector2 position)
        ***REMOVED***
            Position = position;
    ***REMOVED***

***REMOVED***
***REMOVED***