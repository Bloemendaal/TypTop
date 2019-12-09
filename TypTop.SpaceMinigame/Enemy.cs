using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Enemy : Entity
    {
        //
        // Props
        //
        public Word Word { get; private set; }
        public int Speed { get; private set; }
        public int Score { get; private set; }
        
        //
        // Vars
        //
        public float Y => _positionComponent.Y;
        private readonly SpaceMinigame _minigame;
        private readonly PositionComponent _positionComponent;

        public Enemy(int speed, int amountOfWords, Word word, Game game) : base(game)
        {
            ZIndex = 2;

            _positionComponent = new PositionComponent(
                game.Rnd.Next(150, 1720), 
                game.Rnd.Next(0, amountOfWords * 150) * -1);
            AddComponent(_positionComponent);
            AddComponent(new VelocityComponent()
            {
                Velocity = new Vector2(0, speed)
            });
            AddComponent(new WordComponent(word, Brushes.Red, Brushes.DarkRed)
            {
                TransformX = 75,
                TransformY = 150,
                Center = true
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/enemy.png", UriKind.Relative)))
            {
                Width = 150
            });

            Word = word;
            Speed = speed;
            Score = Word.Letters.Length * Speed;
            _minigame = (SpaceMinigame)game;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (Y > _minigame.Line.GetComponent<PositionComponent>().Y)
            {
                _minigame.EnemyList.Remove(this);
                _minigame.RemoveEntity(this);
                _minigame.Lives.Amount--;
            }
        }
    }
}
