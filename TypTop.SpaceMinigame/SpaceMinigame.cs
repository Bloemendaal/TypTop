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
    public class SpaceMinigame : Minigame
    {
        public Player Player { get; set; }
        public List<Enemy> EnemyList { get; set; }
        private readonly InputList _inputList;
        public Level Level { get; set; }
        public Line Line { get; set; }

        public SpaceMinigame(WinCondition winCondition) : base(winCondition)
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
            Line = new Line(this);
            EnemyList = Level.EnemyList;
            _inputList = new InputList(new List<Word>())
            {
                FocusOnHighIndex = true
            };

            // 
            // Adding entities 
            //

            AddEntity(new Background("space.jpg", this));
            AddEntity(new GameStatistics(this));
            EnemyList.ForEach(e => AddEntity(e));

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

        public override void Update(float deltaTime)
        {
            _inputList.Input = EnemyList.Where(e => e.Y - 150 > 0).Select(e => e.Word).ToList();
            base.Update(deltaTime);
        }

        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            _inputList.Input = EnemyList.Where(e => e.Y + 150 > 0).Select(e => e.Word).ToList();
            _inputList.TextInput(e.Text);
            RemoveEntity<Laser>();

            EnemyList.Where(e => e.Word.Finished).ToList().ForEach(e => {
                AddEntity(new Laser(e, this));
                RemoveEntity(e);
                Score.Amount += e.Score;
                EnemyList.Remove(e);
            });
        }
    }
}
