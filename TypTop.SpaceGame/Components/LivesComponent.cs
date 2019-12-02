using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class LivesComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        public bool Hidden { get; set; }

        public void Draw(DrawingContext context)
        {
            throw new NotImplementedException();
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
