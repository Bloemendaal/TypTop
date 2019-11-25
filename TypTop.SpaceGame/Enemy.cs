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
        private PositionComponent _positionComponent;
        private VelocityComponent _velocityComponent;

        public Enemy(int speed, Word word, Game game) : base("Enemy", game)
        {
            _positionComponent = new PositionComponent();
            _velocityComponent = new VelocityComponent();
            AddComponent(_positionComponent);
            AddComponent(_velocityComponent);
            AddComponent(
                new ImageComponent(new BitmapImage(new Uri(@"Images/enemy.png", UriKind.Relative))));
            Word = word;
            Speed = speed;
        }
    }
}
