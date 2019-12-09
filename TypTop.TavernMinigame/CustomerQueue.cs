using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.TavernMinigame
{
    public class CustomerQueue : Entity
    {
        public int Count => _customerQueue.Count;
        private readonly Queue<Customer> _customerQueue = new Queue<Customer>();

        public CustomerQueue(Game game) : base(game)
        {
            ZIndex = 5;

            AddComponent(new PositionComponent(20, (float)Game.Height/2 - 100));
            AddComponent(new ImageComponent(new BitmapImage(new Uri($@"Images/queue.png", UriKind.Relative)))
            {
                Height = 200
            });
            AddComponent(new LabelComponent()
            {
                TransformX = 100,
                TransformY = 100,
                Middle = true
            });

            UpdateCount();
        }

        public void Enqueue(Customer customer)
        {
            _customerQueue.Enqueue(customer);
            UpdateCount();
        }
        public Customer Dequeue() {
            Customer c = _customerQueue.Dequeue();
            UpdateCount();
            return c;
        }

        private void UpdateCount()
        {
            bool hidden = Count < 1;
            GetComponent<ImageComponent>().Hidden = hidden;
            GetComponent<LabelComponent>().Hidden = hidden;
            GetComponent<LabelComponent>().Text = new FormattedText(
                Count.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                ((TavernGame)Minigame).DefaultTypeface,
                80,
                new SolidColorBrush(new Color()
                {
                    R = 58,
                    G = 37, 
                    B = 21, 
                    A = 255
                })
           );
        }
    }
}
