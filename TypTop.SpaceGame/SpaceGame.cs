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
        // the properties are explained as follows
        //   Player represents the user who plays the game
        //   EnenyQueue is a queue of Enemy objects that are currently displayed on the screen
        //   LineHeight gives an integer, it is derived from LineHeight from Level
        //   Level represents the Level the user is playing at the moment
        //   R is a Random instance
        public Player Player { get; set; }
        public Queue<Enemy> EnemyQueue { get; set; }
        public int LineHeight { get; set; }
        public Level Level { get; set; }
        public Random R { get; set; }

        public SpaceGame()
        {
            // initializing
            R = new Random(DateTime.Now.Millisecond);
            Level = new Level(1, "SpaceGame", this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();
            LineHeight = Level.LineHeight;

            AddEntity(Player);
            AddEntity(new Enemy(1, new Word("test"), "Enemy",this));
        }
    }
}
