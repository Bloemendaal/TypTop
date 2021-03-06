﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine.Components
{
    public class LivesComponent : Component, IDrawable
    {
        /// <summary>
        /// Geeft aan of de hartjes verborgen moeten zijn of niet.
        /// </summary>
        public bool Hidden { get; set; }

        private PositionComponent _positionComponent;

        /// <summary>
        /// Tekent de hartjes.
        /// </summary>
        /// <param name="context">
        /// DrawingContext.
        /// </param>
        public void Draw(DrawingContext context)
        {
            if (Entity is Lives lives)
            {
                Uri uri = new Uri(@"Images/heart.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);

                for (int i = 0; i < lives.Amount; i++)
                {
                    context.DrawImage(imgSource, new Rect
                    {
                        Width = 50,
                        Height = 50,
                        X = _positionComponent.X + i * 55,
                        Y = _positionComponent.Y
                    });
                }
            }
        }

        /// <summary>
        /// Stelt de _positionComponent voor het tekenen in.
        /// </summary>
        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }
    }
}
