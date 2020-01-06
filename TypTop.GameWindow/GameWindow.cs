using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TypTop.GameEngine;
using TypTop.MinigameEngine;

namespace TypTop.GameWindow
{
    public enum TransitionState
    {
        FadeOut,
        FaceIn
    }

    public class Transition
    {
        private readonly double _duration;
        private double _current;
        private SolidColorBrush _fadeBrush;

        public TransitionState State { get; private set; } = TransitionState.FadeOut;


        public Transition(double duration)
        {
            _duration = duration;
            _current = 0;
        }

        public event EventHandler Completed;
        public event EventHandler FadeIn;

        public void Update(double deltaTime)
        {
            if (State == TransitionState.FadeOut)
            {
                _current += deltaTime;
                if (_current > _duration / 2)
                {
                    State = TransitionState.FaceIn;
                    OnFadeIn();
                }
            }
            else
            {
                _current -= deltaTime;
                if (_current <= 0)
                {
                    OnCompleted();
                }
            }
        }

        public void Draw(DrawingContext drawingContext)
        {
            _fadeBrush ??= Brushes.Black.Clone();
            _fadeBrush.Opacity = _current.Map(0, _duration / 2, 0,1);
            drawingContext.DrawRectangle(_fadeBrush, null, new Rect(0,0,1920, 1080));
        }

        protected virtual void OnCompleted()
        {
            Completed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFadeIn()
        {
            FadeIn?.Invoke(this, EventArgs.Empty);
        }
    }

    public class GameWindow : Control
    {
        private Game _game;
        private Transition _transition;

        static GameWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameWindow), new FrameworkPropertyMetadata(typeof(GameWindow)));
        }

        public GameWindow()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1), IsEnabled = false };
            previousFrame = DateTime.Now;
            _timer.Tick += TimerOnTick;
            
        }

        public void OnTextInput(TextCompositionEventArgs e)
        {
            _game?.OnTextInput(e);
        }

        public void OnMouseHover(Point point)
        {
            _game?.OnMouseHover(point);
        }

        public void OnMouseDown(Point point)
        {
            _game?.OnMouseDown(point);
        }

        private DateTime previousFrame;

        private void TimerOnTick(object sender, EventArgs e)
        {
            float deltaTime = (float)Math.Min((DateTime.Now - previousFrame).TotalSeconds, 50);

            _transition?.Update(deltaTime);
            _game?.Update(deltaTime);
            InvalidateVisual();
            previousFrame = DateTime.Now;
        }

        public void Start(Game game, Transition transition)
        {
            _transition = transition;
            _transition.FadeIn += (sender, args) =>
            {
                _game = game;
                if (_game is Minigame minigame)
                {
                    minigame.Count?.Reset();
                }
            };
            _transition.Completed += (o, e) =>
            {
                _transition = null;
            };
            _timer.Start();
        }

        private readonly DispatcherTimer _timer;

        private DateTime? previouseFpsSnapShot = null;
        private int _framesSinceFpsSnapShot = 0;
        private int fps;
        private bool showFps = false;

        protected override void OnRender(DrawingContext drawingContext)
        {
            _framesSinceFpsSnapShot++;
            if (previouseFpsSnapShot == null)
            {
                previouseFpsSnapShot = DateTime.Now;
            }

            if (DateTime.Now - previouseFpsSnapShot > TimeSpan.FromSeconds(1))
            {
                previouseFpsSnapShot = DateTime.Now;
                fps = _framesSinceFpsSnapShot;
                _framesSinceFpsSnapShot = 0;
            }


            _game?.Draw(drawingContext);
            _transition?.Draw(drawingContext);


            if (showFps)
            {
                var formattedText = new FormattedText(
#pragma warning restore 618
                    fps.ToString(),
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface("Veranda"),
                    25,
                    Brushes.Black);

                drawingContext.DrawText(formattedText, new Point(50, 50));
            }
          
        }

        public void Stop()
        {
            
        }
    }
}
