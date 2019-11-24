using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class TransformComponent : Component, IUpdateable, IResizable
    ***REMOVED***
        public Vector2 Position ***REMOVED*** get; set; ***REMOVED***
        public Vector2 Velocity ***REMOVED*** get; set; ***REMOVED***
        public float Speed ***REMOVED*** get; set; ***REMOVED*** = 25f;
        public bool Relative 
        ***REMOVED*** 
            get => _relative; 
            set ***REMOVED***
                if (value != _relative)
                ***REMOVED***
                    if (value)
                    ***REMOVED***
                        Position = new Vector2(Position.X / (float)Entity.Game.Width, Position.Y / (float)Entity.Game.Height);
                ***REMOVED***
                    else
                    ***REMOVED***
                        Position = new Vector2(Position.X / 100 * (float)Entity.Game.Width, Position.Y / 100 * (float)Entity.Game.Height);
                ***REMOVED***
            ***REMOVED***

                _relative = value;
        ***REMOVED***
    ***REMOVED***
        private bool _relative;

        public void Resize()
        ***REMOVED***
            Relative = Entity.Game.Relative;
    ***REMOVED***

        public void Update(float deltaTime)
        ***REMOVED***
            // Update position
            Position += Velocity * deltaTime * Speed;
    ***REMOVED***
***REMOVED***
***REMOVED***