using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypTop.Gui.SpaceGame
{
    public class SpaceGame
    {
        public Player Player { get; set; }  // player
        public Queue<Enemy> EnemyQueue { get; set; }    // queue of visible enemies
        public DispatcherTimer Timer { get; private set; }  // timer
        public int LineHeight { get; private set; } // line when enemy hits player
        public Level Level { get; private set; }

        public SpaceGame()
        {
            Level = new Level(1);
            Player = new Player(Level.PlayerLives);
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 400;

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
            EnemyHitPlayer();

            // move each enemy on screen
            MoveEnemies();
        }

        public void Shoot()
        {
            // set score magnifyer, depends on enemy height (the higher the number, the larger the score will be)
            int i = 800-EnemyQueue.Peek().Y;

            // enemy gets killed, points are added up to score (multiplied by score magnifyer)
            Player.GainScore(EnemyQueue.Peek().Score * i);

            //enemy leaves queue
            EnemyQueue.Dequeue();
        }

        public void EnemyHitPlayer()
        {
            // check if contains objects
            if (EnemyQueue.Count > 0)
            {
                // player loses one life and enemy leaves queue when enemy hits player
                if (EnemyQueue.Peek().Y >= LineHeight)
                {
                    Player.LoseLife();
                    EnemyQueue.Dequeue();
                }
            }
        }

        public void MoveEnemies()
        {
            // move each enemy on screen
            foreach (Enemy enemy in EnemyQueue)
            {
                enemy.Move();
            }
        }
    }
}
