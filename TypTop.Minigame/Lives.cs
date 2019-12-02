using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.MinigameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class Lives : Entity
    {
        public int Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _amount = value;
            }
        }
        private int _amount;

        public Lives(Vector2 position, Game game) : base(game)
        {
            AddComponent(new PositionComponent(position));
            AddComponent(new LivesComponent());
        }
        public Lives(float x, float y, Game game) : this(new Vector2(x, y), game) { }
    }
}
