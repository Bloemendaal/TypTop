using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using TypTop.Logic;
using System.Windows.Input;

namespace TavernMinigame
{
    public class TavernGame : Game
    {
        public int TileAmount
        {
            get => _tiles.Count;
            set {
                if (value < 1)
                {
                    value = 1;
                }

                int max = Enum.GetNames(typeof(Order.OrderType)).Length;
                if (value > max)
                {
                    value = max;
                }

                List<int> indexes = new List<int>();
                for (int i = 0; i < value; i++)
                {
                    int index = Rnd.Next(0, max - i);
                    while (indexes.Contains(index))
                    {
                        index++;
                        if (index == value)
                        {
                            index = 0;
                        }
                    }

                    indexes.Add(index);
                }

                RemoveEntity<Tile>();
                RemoveEntity<Order>();
                _tiles = new List<Tile>();
                for (int i = 0; i < indexes.Count; i++)
                {
                    Tile t = new Tile((Order.OrderType)indexes[i], (float)Width - ((i + 1) * ((float)Tile.Width + 20)), this)
                    {
                        Word = _words.Dequeue()
                    };

                    _tiles.Add(t);
                    AddEntity(t);
                    AddEntity(t.Order);
                }
            }
        }
        private List<Tile> _tiles;
        private readonly Queue<Word> _words;

        private readonly InputList _inputList = new InputList(null)
        {
            FocusOnHighIndex = true
        };

        public enum PlayVariant { Default, TimeBased, BossBattle }
        public PlayVariant Variant = PlayVariant.Default;

        public bool AngryCustomers = false;

        public int MaxCustomers
        {
            get => _maxCustomers;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _maxCustomers = value;
            }
        }
        private int _maxCustomers = 3;

        private readonly List<Customer> _customers = new List<Customer>();
        private readonly Queue<Customer> _customerQueue = new Queue<Customer>();

        private readonly ITimer _timer;


        public TavernGame(int tileAmount, List<Word> words)
        {
            _words = new Queue<Word>(words);

            AddEntity(new Background(this));
            TileAmount = tileAmount;

            TextInput += OnTextInput;

            _timer = AddTimer(() =>
            {
                AddCustomer(new Customer(this));
                _timer.Interval = Rnd.Next(3000, 5000);
            }, Rnd.Next(3000, 5000));
        }
        

        public void AddCustomer(Customer customer)
        {
            if (_customers.Count >= MaxCustomers)
            {
                _customerQueue.Enqueue(customer);
            }
            else
            {
                _customers.Add(customer);
                customer.UpdatePosition(CustomerIndex(customer));
                customer.AddEntities();
                UpdateWordlist();
            }
        }
        public bool NextCustomer()
        {
            if (_customerQueue.Count > 0 && _customers.Count < MaxCustomers)
            {
                Customer next = _customerQueue.Dequeue();
                _customers.Add(next);
                next.UpdatePosition(CustomerIndex(next));
                next.AddEntities();
                UpdateWordlist();
                return true;
            }

            return false;
        }
        public bool RemoveCustomer(Customer customer) {
            bool result = _customers.Remove(customer);
            if (result && _customers.Count > 0)
            {
                _customers.ForEach(c => c.UpdatePosition(CustomerIndex(c)));
            }
            UpdateWordlist();
            return result;
        }
        public int CustomerIndex(Customer customer) => _customers.IndexOf(customer);


        public void UpdateWordlist()
        {
            _inputList.Input = _tiles.Where(t => _customers.Any(c => c.HasOrder(t.Order))).Select(t => t.Word).ToList();
        }


        public List<Order> GetOrder(int amount)
        {
            List<Order> result = new List<Order>();
            for (int i = 0; i < amount; i++)
            {
                Order o = new Order(_tiles[Rnd.Next(0, TileAmount)].Order.Type, this);

                o.GetComponent<ImageComponent>().Width = 190;
                if (o.GetComponent<ImageComponent>().Height > 190)
                {
                    o.GetComponent<ImageComponent>().Height = 190;
                    o.GetComponent<ImageComponent>().Width = null;
                }

                result.Add(o);
            }

            return result;
        }


        private void OnTextInput(object sender, TextCompositionEventArgs e)
        {
            _inputList.TextInput(e.Text);
            _tiles.ForEach(c =>
            {
                if (c.Word.Finished)
                {
                    c.Word = _words.Dequeue();
                    foreach (Customer customer in _customers)
                    {
                        if (customer.RemoveOrder(c.Order))
                        {
                            if (customer.Count == 0)
                            {
                                customer.RemoveEntities();
                                RemoveCustomer(customer);
                                NextCustomer();
                            }
                            break;
                        }
                    }

                    UpdateWordlist();
                }
            });
        }
    }
}
