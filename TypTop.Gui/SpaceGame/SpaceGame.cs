using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TypTop.Gui.SpaceGame
{
    public class SpaceGame : Game
    {
        public Player Player { get; set; }  // player
        public Queue<Enemy> EnemyQueue { get; set; }    // queue of visible enemies
        public int LineHeight { get; private set; } // line when enemy hits player
        public Level Level { get; private set; }

        public SpaceGame()
        {
            Level = new Level(1);
            Player = new Player();
            EnemyQueue = new Queue<Enemy>();

            LineHeight = 400;
        }

        // timer event, fired each step
        protected override void Timer_Tick(object sender, EventArgs e) 
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
