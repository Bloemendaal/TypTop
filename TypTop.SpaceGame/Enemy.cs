using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
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
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"enemy.png", UriKind.Relative))));
            Word = word;
            Speed = speed;
        }
    }
}
