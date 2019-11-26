using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class WordComponent : Component, IDrawable
    {
        private PositionComponent pc;
        private Word Word;

        public WordComponent(Word word)
        {
            Word = word;
        }

        public void Draw(DrawingContext context)
        {
            #pragma warning disable 618
            var FormattedText = new FormattedText(
                #pragma warning restore 618
                Word.Letters,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Myriad"),
                30,
                Brushes.Red);
            context.DrawText(FormattedText, new Point(pc.Position.X + 75 - (FormattedText.WidthIncludingTrailingWhitespace /2), pc.Position.Y + 150));
        }

        public override void AddedToEntity()
        {
             pc = Entity.GetComponent<PositionComponent>();
        }
    }
}
