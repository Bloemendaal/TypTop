***REMOVED***
***REMOVED***
using System.Globalization;
using System.Net.Mime;
***REMOVED***
using System.Windows;
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
***REMOVED***
    public class WordComponent : Component, IDrawable
    ***REMOVED***
        private PositionComponent pc;
        private Word Word;

        public WordComponent(Word word)
        ***REMOVED***
            Word = word;
    ***REMOVED***

        public void Draw(DrawingContext context)
        ***REMOVED***
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
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
             pc = Entity.GetComponent<PositionComponent>();
    ***REMOVED***
***REMOVED***
***REMOVED***
