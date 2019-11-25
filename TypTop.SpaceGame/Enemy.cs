using System;
using System.Collections.Generic;
using System.Text;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class Enemy : Entity
    {
        public Word Word { get; private set; }
        public int Speed { get; set; }
        private TransformComponent _transformComponent;

        public Enemy(int speed, Word word, Game game) : base("Enemy", game)
        {
            _transformComponent = new TransformComponent();
            AddComponent(_transformComponent);
            Word = word;
            Speed = speed;
        }
    }
}
