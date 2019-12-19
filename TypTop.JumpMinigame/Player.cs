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
        public float AbsoluteMinimalY { get; private set; }


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

            _imageComponent = new ImageComponent(new BitmapImage(new Uri(@"Images/jumpPlayer.png", UriKind.Relative)))
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
                if (!Game.SaveJump && _velocityComponent.Velocity.Y > 0)
                {
                    _minHeight = Y + (float)_imageComponent.Height;
                }

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
                        Game.CheckGeneratePlatforms();
                        break;
                    }
                }
            }
            else
            {
                if (Y + (float)_imageComponent.Height < _minHeight)
                {
                    _minHeight = Y + (float)_imageComponent.Height;
                }

                var targetY = Math.Min(AbsoluteMinimalY, _positionComponent.AbsoluteY - JumpGame.JumpHeight);

                AbsoluteMinimalY = Lerp(AbsoluteMinimalY, targetY, 0.1f);
                Game.Score.Amount = (int)(Math.Abs(Math.Min(AbsoluteMinimalY, 0)) / 10);

                CameraComponent.SetY(AbsoluteMinimalY, Game);
            }


            base.Update(deltaTime);
        }

        float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}
