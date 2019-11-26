using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using Typop.SpaceGame;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class SpaceGame : Game
    {
        public Player Player { get; set; }
        public Queue<Enemy> EnemyQueue { get; set; }
        public Level Level { get; set; }
        public SpaceGame()
        {
            Level = new Level(1, this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();

            
            AddEntity(new Background(this));
            
            foreach (var enemy in Level.EnemyList)
            {
                AddEntity(enemy);
            }
            AddEntity(Player);
            AddEntity(new Line(this));
        }
    }
}
