using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TypTop.GameEngine;

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


        public Transition(double duration)
        {
            _duration = duration;
            _current = 0;
        }

        public TransitionState State { get; private set; } = TransitionState.FadeOut;

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
                if (_current <= 0) OnCompleted();
            }
        }

        public void Draw(DrawingContext drawingContext)
        {
            _fadeBrush ??= Brushes.Black.Clone();
            _fadeBrush.Opacity = _current.Map(0, _duration / 2, 0, 1);
            drawingContext.DrawRectangle(_fadeBrush, null, new Rect(0, 0, 1920, 1080));
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
        private readonly DispatcherTimer _timer;
        private Game _game;
        private Transition _transition;

        private DateTime previousFrame;

        static GameWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameWindow),
                new FrameworkPropertyMetadata(typeof(GameWindow)));
        }

        public GameWindow()
        {
            _timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(16), IsEnabled = false};
            previousFrame = DateTime.Now;
            _timer.Tick += TimerOnTick;
        }

        public void OnTextInput(TextCompositionEventArgs e)
        {
            _game?.OnTextInput(e);
        }

        public void OnMouseDown(Point point)
        {
            _game?.OnMouseDown(point);
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            var deltaTime = (float) Math.Min((DateTime.Now - previousFrame).TotalSeconds, 50);

            _transition?.Update(deltaTime);
            _game?.Update(deltaTime);
            InvalidateVisual();
            previousFrame = DateTime.Now;
        }

        public void Start(Game game, Transition transition)
        {
            _transition = transition;
            _transition.FadeIn += (sender, args) => { _game = game; };
            _transition.Completed += (o, e) => { _transition = null; };
            _timer.Start();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Brushes.White, null, new Rect(0, 0, 1920, 1080));
            _game?.Draw(drawingContext);
            _transition?.Draw(drawingContext);
        }

        public void Stop()
        {
        }
    }
}