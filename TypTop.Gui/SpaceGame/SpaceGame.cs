using System;
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypTop.Gui.SpaceGame
***REMOVED***
    public class SpaceGame : Game
    ***REMOVED***
        public Player Player ***REMOVED*** get; set; ***REMOVED***  // player
        public Queue<Enemy> EnemyQueue ***REMOVED*** get; set; ***REMOVED***    // queue of visible enemies
        public int LineHeight ***REMOVED*** get; private set; ***REMOVED*** // line when enemy hits player
        public Level Level ***REMOVED*** get; private set; ***REMOVED***

        public SpaceGame()
        ***REMOVED***
            Level = new Level(1);
            Player = new Player();
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 400;
    ***REMOVED***

        // timer event, fired each step
        protected override void Timer_Tick(object sender, EventArgs e) 
        ***REMOVED***
            // player loses one life and enemy leaves queue when enemy hits player
            EnemyHitPlayer();

            // move each enemy on screen
            MoveEnemies();
    ***REMOVED***

        public void Shoot()
        ***REMOVED***
            // set score magnifyer, depends on enemy height (the higher the number, the larger the score will be)
            int i = 800-EnemyQueue.Peek().Y;

            // enemy gets killed, points are added up to score (multiplied by score magnifyer)
            Player.GainScore(EnemyQueue.Peek().Score * i);

            //enemy leaves queue
            EnemyQueue.Dequeue();
    ***REMOVED***

        public void EnemyHitPlayer()
        ***REMOVED***
            // check if contains objects
            if (EnemyQueue.Count > 0)
            ***REMOVED***
                // player loses one life and enemy leaves queue when enemy hits player
                if (EnemyQueue.Peek().Y >= LineHeight)
                ***REMOVED***
                    Player.LoseLife();
                    EnemyQueue.Dequeue();
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        public void MoveEnemies()
        ***REMOVED***
            // move each enemy on screen
            foreach (Enemy enemy in EnemyQueue)
            ***REMOVED***
                enemy.Move();
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***
