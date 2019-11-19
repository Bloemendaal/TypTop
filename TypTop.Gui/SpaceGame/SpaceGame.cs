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
        public List<Enemy> EnemyList ***REMOVED*** get; set; ***REMOVED***  // list of all enemies
        public Queue<Enemy> EnemyQueue ***REMOVED*** get; set; ***REMOVED***    // queue of visible enemies
        public int LineHeight ***REMOVED*** get; private set; ***REMOVED*** // line when enemy hits player
        public SpaceGame()
        ***REMOVED***
            Player = new Player();
            EnemyList = new List<Enemy>();
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 400;
    ***REMOVED***

        // timer event, fired each step
        protected override void Timer_Tick(object sender, EventArgs e) 
        ***REMOVED***
            // player loses one life and enemy leaves queue when enemy hits player
            if (EnemyQueue.Peek().Y <= LineHeight) 
            ***REMOVED***
                Player.LoseLife();
                EnemyQueue.Dequeue();   
        ***REMOVED***

            // move each enemy on screen
            foreach (Enemy enemy in EnemyQueue)
            ***REMOVED***
                enemy.Move();   
        ***REMOVED***
    ***REMOVED***

        public void Shoot()
        ***REMOVED***
            // set score magnifyer, depends on enemy height (the higher the number, the larger the score will be)
            int i = 800-EnemyQueue.Peek().Y;

            // enemy gets killed, points are added up to score (multiplied by score magnifyer), enemy leaves queue
            Player.GainScore(EnemyQueue.Dequeue().Score * i);
    ***REMOVED***
***REMOVED***
***REMOVED***
