using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.JumpMinigame
{
    public class Player : Entity
    {
        private PositionComponent _positionComponent;
        private VelocityComponent _velocityComponent;

        public Player(Game game) : base(game)
        {
            _positionComponent = new PositionComponent()
            {
                Position = new Vector2(885, 100)
            };
            _velocityComponent = new VelocityComponent();

            AddComponent(new CameraComponent());
            AddComponent(_positionComponent);
            AddComponent(_velocityComponent);
            AddComponent(new AccelerationComponent()
            {
                Acceleration = new Vector2(0, 0.5f)
            });

            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/spaceship.png", UriKind.Relative)))
            {
                Width = 100
            });
        }

        public override void Update(float deltaTime)
        {
            if (_positionComponent.Y > 980)
            {
                _velocityComponent.Velocity = -_velocityComponent.Velocity;
            }
            base.Update(deltaTime);
        }
    }
}
