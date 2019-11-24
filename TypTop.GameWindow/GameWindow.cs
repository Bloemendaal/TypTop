﻿using System;
using System.Collections.Generic;
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
using BasicGameEngine;

namespace TypTop.GameWindow
{
    public class GameWindow : Control
    {
        private Game _game;

        static GameWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameWindow), new FrameworkPropertyMetadata(typeof(GameWindow)));
        }

        public GameWindow()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16), IsEnabled = false};
            previousFrame = DateTime.Now;
            _timer.Tick += TimerOnTick;
        }

        private DateTime previousFrame;

        private void TimerOnTick(object? sender, EventArgs e)
        {
            float deltaTime = (float) Math.Min((DateTime.Now - previousFrame).TotalSeconds, 50);

            if (_game == null)
            {
                return;
            }

            _game.Width = Width;
            _game.Height = Height;

            _game.Update(deltaTime);
            InvalidateVisual();
            previousFrame = DateTime.Now;
        }

        public void Start(Game game)
        {
            _game = game;
            _timer.Start();
        }

        private readonly DispatcherTimer _timer;

        protected override void OnRender(DrawingContext drawingContext)
        {
            _game.Draw(drawingContext);
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
