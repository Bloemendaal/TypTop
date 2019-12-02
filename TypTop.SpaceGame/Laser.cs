using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypTop.GameEngine;

namespace TypTop.SpaceGame
{
    public class Laser : Entity
    {
        public Laser(SpaceGame game) : base(game)
        {
            AddComponent(new LaserComponent(game));
        }
    }
}
