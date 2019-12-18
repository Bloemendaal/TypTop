using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class Count : Entity
    {
        private readonly DateTime? _dateTime = null;
        private readonly DateTime _startTime;

        private readonly LabelComponent _labelComponent = new LabelComponent();
        private readonly PositionComponent _positionComponent;

        /// <summary>
        /// Geeft aan of in het visuele gedeelte uren weergegeven moeten worden. Standaardwaarde is false.
        /// </summary>
        public bool ShowHours = false;

        /// <summary>
        /// Geeft aan of de countdown klaar is met aftellen. Standaardwaarde is false. Werkt niet wanneer de Count gebruikt wordt als stopwatch.
        /// </summary>
        public bool Finished { get; private set; }

        /// <summary>
        /// Get en set de X waarde van de positioncomponent van Count.
        /// </summary>
        public float X
        {
            get => _positionComponent.X;
            set => _positionComponent.X = value;
        }

        /// <summary>
        /// Get en set de Y waarde van de positioncomponent van Count.
        /// </summary>
        public float Y
        {
            get => _positionComponent.Y;
            set => _positionComponent.Y = value;
        }

        /// <summary>
        /// Het lettertype dat Count moet gebruiken. Standaardwaarde is Myriad.
        /// </summary>
        public Typeface Typeface = new Typeface("Myriad");

        /// <summary>
        /// De kleur die de cijfers van Count moet gebruiken. Standaardwaarde is zwart.
        /// </summary>
        public SolidColorBrush Color = Brushes.Black;

        /// <summary>
        /// De kleur die de cijfers van Count moet gebruiken als de countdown klaar is met aftellen. Standaardwaarde is donkerrood.
        /// </summary>
        public SolidColorBrush FinishedColor = Brushes.DarkRed;

        /// <summary>
        /// De grootte van de cijfers van Count. Standaardwaarde is 30.
        /// </summary>
        public int FontSize = 30;

        /// <summary>
        /// Een prefix die voor de timer gezet moet worden. Standaardwaarde is NULL.
        /// </summary>
        public string Prefix = null;

        /// <summary>
        /// Een suffix die voor de timer gezet moet worden. Standaardwaarde is NULL.
        /// </summary>
        public string Suffix = null;

        /// <summary>
        /// Het aantal seconden dat de countdown nog moet voordat deze klaar is met aftellen. In het geval van een stopwatch gelijk aan SecondsSpent.
        /// </summary>
        public int Seconds => (int)(_dateTime == null ? DateTime.Now.Subtract(_startTime) : ((DateTime)_dateTime).Subtract(DateTime.Now)).TotalSeconds;
     
        /// <summary>
        /// Het aantal seconden dat verstreken is sinds de timer ingesteld is.
        /// </summary>
        public int SecondsSpent => (int)DateTime.Now.Subtract(_startTime).TotalSeconds;

        public Count(int seconds, Vector2 position, Game game) : base(game)
        {
            _startTime = DateTime.Now;
            if (seconds != 0) { 
                _dateTime = _startTime.AddSeconds(seconds);
            }

            _positionComponent = new PositionComponent(position);

            AddComponent(_positionComponent);
            AddComponent(_labelComponent);
        }
        public Count(int seconds, float x, float y, Game game) : this(seconds, new Vector2(x, y), game) { }

        /// <summary>
        /// Werkt de timer bij inclusief eventuele verandering in de style. Zet ook wanneer de countdown klaar is met aftellen.
        /// </summary>
        /// <param name="deltaTime">
        /// Verschil in tijd.
        /// </param>
        public override void Update(float deltaTime)
        {
            var dt = _dateTime ?? _startTime;
            TimeSpan timeSpan = _dateTime != null ^ Finished ? dt.Subtract(DateTime.Now) : DateTime.Now.Subtract(dt);

            StringBuilder sb = new StringBuilder();

            if (Prefix != null)
            {
                sb.Append(Prefix);
            }
            if (Finished)
            {
                sb.Append("-");
            }
            if (ShowHours)
            {
                sb.Append($"{("0" + (int)timeSpan.Hours).Substring((int)timeSpan.Hours < 10 ? 0 : 1, 2)}:");
            }
            sb.Append($"{("0" + (int)timeSpan.Minutes).Substring((int)timeSpan.Minutes < 10 ? 0 : 1, 2)}:{("0" + (int)timeSpan.Seconds).Substring((int)timeSpan.Seconds < 10 ? 0 : 1, 2)}");
            if (Suffix != null)
            {
                sb.Append(Suffix);
            }

            _labelComponent.Text = new FormattedText(
                sb.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                Typeface,
                FontSize,
                Finished ? FinishedColor : Color
            );

            if (_dateTime != null && (int)timeSpan.TotalSeconds < 0)
            {
                Finished = true;
            }

            base.Update(deltaTime);
        }
    }
}
