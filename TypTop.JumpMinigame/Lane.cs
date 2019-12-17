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
        private readonly List<Platform> _platforms = new List<Platform>();

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

        public new readonly JumpGame Game;


        public Lane(int index, JumpGame minigame) : base(minigame)
        {
            Index = index;
            Game = minigame;

            _positionComponent = new PositionComponent(Index * minigame.LaneWidth, 0);
        }


        public List<Platform> GetPlatforms(float maxHeight = 0)
        {
            return _platforms.Where(e => e.Y >= maxHeight).OrderBy(e => e.Y).ToList();
        }

        public void AddPlatform(float y, int? breakIndex = null)
        {
            Platform platform = breakIndex == null ? new Platform(y, this, Game) : new Platform(y, this, (int)breakIndex, Game);
            _platforms.Add(platform);
            Game.AddEntity(platform);
        }
        public bool RemovePlatform(Platform platform) => Game.RemoveEntity(platform) && _platforms.Remove(platform);
    }
}
