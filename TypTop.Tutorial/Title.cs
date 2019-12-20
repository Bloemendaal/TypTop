using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.Tutorial
{
    public class Title : Entity
    {
        public Title(Game minigame) : base(minigame)
        {
            AddComponent(new PositionComponent((float)Game.Width / 2, 100));
            AddComponent(new LabelComponent(new FormattedText(
                "Gebruik de volgende toetsen",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Myriad"),
                50,
                Brushes.White
            ))
            {
                Center = true
            });
        }
    }
}
