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
        private Queue<Word> _words = new Queue<Word>();
        private readonly List<Lane> _lanes = new List<Lane>();
        private readonly InputList _inputList = new InputList(null) 
        { 
            FocusOnHighIndex = true
        };

        private float _highestPlatform = (float)Height - Platform.Height;

        /// <summary>
        /// Minimal distance between the platforms.
        /// </summary>
        public int MinimalDistance 
        { 
            get => _minimalDistance; 
            private set
            {
                if (value < Platform.Height + 5)
                {
                    value = Platform.Height + 5;
                }
                if (value > MaximumDistance)
                {
                    value = MaximumDistance;
                }

                _minimalDistance = value;
            } 
        }
        private int _minimalDistance = Platform.Height + 5;

        /// <summary>
        /// Maximum distance between the platforms.
        /// </summary>
        public int MaximumDistance
        {
            get => _maximumDistance;
            private set
            {
                if (value < MinimalDistance)
                {
                    value = MinimalDistance;
                }
                if (value > JumpHeight)
                {
                    value = JumpHeight;
                }

                _maximumDistance = value;
            }
        }
        private int _maximumDistance = JumpHeight;

        /// <summary>
        /// Maximum height the player can jump.
        /// </summary>
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
        public bool SwitchWords { get; private set; } = true;

        /// <summary>
        /// Save the players jump when their timing is not accurate. 
        /// </summary>
        public bool SaveJump { get; private set; } = false;


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
                        int enemyMovement when enemyMovement >= 0 && enemyMovement < Enum.GetNames(typeof(EnemyType)).Length => (EnemyType)enemyMovement,
                        _ => throw new ArgumentException("'EnemyMovement' is not valid")
                    };
                }

                // MinimalDistance
                if (level.Properties.TryGetValue("MinimalDistance", out object minimalDistanceObject) && minimalDistanceObject is int minimalDistance)
                {
                    MinimalDistance = minimalDistance;
                }

                // MaximumDistance
                if (level.Properties.TryGetValue("MaximumDistance", out object maximumDistanceObject) && maximumDistanceObject is int maximumDistance)
                {
                    MaximumDistance = maximumDistance;
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

                // SaveJump
                if (level.Properties.TryGetValue("SaveJump", out object saveJumpObject) && saveJumpObject is bool saveJump)
                {
                    SaveJump = saveJump;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(level));
            }

            // Background
            AddEntity(new Background("jumpLevelBackground.png", this));
            AddEntity(new Background("scoreline.png", this)
            {
                ZIndex = 4,
                Height = null,
                Y = -40
            });

            // Score
            Score = new Score(50, (float)Height - 50, this)
            {
                ZIndex = 10,
                Suffix = " meter hoog",
            };
            Score.UpdateText();
            AddEntity(Score);

            // Player
            _player = new Player(this);
            _player.SwitchLane(_lanes[LaneAmount / 2]);
            AddEntity(_player);

            GeneratePlatforms(true);

            TextInput += OnTextInput;
        }

        /// <summary>
        /// Generate platforms for the player to jump on
        /// </summary>
        /// <param name="init">
        /// Indicates of a starting platform should be drawn.
        /// </param>
        /// <param name="diff">
        /// The estimated distance that is gerenated. Due to random occurences, it is typically rendered lower than the set difference. Do not go lower than the jumpheight. 
        /// </param>
        public void GeneratePlatforms(bool init = false, float diff = 10000)
        {
            diff = Math.Abs(diff);

            List<float> coordinates = new List<float>();
            for (int i = 0; i < LaneAmount * diff / JumpHeight; i++)
            {
                _highestPlatform -= Rnd.Next(MinimalDistance, MaximumDistance);
                coordinates.Add(_highestPlatform);
            }

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

            if (init)
            {
                _lanes[LaneAmount / 2].AddPlatform((float)Height - Platform.Height, -1);
            }
        }

        /// <summary>
        /// Checks if platforms should be generated.
        /// </summary>
        public void CheckGeneratePlatforms()
        {
            float highest = _lanes.Select(e => e.HighestPlatform()?.Y ?? 0).OrderBy(e => e).First();
            if (highest > -Height)
            {
                GeneratePlatforms();
            }
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
                        if (_words.Count <= 0)
                        {
                            _words = new Queue<Word>(WordProvider.Serve());
                        }
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
