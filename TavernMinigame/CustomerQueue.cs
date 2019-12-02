using System;
using System.Collections.Generic;
using System.Text;
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

            SetHidden();
        }

        public void Enqueue(Customer customer)
        {
            _customerQueue.Enqueue(customer);
            SetHidden();
        }
        public Customer Dequeue() {
            Customer c = _customerQueue.Dequeue();
            SetHidden();
            return c;
        }

        private void SetHidden() => GetComponent<ImageComponent>().Hidden = Count < 1;
    }
}
