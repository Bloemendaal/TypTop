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
        /// <summary>
        /// Minimale waarde is 1, maximale waarde is de lengte van het aantal OrderType’s. Wanneer deze property geset wordt, worden de Tiles willekeurig gegenereerd tot een lijst _tiles.
        /// </summary>
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

        /// <summary>
        /// Lijst met alle Tile’s erin. Wordt gerenderd wanneer het TileAmount geset wordt.
        /// </summary>
        private List<Tile> _tiles;

        /// <summary>
        /// Lijst met Word’s die gebruikt kan worden door de Tiles.
        /// </summary>
        private readonly Queue<Word> _words;

        /// <summary>
        /// InputList uit TypTop.Logic die gebruikt wordt om de input van de gebruiker te analyseren. FocusOnHighIndex staat op true. De woordenlijst wordt pas meegegeven wanneer de method UpdateWordlist() aangeroepen wordt.
        /// </summary>
        private readonly InputList _inputList = new InputList(null)
        {
            FocusOnHighIndex = true
        };

        /// <summary>
        /// Maximaal aantal Customer’s dat in de taverne getekend wordt voordat ze in de CustomerQueue gestopt worden. Minimaal aantal is 0, maximaal is aanbevolen 3 omdat de rest (deels) buiten het scherm gerenderd wordt.
        /// </summary>
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

        /// <summary>
        /// Every amount of milliseconds a customer should spawn.
        /// </summary>
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

        /// <summary>
        /// Maximum offset that is used when generating random spawn speeds in both directions.
        /// </summary>
        public int CustomerSpawnSpeedOffset
        {
            get => _customerSpawnSpeedOffset;
            private set => _customerSpawnSpeedOffset = Math.Abs(value);
        }
        private int _customerSpawnSpeedOffset = 1000;

        /// <summary>
        /// Multiply the spawnspeed of the customers with 1 + (x * [amount of customers in the queue])
        /// </summary>
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

        /// <summary>
        /// Minimum amount of orders a customer has to take.
        /// </summary>
        public int CustomerMinOrderAmount
        {
            get => _customerMinOrderAmount;
            private set
            {
                if (value < 1)
                {
                    value = 1;
                }

                if (value > CustomerMaxOrderAmount)
                {
                    value = CustomerMaxOrderAmount;
                }

                _customerMinOrderAmount = value;
            }
        }
        private int _customerMinOrderAmount = 1;

        /// <summary>
        /// Maximum amount of orders a customer has to take.
        /// </summary>
        public int CustomerMaxOrderAmount
        {
            get => _customerMaxOrderAmount;
            private set
            {
                if (value > 4)
                {
                    value = 4;
                }

                if (value < CustomerMinOrderAmount)
                {
                    value = CustomerMinOrderAmount;
                }

                _customerMaxOrderAmount = value;
            }
        }
        private int _customerMaxOrderAmount = 4;


        /// <summary>
        /// Lijst met Customer’s die zichtbaar zijn in de taverne.
        /// </summary>
        private readonly List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Visuele weergave van de CustomerQueue inclusief de Queue<Customer> zelf.
        /// </summary>
        private readonly CustomerQueue _customerQueue;

        /// <summary>
        /// Timer die nodig is om Customer’s toe te voegen aan de rij.
        /// </summary>
        private readonly ITimer _timer;

        /// <summary>
        /// Standaard font dat gebruikt moet worden in de hele Tavern minigame, MV Boli.
        /// </summary>
        public readonly Typeface DefaultTypeface = new Typeface("MV Boli");

        /// <summary>
        /// Geef de satisfaction van een Customer weer. Standaardwaarde is false.
        /// </summary>
        public bool ShowSatisfaction { get; private set; } = false;

        /// <summary>
        /// Waarde tussen 1 en 5 waarop de Customer’s satisfaction standaard ingesteld staat. Standaardwaarde is 5. 
        /// </summary>
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

        /// <summary>
        /// Tijden in milliseconden waarin waarin de Customer’s bozer worden. Eerste int, TKey, is de satisfaction. Tweede int, TValue, is het aantal milliseconden. Standaardwaardes per satisfaction is 0 milliseconden (geen timer ingesteld, satisfaction kan dus niet verspringen).
        /// </summary>
        private readonly Dictionary<int, int> _satisfactionTiming = new Dictionary<int, int>()
        {
            { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 }
        };


        public TavernGame(Level level) : base(level)
        {
            if (level != null && level.Properties != null)
            {
                int countOffset = 360;
                _customerQueue = new CustomerQueue(this);

                // Words
                _words = new Queue<Word>(WordProvider.Serve());

                // TileAmount
                TileAmount = level.Properties.TryGetValue("TileAmount", out object tileAmountObject) && tileAmountObject is int tileAmount ? tileAmount : 3;

                if (_words.Count < TileAmount)
                {
                    throw new ArgumentException("'Words' amount is less than the amount of tiles");
                }

                // MaxCustomers
                if (level.Properties.TryGetValue("MaxCustomers", out object maxCustomersObject) && maxCustomersObject is int maxCustomers)
                {
                    MaxCustomers = maxCustomers;
                }

                // ShowSatisfaction
                if (level.Properties.TryGetValue("ShowSatisfaction", out object showSatisfactionObject) && showSatisfactionObject is bool showSatisfaction)
                {
                    ShowSatisfaction = showSatisfaction;
                }

                // StartSatisfaction
                if (level.Properties.TryGetValue("StartSatisfaction", out object startSatisfactionObject) && startSatisfactionObject is int startSatisfaction)
                {
                    StartSatisfaction = startSatisfaction;
                }

                // SatisfactionTiming
                if (level.Properties.TryGetValue("SatisfactionTiming", out object satisfactionTimingObject) && satisfactionTimingObject is Dictionary<int, int> satisfactionTiming)
                {
                    _satisfactionTiming = new Dictionary<int, int>(satisfactionTiming);
                }

                // CustomerSpawnSpeed
                if (level.Properties.TryGetValue("CustomerSpawnSpeed", out object customerSpawnSpeedObject) && customerSpawnSpeedObject is int customerSpawnSpeed)
                {
                    CustomerSpawnSpeed = customerSpawnSpeed;
                }

                // CustomerSpawnSpeedOffset
                if (level.Properties.TryGetValue("CustomerSpawnSpeedOffset", out object customerSpawnSpeedOffsetObject) && customerSpawnSpeedOffsetObject is int customerSpawnSpeedOffset)
                {
                    CustomerSpawnSpeedOffset = customerSpawnSpeedOffset;
                }

                // CustomerSpawnSpeedMultiplier
                if (level.Properties.TryGetValue("CustomerSpawnSpeedMultiplier", out object customerSpawnSpeedMultiplierObject) && customerSpawnSpeedMultiplierObject is double customerSpawnSpeedMultiplier)
                {
                    CustomerSpawnSpeedMultiplier = customerSpawnSpeedMultiplier;
                }

                // CustomerMinOrderAmount
                if (level.Properties.TryGetValue("CustomerMinOrderAmount", out object customerMinOrderAmountObject) && customerMinOrderAmountObject is int customerMinOrderAmount)
                {
                    CustomerMinOrderAmount = customerMinOrderAmount;
                }
                // CustomerMaxOrderAmount
                if (level.Properties.TryGetValue("CustomerMaxOrderAmount", out object customerMaxOrderAmountObject) && customerMaxOrderAmountObject is int customerMaxOrderAmount)
                {
                    CustomerMaxOrderAmount = customerMaxOrderAmount;
                }


                // WinConditions
                if (level.WinCondition == WinConditionType.ScoreCondition)
                {
                    Finish = () => Count.Seconds < 0;
                }

                if (level.WinCondition == WinConditionType.LifeCondition)
                {
                    if (level.Properties.TryGetValue("Lives", out object livesObject) && livesObject is int lives)
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

                if (level.WinCondition == WinConditionType.TimeCondition)
                {
                    if (level.Properties.TryGetValue("Queue", out object queueObject) && queueObject is int queue)
                    {
                        for (int i = 0; i < queue; i++)
                        {
                            AddCustomer(new Customer(this));
                        }

                        Count = new Count(0, countOffset, (float)Height - 50, this);

                        Finish = () => _customerQueue.Count <= 0 && _customers.Count <= 0;
                    }
                    else
                    {
                        throw new ArgumentException("'Queue' is missing or not valid");
                    }
                }
                else
                {
                    if (level.Properties.TryGetValue("Seconds", out object secondsObject) && secondsObject is int seconds)
                    {
                        _timer = AddTimer(() =>
                        {
                            AddCustomer(new Customer(this));
                            _timer.Interval = (int)(Rnd.Next(Math.Max(CustomerSpawnSpeed - CustomerSpawnSpeedOffset, 0), CustomerSpawnSpeed + CustomerSpawnSpeedOffset) * (1 + _customerQueue.Count * CustomerSpawnSpeedMultiplier));
                        }, Rnd.Next(Math.Max(CustomerSpawnSpeed - CustomerSpawnSpeedOffset, 0), CustomerSpawnSpeed + CustomerSpawnSpeedOffset));

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

        /// <summary>
        /// Get the amount of milliseconds for a certain satisfaction.
        /// </summary>
        /// <param name="key">
        /// Satisfaction (0 - 5)
        /// </param>
        /// <returns>
        /// Time in milliseconds.
        /// </returns>
        public int GetSatisfaction(int key) => _satisfactionTiming.ContainsKey(key) ? _satisfactionTiming[key] : 0;

        /// <summary>
        /// Add customer to _customers unless it exceeds MaxCustomers. In that case it is added to _customerQueue.
        /// </summary>
        /// <param name="customer">
        /// Customer to be added.
        /// </param>
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

        /// <summary>
        /// Schuift de complete rij Customer’s een plekje door.
        /// </summary>
        /// <returns>
        /// Geeft terug of dit gelukt is.
        /// </returns>
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

        /// <summary>
        /// Verwijdert een Customer uit _customers en werkt de posities van alle Customer’s in _customers daarna bij. Daarna wordt de method UpdateWordlist() aangeroepen.
        /// </summary>
        /// <param name="customer">
        /// Customer to be removed.
        /// </param>
        /// <returns>
        /// Geeft terug of het verwijderen gelukt is.
        /// </returns>
        public bool RemoveCustomer(Customer customer) {
            bool result = _customers.Remove(customer);
            if (result && _customers.Count > 0)
            {
                _customers.ForEach(c => c.UpdatePosition(CustomerIndex(c)));
            }
            UpdateWordlist();
            return result;
        }

        /// <summary>
        /// Geeft de index van de Customer in _customers.
        /// </summary>
        /// <param name="customer">
        /// Customer to be checked.
        /// </param>
        /// <returns>
        /// Geeft de index van de Customer in _customers.
        /// </returns>
        public int CustomerIndex(Customer customer) => _customers.IndexOf(customer);

        /// <summary>
        /// Werkt de woordenlijst van _inputList bij zodat deze overeenkomt met de wensen van de Customer’s. Word’s op Tile’s die niet gevraagd worden door Customer’s, worden hierdoor niet geaccepteerd als input.
        /// </summary>
        public void UpdateWordlist()
        {
            _inputList.Input = _tiles.Where(t => _customers.Any(c => c.HasOrder(t.Order))).Select(t => t.Word).ToList();
            _tiles.Where(t => !_customers.Any(c => c.HasOrder(t.Order))).Select(t => t.Word).ToList().ForEach(w => w.Index = 0);
        }

        /// <summary>
        /// Geeft een lijst met amount aantal willekeurige Order’s erin.
        /// </summary>
        /// <param name="amount">
        /// Aantal willekeurige Order's.
        /// </param>
        /// <returns>
        /// Geeft een lijst met amount aantal willekeurige Order’s erin.
        /// </returns>
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

        /// <summary>
        /// Controleert de input van de leerling. Controleert voor elke Customer of een Order afgehandeld is door die input en ook of de Customer volledig geholpen is. Een Word wordt verwijdert uit _words en de method UpdateWordlist() wordt aangeroepen wanneer een Word volledig goed getypt is. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
