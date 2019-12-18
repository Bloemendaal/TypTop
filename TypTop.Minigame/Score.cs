using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using System.Windows.Media;
using System.Globalization;
using System.Windows;

namespace TypTop.MinigameEngine
{
    public class Score : Entity
    {
        /// <summary>
        /// Roept de method DisplayDifference met het verschil zodra de score bijgewerkt wordt.
        /// </summary>
        public int Amount
        {
            get => _amount;
            set
            {
                int diff = value - _amount;
                _amount = value;
                DisplayDifference(diff);
            }
        }
        private int _amount = 0;

        /// <summary>
        /// Het aantal dat moet toegevoegd worden aan de x van een FloatingScore. Standaardwaarde is 0.
        /// </summary>
        public float LabelTransformX = 0;

        /// <summary>
        /// Het aantal dat moet toegevoegd worden aan de y van een FloatingScore. Standaardwaarde is 0.
        /// </summary>
        public float LabelTransformY = 0;

        /// <summary>
        /// Geeft de X van het label dat gebruikt wordt om de score weer te geven.
        /// </summary>
        public float LabelX => _labelComponent.X;

        /// <summary>
        /// Geeft de Y van het label dat gebruikt wordt om de score weer te geven.
        /// </summary>
        public float LabelY => _labelComponent.Y;

        /// <summary>
        /// De mogelijke richtingen waarop een FloatingScore kan zweven zodra er een verandering in de score optreedt.
        /// </summary>
        public enum FloatDirection { None, Up, Down }

        /// <summary>
        /// De richting waarop een FloatingScore zal zweven zodra er een verandering in de score optreedt. Standaardwaarde is None, er zal geen FloatingScore weergegeven worden.
        /// </summary>
        public FloatDirection Direction = FloatDirection.None;

        /// <summary>
        /// Het lettertype dat Score moet gebruiken. Standaardwaarde is Myriad.
        /// </summary>
        public Typeface Typeface = new Typeface("Myriad");

        /// <summary>
        /// De kleur die de cijfers van Score moet gebruiken. Standaardwaarde is zwart.
        /// </summary>
        public SolidColorBrush Color = Brushes.Black;

        /// <summary>
        /// De kleur die de FloatingScore moet gebruiken als er een negatieve verandering in de score optreedt. Standaardwaarde is donkerrood.
        /// </summary>
        public SolidColorBrush Negative = Brushes.DarkRed;

        /// <summary>
        /// De kleur die de FloatingScore moet gebruiken als er een positieve verandering in de score optreedt. Standaardwaarde is donkergroen.
        /// </summary>
        public SolidColorBrush Positive = Brushes.DarkGreen;

        /// <summary>
        /// De grootte van de cijfers van Score en FloatingScore. Standaardwaarde is 30.
        /// </summary>
        public int FontSize = 30;

        private readonly LabelComponent _labelComponent = new LabelComponent();

        /// <summary>
        /// Een prefix die voor de score gezet moet worden. Standaardwaarde is NULL.
        /// </summary>
        public string Prefix = null;

        /// <summary>
        /// Een suffix die voor de score gezet moet worden. Standaardwaarde is NULL.
        /// </summary>
        public string Suffix = null;

        /// <summary>
        /// Match de positie van de FloatingScore met de beide rechter uiteindes van de Score en FloatingScore. Standaardwaarde is false.
        /// </summary>
        public bool Right = false;

        /// <summary>
        /// Geeft aan of de FloatingScore de + / - voor het verschil moet weergeven. Standaardwaarde is true.
        /// </summary>
        public bool ShowOperator = true;

        public Score(Vector2 position, Game game) : base(game)
        {
            AddComponent(new PositionComponent(position));
            AddComponent(_labelComponent);
        }
        public Score(float x, float y, Game game) : this(new Vector2(x, y), game) { }

        /// <summary>
        /// Werkt de score bij inclusief de styling.
        /// </summary>
        public void UpdateText()
        {
            _labelComponent.Text = new FormattedText(
                $"{Prefix ?? ""}{Amount}{Suffix ?? ""}",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                Typeface,
                FontSize,
                Color
            );
        }

        /// <summary>
        /// Roept eerst UpdateText() aan en maakt vervolgens een nieuwe instantie aan van FloatingScore wanneer het verschil niet 0 is en er een Direction ingesteld is. Kan alleen opgeroepen worden door de score bij te werken via Amount.
        /// </summary>
        /// <param name="diff">
        /// Verschil dat weergegeven moet worden.
        /// </param>
        private void DisplayDifference(int diff)
        {
            UpdateText();

            if (diff != 0 && Direction != FloatDirection.None)
            {
                FloatingScore fScore = new FloatingScore(diff, this)
                {
                    ZIndex = ZIndex + 1,
                    LabelTransformX = LabelTransformX,
                    LabelTransformY = LabelTransformY,
                    ShowOperator = ShowOperator
                };

                if (Right)
                {
                    fScore.LabelTransformX += (float)_labelComponent.Width - (float)fScore.GetComponent<LabelComponent>().Width;
                }

                Game.AddEntity(fScore);
            }
        }
    }
}
