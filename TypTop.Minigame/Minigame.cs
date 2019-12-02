using System;
using TypTop.GameEngine;

namespace TypTop.MinigameEngine
{
    public class Minigame : Game
    {
        public int? TimeLimit
        {
            get => _timeLimit;
            set
            {
                if (value != null && value < 0)
                {
                    value = 0;
                }

                _timeLimit = value;
            }
        }
        private int? _timeLimit;

        public int? Stars
        {
            get => _stars;
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > 3)
                    {
                        value = 3;
                    }
                }

                _stars = value;
            }
        }
        private int? _stars;

        public Score Score;
        public Lives Lives;

    }
}
