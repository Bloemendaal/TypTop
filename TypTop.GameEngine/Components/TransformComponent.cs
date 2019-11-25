using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class TransformComponent : Component, IUpdateable
    ***REMOVED***
        public Vector2 Position ***REMOVED*** get; set; ***REMOVED***
        public Vector2 Velocity ***REMOVED*** get; set; ***REMOVED***
        public float Speed ***REMOVED*** get; set; ***REMOVED*** = 25f;

        public void Update(float deltaTime)
        ***REMOVED***
            // Update position
            Position += Velocity * deltaTime * Speed;
    ***REMOVED***
***REMOVED***
***REMOVED***