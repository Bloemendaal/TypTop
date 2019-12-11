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
            private set
            {
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
            private set
            {
                if (value < 1)
                {
                    value = 1;
                }

                if (value > 3)
                {
                    value = 3;
                }

                _maxCustomers = value;
            }
        }
        private int _maxCustomers = 3;

        public int CustomerSpawnSpeed 
        { 
            get => _customerSpawnSpeed; 
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _customerSpawnSpeed = value;
            } 
        }
        private int _customerSpawnSpeed = 4000;
        public int CustomerSpawnSpeedOffset
        {
            get => _customerSpawnSpeedOffset;
            private set => _customerSpawnSpeedOffset = Math.Abs(value);
        }
        private int _customerSpawnSpeedOffset = 1000;
        public double CustomerSpawnSpeedMultiplier
        {
            get => _customerSpawnSpeedMultiplier;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _customerSpawnSpeedMultiplier = value;
            }
        }
        private double _customerSpawnSpeedMultiplier = 0.1;


        private readonly List<Customer> _customers = new List<Customer>();
        private readonly CustomerQueue _customerQueue;

        private readonly ITimer _timer;

        public readonly Typeface DefaultTypeface = new Typeface("MV Boli");

        // Customer Satisfaction
        public bool ShowSatisfaction { get; private set; } = false;
        public int StartSatisfaction
        { 
            get => _startSatisfaction; 
            private set
            {
                if (value < 1)
                {
                    value = 1;
                }

                if (value > 5)
                {
                    value = 5;
                }

                _startSatisfaction = value;
            } 
        }
        private int _startSatisfaction = 5;
        private readonly Dictionary<int, int> _satisfactionTiming = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 }
        };


        public TavernGame(Level level) : base(level.WinCondition)
        {
            if (level != null && level.Properties != null)
            {
                int countOffset = 360;

                // Words
                if (level.Properties.ContainsKey("Words") && level.Properties["Words"] is IEnumerable<Word> words)
                {
                    _words = new Queue<Word>(words);
                }
                else
                {
                    throw new ArgumentException("'Words' is missing or not valid");
                }

                // TileAmount
                if (level.Properties.ContainsKey("TileAmount") && level.Properties["TileAmount"] is int tileAmount)
                {
                    TileAmount = tileAmount;
                }

                // MaxCustomers
                if (level.Properties.ContainsKey("MaxCustomers") && level.Properties["MaxCustomers"] is int maxCustomers)
                {
                    MaxCustomers = maxCustomers;
                }

                // ShowSatisfaction
                if (level.Properties.ContainsKey("ShowSatisfaction") && level.Properties["ShowSatisfaction"] is bool showSatisfaction)
                {
                    ShowSatisfaction = showSatisfaction;
                }

                // StartSatisfaction
                if (level.Properties.ContainsKey("StartSatisfaction") && level.Properties["StartSatisfaction"] is int startSatisfaction)
                {
                    StartSatisfaction = startSatisfaction;
                }

                // SatisfactionTiming
                if (level.Properties.ContainsKey("SatisfactionTiming") && level.Properties["SatisfactionTiming"] is Dictionary<int, int> satisfactionTiming)
                {
                    _satisfactionTiming = new Dictionary<int, int>(satisfactionTiming);
                }

                // CustomerSpawnSpeed
                if (level.Properties.ContainsKey("CustomerSpawnSpeed") && level.Properties["CustomerSpawnSpeed"] is int customerSpawnSpeed)
                {
                    CustomerSpawnSpeed = customerSpawnSpeed;
                }

                // CustomerSpawnSpeedOffset
                if (level.Properties.ContainsKey("CustomerSpawnSpeedOffset") && level.Properties["CustomerSpawnSpeedOffset"] is int customerSpawnSpeedOffset)
                {
                    CustomerSpawnSpeedOffset = customerSpawnSpeedOffset;
                }

                // CustomerSpawnSpeedMultiplier
                if (level.Properties.ContainsKey("CustomerSpawnSpeedMultiplier") && level.Properties["CustomerSpawnSpeedMultiplier"] is double customerSpawnSpeedMultiplier)
                {
                    CustomerSpawnSpeedMultiplier = customerSpawnSpeedMultiplier;
                }


                // WinConditions
                if (level.WinCondition is ScoreCondition)
                {
                    Finish = () => Count.Seconds < 0;
                }

                if (level.WinCondition is LifeCondition)
                {
                    if (level.Properties.ContainsKey("Lives") && level.Properties["Lives"] is int lives)
                    {
                        Lives = new Lives(550, (float)Height - 60, this)
                        {
                            Amount = lives,
                            ZIndex = 6
                        };

                        Finish = () => Lives.Amount <= 0 || Count.Seconds < 0;

                        AddEntity(Lives);
                    }
                    else
                    {
                        throw new ArgumentException("'Lives' is missing or not valid");
                    }
                }

                if (level.WinCondition is TimeCondition)
                {
                    if (level.Properties.ContainsKey("Queue") && level.Properties["Queue"] is int queue)
                    {
                        for (int i = 0; i < queue; i++)
                        {
                            AddCustomer(new Customer(this));
                        }

                        Count = new Count(0, countOffset, (float)Height - 50, this);

                        Finish = () => _customerQueue.Count <= 0;
                    }
                    else
                    {
                        throw new ArgumentException("'Queue' is missing or not valid");
                    }
                }
                else
                {
                    if (level.Properties.ContainsKey("Seconds") && level.Properties["Seconds"] is int seconds)
                    {
                        _timer = AddTimer(() =>
                        {
                            AddCustomer(new Customer(this));
                            _timer.Interval = (int)(Rnd.Next(CustomerSpawnSpeed - CustomerSpawnSpeedOffset, CustomerSpawnSpeed + CustomerSpawnSpeedOffset) * (1 + _customerQueue.Count * CustomerSpawnSpeedMultiplier));
                        }, Rnd.Next(CustomerSpawnSpeed - CustomerSpawnSpeedOffset, CustomerSpawnSpeed + CustomerSpawnSpeedOffset));

                        Count = new Count(seconds, countOffset, (float)Height - 50, this);
                    }
                    else
                    {
                        throw new ArgumentException("'Seconds' is missing or not valid");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(level));
            }

            AddEntity(new Background("tavern.png", this));

            _customerQueue = new CustomerQueue(this);
            AddEntity(_customerQueue);

            TextInput += OnTextInput;
            
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
                Prefix = "Score : ",
                Right = true
            };

            Score.UpdateText();
            AddEntity(Score);

            UpdateWordlist();
        }


        public int GetSatisfaction(int key) => _satisfactionTiming.ContainsKey(key) ? _satisfactionTiming[key] : 0;

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
            _tiles.Where(t => !_customers.Any(c => c.HasOrder(t.Order))).Select(t => t.Word).ToList().ForEach(w => w.Index = 0);
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
                                customer.RemoveEntities(customer.OriginalCount * 10 + 50 + (customer.Satisfaction?.Amount ?? StartSatisfaction) * 2);
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
