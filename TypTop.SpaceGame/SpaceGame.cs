using System;
***REMOVED***
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using Typop.SpaceGame;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;

namespace TypTop.SpaceGame
***REMOVED***
    public class SpaceGame : Game
    ***REMOVED***
        public Player Player ***REMOVED*** get; set; ***REMOVED***
        public Queue<Enemy> EnemyQueue ***REMOVED*** get; set; ***REMOVED***
        public Level Level ***REMOVED*** get; set; ***REMOVED***
        public SpaceGame()
        ***REMOVED***
            Level = new Level(1, this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();

            
            AddEntity(new Background(this));
            
            foreach (var enemy in Level.EnemyList)
            ***REMOVED***
                AddEntity(enemy);
        ***REMOVED***
            AddEntity(Player);
            AddEntity(new Line(this));
    ***REMOVED***
***REMOVED***
***REMOVED***
