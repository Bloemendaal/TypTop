using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypTop.Game.SpaceGame
{
    public class SpaceGame
    {
        public Player Player { get; set; }  // player
        public List<Enemy> EnemyList { get; set; }  // list of all enemies
        public Queue<Enemy> EnemyQueue { get; set; }    // queue of visible enemies
        public DispatcherTimer Timer { get; private set; }  // timer
        public int LineHeight { get; private set; } // line when enemy hits player
        public SpaceGame()
        {
            Player = new Player();
            EnemyList = new List<Enemy>();
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 600;

            //  DispatcherTimer setup, ~59 intervals per second, 1000 / 60 = 16.6667... miliseconds
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
            Timer.Start();
        }

        // timer event, fired each step
        private void Timer_Tick(object sender, EventArgs e) 
        {
            // player loses one life and enemy leaves queue when enemy hits player
            if (EnemyQueue.Peek().Y <= LineHeight) 
            {
                Player.LoseLife();
                EnemyQueue.Dequeue();   
            }

            // move each enemy on screen
            foreach (Enemy enemy in EnemyQueue)
            {
                enemy.Move();   
            }
        }

        public void Shoot()
        {
            // set score magnifyer, depends on enemy height (the higher the number, the larger the score will be)
            int i = 800-EnemyQueue.Peek().Y;

            // enemy gets killed, points are added up to score (multiplied by score magnifyer), enemy leaves queue
            Player.GainScore(EnemyQueue.Dequeue().Score * i);
        }
    }
}
