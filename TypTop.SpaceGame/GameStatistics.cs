using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.SpaceGame.Components;

namespace TypTop.SpaceGame
{
    class GameStatistics : Entity
    {
        public GameStatistics(SpaceGame game) : base(game)
        {
            AddComponent(new PositionComponent(new Vector2(0,0)));
            //AddComponent(new GameStatisticsBackgroundComponent());
            AddComponent(new PlayerInfoComponent(game));
            AddComponent(new LivesComponent(game));
            
            
        }
    }
}
