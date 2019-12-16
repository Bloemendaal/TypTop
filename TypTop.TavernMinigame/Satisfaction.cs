using System;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class Satisfaction : Entity
    {
        private readonly Customer _customer;
        private readonly TavernGame _game;
        private readonly ImageComponent _imageComponent;
        private readonly ITimer _timer;
        private int _amount;

        public Satisfaction(Customer customer, TavernGame game) : base(game)
        {
            ZIndex = 4;
            _game = game;
            _customer = customer;
            Amount = _game.StartSatisfaction;

            var mseconds = _game.GetSatisfaction(Amount);
            if (mseconds > 0)
                _timer = _game.AddTimer(() =>
                {
                    Amount--;
                    SetInterval();
                }, mseconds);

            _imageComponent =
                new ImageComponent(new BitmapImage(new Uri($@"Images/Satisfaction/satisfaction_{Amount}.png",
                    UriKind.Relative)))
                {
                    Width = 60
                };

            AddComponent(new PositionComponent
            {
                X = _customer.GetComponent<PositionComponent>().X,
                Y = 290
            });
            AddComponent(_imageComponent);
        }

        /// <summary>
        ///     Amount of satisfaction the Customer has. Value from 0 - 5 where 0 will result in the customer leaving.
        /// </summary>
        public int Amount
        {
            get => _amount;
            private set
            {
                if (value < 1)
                {
                    if (_amount > value)
                    {
                        _timer?.Dispose();
                        _customer?.RemoveEntities(_customer.Count * -10);

                        if (_game != null)
                        {
                            _game?.RemoveCustomer(_customer);
                            _game?.NextCustomer();
                            if (_game.Lives != null) _game.Lives.Amount--;
                        }
                    }

                    _amount = 0;
                    return;
                }

                if (value > 5) value = 5;

                _amount = value;

                UpdateImage();
            }
        }

        /// <summary>
        ///     Reset the interval to the current amount of satisfaction.
        /// </summary>
        private void SetInterval()
        {
            var mseconds = _game.GetSatisfaction(Amount);
            if (mseconds > 0)
                _timer.Interval = mseconds;
            else
                _timer?.Dispose();
        }

        /// <summary>
        ///     Dispose the satisfactiontimer. Do not remove a Customer or Satisfaction class from the game without disposing.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }

        /// <summary>
        ///     Update the satisfactionimage to match the amount.
        /// </summary>
        public void UpdateImage()
        {
            if (Amount > 0)
                _imageComponent?.UpdateImage(new BitmapImage(new Uri($@"Images/Satisfaction/satisfaction_{Amount}.png",
                    UriKind.Relative)));
        }
    }
}