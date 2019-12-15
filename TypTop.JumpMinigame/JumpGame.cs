using System;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.JumpMinigame
{
    public class JumpGame : Minigame
    {
        public JumpGame(Level level) : base(level)
        {
            AddEntity(new Player(this));
        }
    }
}
