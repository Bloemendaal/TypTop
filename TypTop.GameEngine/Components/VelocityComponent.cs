using System.Numerics;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class VelocityComponent : Component, IUpdateable
    ***REMOVED***
        private PositionComponent _positionComponent;
        public Vector2 Velocity ***REMOVED*** get; set; ***REMOVED***
        public float Speed ***REMOVED*** get; set; ***REMOVED*** = 25f;

        public override void AddedToEntity()
        ***REMOVED***
            _positionComponent = Entity.GetComponent<PositionComponent>();
    ***REMOVED***

        public void Update(float deltaTime)
        ***REMOVED***
            // Update position
            _positionComponent.Position += Velocity * deltaTime * Speed;
    ***REMOVED***
***REMOVED***
***REMOVED***