using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.JumpMinigame
{
    public class JumpGame : Minigame
    {
        private readonly Player _player;
        private readonly List<Lane> _lanes = new List<Lane>();
        private readonly Queue<Word> _words = new Queue<Word>();
        private readonly InputList _inputList = new InputList(null) 
        { 
            FocusOnHighIndex = true
        };

        public const int JumpHeight = 400;

        /// <summary>
        /// Amount of lanes that should be used for this level. Minimum amount of unique words must be equal to this value.
        /// </summary>
        public int LaneAmount
        {
            get => _laneAmount;
            private set
            {
                if (value < 2)
                {
                    value = 2;
                }

                if (value > 10)
                {
                    value = 10;
                }

                _laneAmount = value;

                if (_lanes.Count > 0)
                {
                    foreach (var lane in _lanes)
                    {
                        RemoveEntity(lane);
                    }

                    _lanes.Clear();
                }
                for (int i = 0; i < _laneAmount; i++)
                {
                    Lane l = new Lane(i, this)
                    {
                        Word = _words.Dequeue()
                    };
                    _lanes.Add(l);
                    AddEntity(l);
                }
            }
        }
        private int _laneAmount;

        /// <summary>
        /// Width that the lanes should have.
        /// </summary>
        public float LaneWidth => (float)Width / LaneAmount;

        /// <summary>
        /// Minimal height of an enemy to spawn. Default is after one screen height.
        /// </summary>
        public double EnemySpawnHeight
        {
            get => _enemySpawnHeight;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _enemySpawnHeight = value;
            }
        }
        private double _enemySpawnHeight = Height;

        /// <summary>
        /// Amount of enemies to spawn per 100 platforms.
        /// </summary>
        public double EnemyAmount
        {
            get => _enemyAmount;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _enemyAmount = value;
            }
        }
        private double _enemyAmount = 0;

        /// <summary>
        /// All possible ways an enemy can move.
        /// </summary>
        public enum EnemyType
        {
            Static,
            Horizontal,
            Vertical,
            Moving,
            All
        }

        /// <summary>
        /// Set movement of the enemies.
        /// </summary>
        public EnemyType EnemyMovement { get; private set; } = EnemyType.All;

        /// <summary>
        /// Amount of jumps the player can make on a platform until it breaks. 0 will instantly break.
        /// </summary>
        public int PlatformBreakAmount
        {
            get => _platformBreakAmount;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _platformBreakAmount = value;
            }
        }
        private int _platformBreakAmount;

        /// <summary>
        /// Offset when generating random Platform break amounts.
        /// </summary>
        public int PlatformBreakOffset
        {
            get => _platformBreakOffset;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _platformBreakOffset = value;
            }
        }
        private int _platformBreakOffset;

        /// <summary>
        /// Percentage solid platforms. Default is solid platforms only.
        /// </summary>
        public double PlatformSolidRatio
        {
            get => _platformSolidRatio;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > 1)
                {
                    value = 1;
                }

                _platformSolidRatio = value;
            }
        }
        private double _platformSolidRatio = 1;

        /// <summary>
        /// Switch words when the word was typed correctly.
        /// </summary>
        public bool SwitchWords = true;


        public JumpGame(Level level) : base(level)
        {
            if (level != null && level.Properties != null)
            {
                // Words
                _words = new Queue<Word>(WordProvider.Serve());

                // LaneAmount
                LaneAmount = level.Properties.TryGetValue("LaneAmount", out object laneAmountObject) && laneAmountObject is int laneAmount ? laneAmount : 5;

                if (_words.Count < LaneAmount)
                {
                    throw new ArgumentException("'Words' amount is less than the amount of lanes");
                }

                // EnemySpawnHeight
                if (level.Properties.TryGetValue("EnemySpawnHeight", out object enemySpawnHeightObject) && enemySpawnHeightObject is double enemySpawnHeight)
                {
                    EnemySpawnHeight = enemySpawnHeight;
                }

                // EnemyAmount
                if (level.Properties.TryGetValue("EnemyAmount", out object enemyAmountObject) && enemyAmountObject is int enemyAmount)
                {
                    EnemyAmount = enemyAmount;
                }

                // EnemyMovement
                if (level.Properties.TryGetValue("EnemyMovement", out object enemyMovementObject))
                {
                    EnemyMovement = enemyMovementObject switch
                    {
                        EnemyType enemyMovement => enemyMovement,
                        int enemyMovement when enemyMovement >= 0 && enemyMovement < Enum.GetNames(typeof(EnemyType)).Length => (EnemyType) enemyMovement,
                        _ => throw new ArgumentException("'EnemyMovement' is not valid")
                    };
                }

                // PlatformBreakAmount
                if (level.Properties.TryGetValue("PlatformBreakAmount", out object platformBreakAmountObject) && platformBreakAmountObject is int platformBreakAmount)
                {
                    PlatformBreakAmount = platformBreakAmount;
                }

                // PlatformBreakOffset
                if (level.Properties.TryGetValue("PlatformBreakOffset", out object platformBreakOffsetObject) && platformBreakOffsetObject is int platformBreakOffset)
                {
                    PlatformBreakOffset = platformBreakOffset;
                }

                // PlatformSolidRatio
                if (level.Properties.TryGetValue("PlatformSolidRatio", out object platformSolidRatioObject) && platformSolidRatioObject is double platformSolidRatio)
                {
                    PlatformSolidRatio = platformSolidRatio;
                }

                // SwitchWords
                if (level.Properties.TryGetValue("SwitchWords", out object switchWordsObject) && switchWordsObject is bool switchWords)
                {
                    SwitchWords = switchWords;
                }

                // Seconds
                if (level.Properties.TryGetValue("Seconds", out object secondsObject) && secondsObject is int seconds)
                {
                    Count = new Count(seconds, 0, 0, this);
                    Finish = () => _player.Y > Height || Count.Seconds <= 0;
                }
                else
                {
                    Finish = () => _player.Y > Height;
                }

                // Lives
                if (EnemyAmount > 0 && level.Properties.TryGetValue("Lives", out object livesObject) && livesObject is int lives)
                {
                    Lives = new Lives(0, 0, this)
                    {
                        Amount = lives,
                        ZIndex = 10
                    };

                    AddEntity(Lives);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(level));
            }

            AddEntity(new Background("jumpLevelBackground.png", this));
            AddEntity(new Background("scoreline.png", this)
            {
                ZIndex = 4,
                Height = null,
                Y = -20
            });

            _player = new Player(this);
            _player.SwitchLane(_lanes[LaneAmount / 2]);
            Score = new Score(0, 0, this);

            AddEntity(_player);
            GeneratePlatforms((float)Height, solidBase: true);

            TextInput += OnTextInput;
        }


        public void GeneratePlatforms(float start = 0, float diff = 10000, bool solidBase = false)
        {
            diff = Math.Abs(diff);

            List<float> coordinates = new List<float>();
            for (int i = 0; i < LaneAmount * diff / JumpHeight; i++)
            {
                coordinates.Add(Rnd.Next((int)((start - diff) * 1000), (int)(start * 1000)) / 1000f);
            }

            coordinates.Add(start - Platform.Height);
            coordinates.Sort();
            coordinates.Reverse();

            for (int i = 0; i < coordinates.Count - 1; i++)
            {
                float tdiff = Math.Abs(coordinates[i + 1] - coordinates[i]);
                if (tdiff > JumpHeight)
                {
                    coordinates[i + 1] -= tdiff;
                }
            }

            coordinates.RemoveAt(0);


            // Shuffle
            List<float> randomList = new List<float>();
            while (coordinates.Count > 0)
            {
                int randomIndex = Rnd.Next(0, coordinates.Count);
                randomList.Add(coordinates[randomIndex]);
                coordinates.RemoveAt(randomIndex);
            }

            int laneIndex = 0;
            foreach (float coordinate in randomList)
            {
                _lanes[laneIndex % LaneAmount].AddPlatform(coordinate);
                laneIndex++;
            }

            _lanes[LaneAmount / 2].AddPlatform(start - Platform.Height, solidBase ? -1 : new int?());
        }

        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            _inputList.Input = _lanes.Where(l => !l.Equals(_player.Lane)).Select(l => l.Word).ToList();
            _inputList.TextInput(e.Text);

            foreach (Lane lois in _lanes)
            {
                if (lois.Word.Finished)
                {
                    if (SwitchWords)
                    {
                        lois.Word = _words.Dequeue();
                    }
                    else
                    {
                        lois.Word.Finished = false;
                        lois.Word.Index = 0;
                        lois.Word.Correct = null;
                    }

                    _player.SwitchLane(lois);
                    break;
                }
            }
        }
    }
}
