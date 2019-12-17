using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.JumpMinigame.Components;

namespace TypTop.JumpMinigame
{
    public class Platform : Entity
    {
        public int BreakAmount { get; private set; }
        public Lane Lane { get; private set; }

        public new readonly JumpGame Game;

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

        public const int Height = 20;

        private readonly PositionComponent _positionComponent;
        private readonly RectangleComponent _rectangleComponent;

        public Platform(float y, Lane lane, JumpGame minigame) : this(y, lane, GetBreakAmount(minigame), minigame) { }
        public Platform(float y, Lane lane, int? breakAmount, JumpGame minigame) : base(minigame)
        {
            ZIndex = 1;
            Game = minigame;
            Lane = lane;
            BreakAmount = breakAmount == null ? GetBreakAmount(minigame) : (int)breakAmount;

            _positionComponent = new PositionComponent(Lane.X, y);
            _rectangleComponent = new RectangleComponent()
            {
                Fill = BreakAmount == -1 ? Brushes.Black : new SolidColorBrush(Brushes.DarkGreen.Color)
                {
                    Opacity = (BreakAmount + 1) / (minigame.PlatformBreakAmount + minigame.PlatformBreakOffset + 1)
                },
                Width = minigame.LaneWidth,
                Height = Height
            };

            AddComponent(new CameraComponent());
            AddComponent(_positionComponent);
            AddComponent(_rectangleComponent);
        }

        private static int GetBreakAmount(JumpGame minigame)
        {
            if (minigame.Rnd.Next(1000001) < minigame.PlatformSolidRatio * 1000000)
            {
                return -1;
            }

            return minigame.Rnd.Next(
               Math.Max(minigame.PlatformBreakAmount - minigame.PlatformBreakOffset, 0),
               minigame.PlatformBreakAmount + minigame.PlatformBreakOffset + 1
            );
        }

        public override void Update(float deltaTime)
        {
            if (Y > JumpGame.Height)
            {
                Lane.RemovePlatform(this);
            }

            base.Update(deltaTime);
        }

        public void Jump()
        {
            switch (BreakAmount)
            {
                case -1:
                    return;
                case 0:
                    Game.RemoveEntity(this);
                    break;
                default:
                    BreakAmount--;
                    _rectangleComponent.Fill.Opacity = (BreakAmount + 1) / (Game.PlatformBreakAmount + Game.PlatformBreakOffset + 1);
                    break;
            }
        }
    }
}
