using System;
using System.Collections.Generic;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.JumpMinigame
{
    public class JumpGame : Minigame
    {
        private readonly Player _player;
        private List<Lane> _lanes = new List<Lane>();

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
                    _lanes = new List<Lane>();
                }
                for (int i = 0; i < _laneAmount; i++)
                {
                    _lanes.Add(new Lane(i, this));
                }
            }
        }
        private int _laneAmount = 5;

        /// <summary>
        /// Width that the lanes should have.
        /// </summary>
        public float LaneWidth => LaneAmount / (float)Height;

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


        public JumpGame(Level level) : base(level)
        {
            _player = new Player(this);
            Score = new Score(0, 0, this);
            Lives = new Lives(0, 0, this);
            Count = new Count(0, 0, 0, this);
        }
    }
}
