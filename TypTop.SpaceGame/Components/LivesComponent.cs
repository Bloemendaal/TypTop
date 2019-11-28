using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class LivesComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;
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
