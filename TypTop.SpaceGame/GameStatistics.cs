using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    class GameStatistics : Entity
    {
        public GameStatistics(SpaceGame game) : base(game)
        {
            ZIndex = 4;
            AddComponent(new PositionComponent(new Vector2(0,0)));
            //AddComponent(new GameStatisticsBackgroundComponent());
        }
    }
}
