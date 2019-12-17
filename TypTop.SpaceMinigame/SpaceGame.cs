using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.SpaceMinigame
{
    public class SpaceGame : Minigame
    {
        private readonly List<Enemy> _enemyList = new List<Enemy>();

        private readonly InputList _inputList = new InputList(null)
        {
            FocusOnHighIndex = true
        };

        //
        // Vars
        //
        private readonly List<Word> _words;
        private int _enemyAmount;
        private float _enemyVelocity = 1;
        private float _enemyVelocityOffset;
        private float _lineHeight = 950;

        public SpaceGame(Level level) : base(level)
        {
            if (level != null && level.Properties != null)
            {
                // Words
                if (level.Properties.TryGetValue("Words", out object wordsObject) &&
                    wordsObject is IEnumerable<Word> words)
                    _words = new List<Word>(words);
                else
                    throw new ArgumentException("'Words' is missing or not valid");

                //Lives
                if (level.Properties.TryGetValue("Lives", out object livesObject) && livesObject is int lives)
                    Lives = new Lives(250, 10, this)
                    {
                        Amount = lives,
                        ZIndex = 5
                    };
                else
                    throw new ArgumentException("'Lives' is missing or not valid");

                // EnemyAmount
                EnemyAmount =
                    level.Properties.TryGetValue("EnemyAmount", out object enemyAmountObject) &&
                    enemyAmountObject is int enemyAmount
                        ? enemyAmount
                        : _words.Count;

                // EnemyVelocity
                if (level.Properties.TryGetValue("EnemyVelocity", out object enemyVelocityObject) &&
                    enemyVelocityObject is float enemyVelocity) EnemyVelocity = enemyVelocity;
                // EnemyVelocityOffset
                if (level.Properties.TryGetValue("EnemyVelocityOffset", out object enemyVelocityOffsetObject) &&
                    enemyVelocityOffsetObject is float enemyVelocityOffset) EnemyVelocityOffset = enemyVelocityOffset;

                // LineHeight
                if (level.Properties.TryGetValue("LineHeight", out object lineHeightObject) &&
                    lineHeightObject is float lineHeight) LineHeight = lineHeight;
            }
            else
            {
                throw new ArgumentNullException(nameof(level));
            }

            for (var i = 0; i < EnemyAmount; i++)
                _enemyList.Add(new Enemy(
                    EnemyVelocity + (float) Rnd.Next((int) (EnemyVelocityOffset * 1000000),
                        (int) (EnemyVelocityOffset * 1000000)) / 1000000, _words[i % _words.Count], this));


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


            Finish = () => Lives.Amount <= 0 || _enemyList.Count <= 0;

            Player = new Player(this);
            Line = new Line(LineHeight, this);


            // 
            // Adding entities 
            //

            AddEntity(new Background("space.jpg", this));
            _enemyList.ForEach(AddEntity);

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

        //
        // Props
        //
        public Player Player { get; }
        public Line Line { get; }

        public int EnemyAmount
        {
            get => _enemyAmount;
            private set
            {
                if (value < 1) value = 1;

                _enemyAmount = value;
            }
        }

        public float EnemyVelocity
        {
            get => _enemyVelocity;
            private set
            {
                if (value < 1) value = 1;

                _enemyVelocity = value;
            }
        }

        public float EnemyVelocityOffset
        {
            get => _enemyVelocityOffset;
            private set
            {
                if (value < 1) value = 1;

                _enemyVelocityOffset = value;
            }
        }

        public float LineHeight
        {
            get => _lineHeight;
            private set
            {
                if (value < 0) value = 0;

                if (value > Height) value = (float) Height;

                _lineHeight = value;
            }
        }

        public bool RemoveEnemy(Enemy enemy)
        {
            var result = _enemyList.Remove(enemy);
            RemoveEntity(enemy);
            return result;
        }

        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            _inputList.Input = _enemyList.Where(e => e.Y + 150 > 0).Select(e => e.Word).ToList();
            _inputList.TextInput(e.Text);
            RemoveEntity<Laser>();

            _enemyList.Where(e => e.Word.Finished).ToList().ForEach(e =>
            {
                AddEntity(new Laser(e, this));
                RemoveEnemy(e);
                Score.Amount += e.Score;
            });
        }
    }
}