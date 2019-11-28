using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
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
        public SpaceGame()
        {
            Level = new Level(1, this);
            Player = new Player(this);
            EnemyQueue = new Queue<Enemy>();

            // Sort enemy by height

            EnemyQueue = MakeEnemyQueue(Level.EnemyList);
            _inputQueue = new InputQueue(MakeWordsQueue(EnemyQueue))
            {
                RemoveOnSpace = true
            };
            // 
            // Adding entities 
            //
            //AddEntity(new Background(this));

            foreach (var enemy in EnemyQueue)
            {
                AddEntity(enemy);
            }

            AddEntity(Player);
            AddEntity(new Line(this));

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
            if (_inputQueue.Input.Peek().Finished)
            {
                foreach (var entity in this)
                {
                    if (entity is Enemy enemy)
                    {
                        if (Equals(enemy.Word, _inputQueue.Input.Peek()))
                        {
                            var currentEnemy = enemy.GetComponent<WordComponent>();
                            currentEnemy.Color = Brushes.GreenYellow;
                            currentEnemy.TypedColor = Brushes.GreenYellow;
                        }
                    }
                }
                
            }
            
        }
    }
}
