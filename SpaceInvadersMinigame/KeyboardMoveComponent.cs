using System.Numerics;
using System.Windows.Input;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class KeyboardMoveComponent : Component, IUpdateable
    ***REMOVED***
        private VelocityComponent _velocityComponent;
        
        public override void AddedToEntity()
        ***REMOVED***
            _velocityComponent = Entity.GetComponent<VelocityComponent>();
    ***REMOVED***

        public void Update(float deltaTime)
        ***REMOVED***
            Vector2 tmpVelocity;

            if (Keyboard.IsKeyDown(Key.A))
            ***REMOVED***
                tmpVelocity.X = -5;
        ***REMOVED***
            else if (Keyboard.IsKeyDown(Key.D))
            ***REMOVED***
                tmpVelocity.X = 5;
        ***REMOVED***
            else
            ***REMOVED***
                tmpVelocity.X = 0;
        ***REMOVED***

            if (Keyboard.IsKeyDown(Key.W))
            ***REMOVED***
                tmpVelocity.Y = -5;
        ***REMOVED***
            else if (Keyboard.IsKeyDown(Key.S))
            ***REMOVED***
                tmpVelocity.Y = 5;
        ***REMOVED***
            else
            ***REMOVED***
                tmpVelocity.Y = 0;
        ***REMOVED***
            _velocityComponent.Velocity = tmpVelocity;
    ***REMOVED***
***REMOVED***
***REMOVED***