using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Windows.Input;
using TypTop.Logic;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.MinigameEngine;
using System.Windows.Media;
using TypTop.MinigameEngine.WinConditions;

namespace TypTop.TavernMinigame
{
    public class TavernGame : Minigame
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

        public bool AngryCustomers { get; private set; } = false;

        private readonly List<Customer> _customers = new List<Customer>();
        private readonly CustomerQueue _customerQueue;

        private readonly ITimer _timer;

        public readonly Typeface DefaultTypeface = new Typeface("MV Boli");


        public TavernGame(WinCondition winCondition, List<Word> words, int secondsOrQueue = 0, int tileAmount = 3, int lives = 3) : base(winCondition)
        {
            _words = new Queue<Word>(words);

            AddEntity(new Background("tavern.png", this));
            TileAmount = tileAmount;

            _customerQueue = new CustomerQueue(this);
            AddEntity(_customerQueue);

            TextInput += OnTextInput;

            int countOffset = 360;

            if (winCondition is ScoreCondition)
            {
                Finish = delegate ()
                {
                    return Count.Seconds < 0;
                };
            }

            if (winCondition is LifeCondition)
            {
                AngryCustomers = true;
                Lives = new Lives(550, (float)Height - 60, this)
                {
                    Amount = lives,
                    ZIndex = 6
                };

                Finish = delegate ()
                {
                    return Lives.Amount <= 0 || Count.Seconds < 0;
                };

                AddEntity(Lives);
            }

            if (winCondition is TimeCondition)
            {
                for (int i = 0; i < secondsOrQueue; i++)
                {
                    AddCustomer(new Customer(this));
                }

                Count = new Count(0, countOffset, (float)Height - 50, this);

                Finish = delegate ()
                {
                    return _customerQueue.Count <= 0;
                };
            }
            else
            {
                _timer = AddTimer(() =>
                {
                    AddCustomer(new Customer(this));
                    _timer.Interval = Rnd.Next(3000, 5000) * (1 + _customerQueue.Count / 10);
                }, Rnd.Next(3000, 5000));

                Count = new Count(secondsOrQueue, countOffset, (float)Height - 50, this);
            }

            Count.Typeface = DefaultTypeface;
            Count.ZIndex = 5;
            AddEntity(Count);


            AddEntity(new Background("tavernscore.png", this)
            {
                X = 10,
                Y = (float)Height - 70,
                Width = 500,
                Height = null,
                ZIndex = 4
            });
            Score = new Score(50, (float)Height - 50, this)
            {
                Direction = Score.FloatDirection.Up,
                Typeface = DefaultTypeface,
                ZIndex = 5,
                Prefix = "Score : "
            };

            Score.UpdateText();
            AddEntity(Score);

            UpdateWordlist();
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
