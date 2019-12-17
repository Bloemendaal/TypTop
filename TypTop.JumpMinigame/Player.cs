using System;
using System.Collections.Generic;
using System.Linq;
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
            get => _positionComponent.X - (float)_imageComponent.Width / 2;
            set => _positionComponent.X = value - (float)_imageComponent.Width / 2;
        }
        public float Y
        {
            get => _positionComponent.Y;
            set => _positionComponent.Y = value;
        }

        private float _minHeight = 500;
        private float _absMinHeight;


        /// <summary>
        /// Current lane the player is jumping in.
        /// </summary>
        public Lane Lane
        { 
            get => _lane;
            set
            {
                if (value != null && (Lane?.Game.Equals(Game) ?? true))
                {
                    _lane = value;
                }
            }
        }
        private Lane _lane;

        public Player(JumpGame game) : base(game)
        {
            ZIndex = 2;
            Game = game;
            _positionComponent = new PositionComponent
            {
                Y = _minHeight
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

        public void SwitchLane(Lane lane)
        {
            if (!lane.Equals(Lane) && lane != null)
            {
                Lane = lane;
                X = Lane.X + Game.LaneWidth / 2;
            }
        }

        public override void Update(float deltaTime)
        {
            if (_velocityComponent.Velocity.Y > 0)
            {
                foreach (Platform platform in Lane?.GetPlatforms(_minHeight))
                {
                    if (platform.Y < _positionComponent.Y + _imageComponent.Height)
                    {
                        _minHeight = (float)JumpGame.Height;
                        _velocityComponent.Velocity = new Vector2(0, -30f);

                        platform.Jump();
                        break;
                    }
                }
            }
            else
            {
                if (Y < _minHeight)
                {
                    _minHeight = Y;
                }

                _absMinHeight = Math.Min(_absMinHeight, _positionComponent.AbsoluteY - JumpGame.JumpHeight);

                CameraComponent.SetY(_absMinHeight, Game);
            }


            base.Update(deltaTime);
        }
    }
}
