﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.Logic;

namespace TypTop.GameEngine.Components
{
    /// <summary>Used to render text on entity</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    /// <seealso cref="TypTop.GameEngine.IDrawable" />
    public class LabelComponent : Component, IDrawable
    {
        private PositionComponent _positionComponent;

        public float X => _positionComponent.X + TransformX - (Center ? (float)Text.WidthIncludingTrailingWhitespace / 2 : 0);
        public float Y => _positionComponent.Y + TransformY - (Middle ? (float)Text.Height / 2 : 0);

        /// <summary>  horizontal offset</summary>
        public float TransformX = 0;
        /// <summary>  vertical offset</summary>
        public float TransformY = 0;

        /// <summary>Center rendering of the label</summary>
        public bool Center = false;

        /// <summary>  Vertical centration</summary>
        public bool Middle = false;

        /// <summary>  With of te label</summary>
        /// <value>The width.</value>
        public double Width => Text?.WidthIncludingTrailingWhitespace ?? 0;
        
        /// <summary>  Height of the text</summary>
        /// <value>The height.</value>
        public double Height => Text?.Height ?? 0;

        public bool Hidden { get; set; }

        /// <summary>The text
        /// to render</summary>
        public FormattedText Text;

        public LabelComponent(FormattedText text = null)
        {
            Text = text;
        }

        public void Draw(DrawingContext context)
        {
            if (Text != null)
            {
                if (Y + Text.Height < 0 ||
                    Y > Game.Height ||
                    X + Text.WidthIncludingTrailingWhitespace < 0 ||
                    X > Game.Width
                ) return;
                context.DrawText(Text, new Point(X, Y));
            }
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
            if (_positionComponent == null) throw new Exception("PositionComponent is required to draw a label.");
        }
    }
}
