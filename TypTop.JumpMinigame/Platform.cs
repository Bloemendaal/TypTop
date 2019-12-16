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

        private readonly PositionComponent _positionComponent;

        public Platform(float y, Lane lane, JumpGame minigame) : base(minigame)
        {
            Lane = lane;

            if (minigame.Rnd.Next(1000001) < minigame.PlatformSolidRatio * 1000000)
            {
                BreakAmount = -1;
            }
            else
            {
                BreakAmount = minigame.Rnd.Next(
                    Math.Max(minigame.PlatformBreakAmount - minigame.PlatformBreakOffset, 0),
                    minigame.PlatformBreakAmount + minigame.PlatformBreakOffset + 1
                );
            }

            _positionComponent = new PositionComponent(Lane.X, y);

            AddComponent(new CameraComponent());
            AddComponent(_positionComponent);

            AddComponent(new RectangleComponent()
            {
                Fill = Brushes.Black,
                Width = minigame.LaneWidth,
                Height = 20
            });
        }

        public override void Update(float deltaTime)
        {
            if (Y > Game.Height)
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
                    break;
            }
        }
    }
}
