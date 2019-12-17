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
        private readonly ImageComponent _imageComponent;

        private new readonly JumpGame Game;

        public float X
        {
            get => _positionComponent.X;
            set => _positionComponent.X = value;
        }
        public float Y
        {
            get => _positionComponent.Y;
            set => _positionComponent.Y = value;
        }


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
            ZIndex = 10;
            Game = game;
            _positionComponent = new PositionComponent
            {
                Position = new Vector2(885, 100)
            };
            _velocityComponent = new VelocityComponent();

            _imageComponent = new ImageComponent(new BitmapImage(new Uri(@"Images/spaceship.png", UriKind.Relative)))
            {
                Width = 100
            };

            AddComponent(new CameraComponent());
            AddComponent(_positionComponent);
            AddComponent(_velocityComponent);
            AddComponent(new AccelerationComponent
            {
                Acceleration = new Vector2(0, 1)
            });

            AddComponent(_imageComponent);
        }

        public override void Update(float deltaTime)
        {
            if (_velocityComponent.Velocity.Y > 0)
            {
                if (_positionComponent.Y > 980)
                    _velocityComponent.Velocity = new Vector2(0, -30f);

                /*
                Lane.GetPlatforms().ForEach(platform =>
                {
                    if (platform.Y > _positionComponent.Y)
                    {
                        _velocityComponent.Velocity = new Vector2(0, 30f);
                    }
                });
                */
            }

            base.Update(deltaTime);
        }
    }
}
