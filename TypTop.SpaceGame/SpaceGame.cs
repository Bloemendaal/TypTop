using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class SpaceGame : Game
    {
        public Player Player { get; set; }
        public Queue<Enemy> EnemyQueue { get; set; }
        public int LineHeight { get; set; }
        public Level Level { get; set; }    
        public SpaceGame()
        {
            Level = new Level(1);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();
            LineHeight = 400;
            AddEntity(Player);
            AddEntity(new Enemy(1, new Word("test"), this));
        }
    }
}
