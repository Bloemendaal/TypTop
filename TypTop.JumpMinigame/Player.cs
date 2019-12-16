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
        private readonly PositionComponent _positionComponent;
        private readonly VelocityComponent _velocityComponent;

        private new readonly JumpGame Game;

        /// <summary>
        /// Current lane the player is jumping in.
        /// </summary>
        public Lane Lane
        { 
            get => _lane;
            set
            {
                if (value != null && Lane.Game.Equals(Game))
                {
                    _lane = value;
                }
            }
        }
        private Lane _lane;

        public Player(JumpGame game) : base(game)
        {
            Game = game;
            _positionComponent = new PositionComponent
            {
                Position = new Vector2(885, 100)
            };
            _velocityComponent = new VelocityComponent();

            AddComponent(new CameraComponent());
            AddComponent(_positionComponent);
            AddComponent(_velocityComponent);
            AddComponent(new AccelerationComponent
            {
                Acceleration = new Vector2(0, 1)
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
                _velocityComponent.Velocity = new Vector2(0, -32);
            }
            base.Update(deltaTime);
        }
    }
}
