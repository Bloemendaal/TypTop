﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Line : Entity
    {
        public Line(float height, Game game) : base(game)
        {
            AddComponent(new PositionComponent()
            {
                Position = new Vector2(0, height)
            });
            AddComponent(new LineComponent());
        }
    }
}
