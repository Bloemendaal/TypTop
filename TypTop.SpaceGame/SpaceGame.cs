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
using TypTop.SpaceGame;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class SpaceGame : Game
    {
        public Player Player { get; set; }
        public Queue<Enemy> EnemyQueue { get; set; }
        private InputQueue _inputQueue;
        public Level Level { get; set; }
        public Line Line { get; set; }

        public SpaceGame()
        {
            Level = new Level(1, this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();
            Line = new Line(this);
            EnemyQueue = MakeEnemyQueue(Level.EnemyList);
            _inputQueue = new InputQueue(MakeWordsQueue(EnemyQueue))
            {
                RemoveOnSpace = false,
                RemoveOnFinished = true
            };

            // 
            // Adding entities 
            //

            AddEntity(new Background(this));
            AddEntity(new GameStatistics(this));
            foreach (var enemy in EnemyQueue)
            {
                AddEntity(enemy);
            }

            AddEntity(Player);
            AddEntity(Line);

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
            _inputQueue.TextInput(e.Text);
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
                            Player.GainScore(enemy.Score);
                        }
                    }
                }
            }
        }
    }
}
