using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class Line : Entity
    {
        private PositionComponent _positionComponent;
        public Line(Game game) : base("Line", game)
        {
            _positionComponent = new PositionComponent()
            {
                Position = new Vector2(0, 900)
            };
            AddComponent(_positionComponent);
            AddComponent(new LineComponent());
        }
    }
}
