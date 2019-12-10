using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class Satisfaction : Entity
    {
        public int Amount 
        {
            get => _amount;
            private set
            {
                if (value < 1)
                {
                    _customer.RemoveEntities();
                    _timer?.Dispose();
                    return;
                }

                if (value > 5)
                {
                    value = 5;
                }

                _amount = value;

                UpdateImage();
            }
        }
        private int _amount;

        private readonly Customer _customer;
        private readonly ITimer _timer;
        private readonly TavernGame _game;
        private readonly ImageComponent _imageComponent;

        public Satisfaction(Customer customer, TavernGame game) : base(game)
        {
            ZIndex = 4;
            _game = game;
            _customer = customer;
            Amount = _game.StartSatisfaction;

            int mseconds = _game.GetSatisfaction(Amount);
            if (mseconds > 0)
            {
                _timer = _game.AddTimer(() =>
                {
                    Amount--;
                    SetInterval();
                }, mseconds);
            }

            _imageComponent = new ImageComponent(new BitmapImage(new Uri($@"Images/Satisfaction/satisfaction_{Amount}.png", UriKind.Relative)))
            {
                Width = 100
            };

            AddComponent(new PositionComponent()
            {
                X = _customer.GetComponent<PositionComponent>().X,
                Y = 275
            });
            AddComponent(_imageComponent);
        }

        private void SetInterval()
        {
            int mseconds = _game.GetSatisfaction(Amount);
            if (mseconds > 0)
            {
                _timer.Interval = mseconds;
            }
            else
            {
                _timer.Dispose();
            }
        }

        public void UpdateImage()
        {
            _imageComponent?.UpdateImage(new BitmapImage(new Uri($@"Images/Satisfaction/satisfaction_{Amount}.png", UriKind.Relative)));
        }
    }
}
