using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.MinigameEngine;

namespace TypTop.JumpMinigame
{
    public class Lane : Entity
    {
        private readonly List<Platform> _platforms;

        public int Index { get; private set; }

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

        public Lane(int index, JumpGame minigame) : base(minigame)
        {
            Index = index;

            _positionComponent = new PositionComponent(Index * minigame.LaneWidth,0);
        }

        public List<float> Coordinates() => _platforms.Select(e => e.Y).ToList();
    }
}
