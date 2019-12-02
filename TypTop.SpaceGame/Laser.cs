using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypTop.GameEngine;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Laser : Entity
    {
        public Laser(SpaceGame game) : base(game)
        {
            ZIndex = 3;
            AddComponent(new LaserComponent(game));
        }
    }
}
