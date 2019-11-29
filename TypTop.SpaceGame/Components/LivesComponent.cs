using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class LivesComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;
        private readonly Player _player;
        public LivesComponent(SpaceGame game)
        {
            _player = game.Player;
        }

        public void Draw(DrawingContext context)
        {
            for (int i = 0; i < _player.Lives; i++)
            {
                Rect myRect1 = new Rect();
                
                myRect1.Width = 50;
                myRect1.Height = 50;

                myRect1.X = (_positionComponent.X + 50) + (i * myRect1.Width + 25);
                myRect1.Y = _positionComponent.Y + 15;

                Uri uri = new Uri("./Images/heart.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);

                context.DrawImage(imgSource, myRect1);
            }
            
        }
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
