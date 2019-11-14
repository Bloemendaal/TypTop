using System;
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypTop.Logic.SpaceGame
***REMOVED***
    public class SpaceGame
    ***REMOVED***
        public Player Player ***REMOVED*** get; set; ***REMOVED***  // player
        public List<Enemy> EnemyList ***REMOVED*** get; set; ***REMOVED***  // list of all enemies
        public Queue<Enemy> EnemyQueue ***REMOVED*** get; set; ***REMOVED***    // queue of visible enemies
        public DispatcherTimer Timer ***REMOVED*** get; private set; ***REMOVED***  // timer
        public int LineHeight ***REMOVED*** get; private set; ***REMOVED*** // line when enemy hits player
        public SpaceGame()
        ***REMOVED***
            Player = new Player();
            EnemyList = new List<Enemy>();
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 600;

            //  DispatcherTimer setup, ~59 intervals per second, 1000 / 60 = 16.6667... miliseconds
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
            Timer.Start();
    ***REMOVED***

        // timer event, fired each step
        private void Timer_Tick(object sender, EventArgs e) 
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
