using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine.Components
{
    public class LivesComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        /// <summary>
        ///     Geeft aan of de hartjes verborgen moeten zijn of niet.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        ///     Tekent de hartjes.
        /// </summary>
        /// <param name="context">
        ///     DrawingContext.
        /// </param>
        public void Draw(DrawingContext context)
        {
            if (Entity is Lives lives)
            {
                var uri = new Uri(@"Images/heart.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);

                for (var i = 0; i < lives.Amount; i++)
                    context.DrawImage(imgSource, new Rect
                    {
                        Width = 50,
                        Height = 50,
                        X = _positionComponent.X + i * 55,
                        Y = _positionComponent.Y
                    });
            }
        }

        /// <summary>
        ///     Stelt de _positionComponent voor het tekenen in.
        /// </summary>
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}