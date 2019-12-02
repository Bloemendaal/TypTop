using System;
using System.Collections.Generic;
using System.Text;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.SpaceMinigame.Components
{
    public class EnemyPositionComponent : Component
    {
        private Line _line;
        private SpaceGame _game;
        
        public EnemyPositionComponent(SpaceGame game)
        {
            foreach (var entity in game)
            {
                if (entity is Line line)
                {
                    _line = line;
                }
            }

            _game = game;
        }
        
        public void Update()
        {
            if (Entity.GetComponent<PositionComponent>().Y > _line.GetComponent<PositionComponent>().Y)
            {
                _game.Lives.Amount--;
            }
        }
    }
}
