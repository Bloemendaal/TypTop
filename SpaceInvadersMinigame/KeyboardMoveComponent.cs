using System.Numerics;
using System.Windows.Input;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace SpaceInvadersMinigame
{
    public class KeyboardMoveComponent : Component, IUpdateable
    {
        private VelocityComponent _velocityComponent;
        
        public override void AddedToEntity()
        {
            _velocityComponent = Entity.GetComponent<VelocityComponent>();
        }

        public void Update(float deltaTime)
        {
            Vector2 tmpVelocity;

            if (Keyboard.IsKeyDown(Key.A))
            {
                tmpVelocity.X = -5;
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                tmpVelocity.X = 5;
            }
            else
            {
                tmpVelocity.X = 0;
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
                tmpVelocity.Y = -5;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                tmpVelocity.Y = 5;
            }
            else
            {
                tmpVelocity.Y = 0;
            }
            _velocityComponent.Velocity = tmpVelocity;
        }
    }
}