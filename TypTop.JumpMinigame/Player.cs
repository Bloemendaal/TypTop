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

        private float _maxHeight = 500;


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
            ZIndex = 10;
            Game = game;
            _positionComponent = new PositionComponent
            {
                Y = _maxHeight
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
                if (Lane?.GetPlatforms(_maxHeight).Any(platform => platform.Y < _positionComponent.Y + _imageComponent.Height) ?? false)
                {
                    _maxHeight = 0;
                    _velocityComponent.Velocity = new Vector2(0, -30f);
                }
            }
            else if (Y > _maxHeight)
            {
                _maxHeight = Y;

                float diff = (float)JumpGame.Height - _maxHeight;
                if (diff > JumpGame.JumpHeight)
                {
                    CameraComponent.SetY(CameraComponent.GetY(Game) + diff, Game);
                }
            }

            base.Update(deltaTime);
        }
    }
}
