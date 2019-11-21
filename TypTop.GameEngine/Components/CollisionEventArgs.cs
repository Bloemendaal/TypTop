using System.Numerics;
using System.Windows;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class CollisionEventArgs
    ***REMOVED***
        public Entity Entity ***REMOVED*** get; ***REMOVED***

        public Vector2 PenetrationVector ***REMOVED*** get; ***REMOVED***

        public CollisionEventArgs(Entity entity, Vector2 penetrationVector)
        ***REMOVED***
            Entity = entity;
            PenetrationVector = penetrationVector;
    ***REMOVED***
***REMOVED***
***REMOVED***