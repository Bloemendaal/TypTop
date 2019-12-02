using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.SpaceMinigame;
using TypTop.Logic;
using TypTop.MinigameEngine;
using TypTop.MinigameEngine.WinConditions;

namespace TypTop.SpaceMinigame
{
    public class SpaceGame : Minigame
    {
        public Player Player { get; set; }
        public Queue<Enemy> EnemyQueue { get; set; }
        public InputQueue InputQueue { get; set; }
        public Level Level { get; set; }
        public Line Line { get; set; }

        public SpaceGame(WinCondition winCondition) : base(winCondition)
        {
            Score = new Score(10, 10, this)
            {
                Direction = Score.FloatDirection.Down,
                ZIndex = 5,
                Prefix = "Score : ",
                Color = Brushes.White,
                Positive = Brushes.LightGreen,
                Negative = Brushes.Red,
                FontSize = 40,
                Right = true
            };
            Lives = new Lives(200, 10, this) 
            { 
                Amount = 4,
                ZIndex = 5 
            };

            Finish = delegate ()
            {
                return Lives.Amount <= 0;
            };

            Level = new Level(1, this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();
            Line = new Line(this);
            EnemyQueue = MakeEnemyQueue(Level.EnemyList);
            InputQueue = new InputQueue(MakeWordsQueue(EnemyQueue))
            {
                RemoveOnSpace = false,
                RemoveOnFinished = true
            };

            // 
            // Adding entities 
            //

            AddEntity(new Background("space.jpg", this));
            AddEntity(new GameStatistics(this));
            foreach (var enemy in EnemyQueue)
            {
                AddEntity(enemy);
            }

            AddEntity(Player);
            AddEntity(Line);

            Score.UpdateText();
            AddEntity(Score);
            AddEntity(Lives);

            //
            // Events
            //

            TextInput += OnTextInput;
        }

        private Queue<Enemy> MakeEnemyQueue(List<Enemy> enemyList)
        {
            var tempQueue = new Queue<Enemy>();
            foreach (var enemy in enemyList.OrderByDescending(e => e.Y))
            {
                tempQueue.Enqueue(enemy);
            }

            return tempQueue;
        }

        private Queue<Word> MakeWordsQueue(Queue<Enemy> enemyQueue)
        {
            Queue<Word> tempWordsQueue = new Queue<Word>();
            foreach (var enemy in enemyQueue)
            {
                tempWordsQueue.Enqueue(enemy.Word);
            }

            return tempWordsQueue;
        }

        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            InputQueue.TextInput(e.Text);
            foreach (var entity in this.ToList().OfType<Laser>())
            {
                RemoveEntity(entity);
            }

            foreach (var entity in this.ToList())
            {
                if (entity is Enemy enemy)
                {
                    if (enemy.Word.Finished)
                    {
                        if (Equals(enemy.Word, EnemyQueue.First().Word))
                        {
                            RemoveEntity(enemy);
                            AddEntity(new Laser(this));
                            EnemyQueue.Dequeue();
                            Score.Amount += enemy.Score;
                        }
                    }
                }
            }
        }
    }
}
