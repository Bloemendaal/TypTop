using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TypTop.Gui.SpaceGame
{
    /// <summary>
    /// Interaction logic for SpaceGameWindow.xaml
    /// </summary>
    public partial class SpaceGameWindow : Window
    {
        public SpaceGame Game { get; set; } = new SpaceGame(350); // create spacegame object

        // the following line represents the height when enemies hit the player
        public Line Line;

        // the following rectangle represents the player
        public Rectangle PlayerRect;

        public List<Rectangle> EnemyRectList = new List<Rectangle>();  // list of rectangles for the enemies, should never countain more than largest what is shown at once on screen

        public List<Label> EnemyLabelList = new List<Label>(); // similar to EnemyRectList, except it carries all possible labels

        public WordProvider WordProvider = new WordProvider();

        public SpaceGameWindow()
        {
            Line = new Line
            {
                X1 = 0,
                X2 = 800,
                Y1 = Game.LineHeight,
                Y2 = Game.LineHeight,
                Stroke = Brushes.Red,
                StrokeThickness = 5
            };

            PlayerRect = new Rectangle
            {
                Name = "Player",
                Width = 50,
                Height = 50,
                Fill = Brushes.DarkCyan
            };

            InitializeComponent();

            // subscribe to event
            Game.Timer.Tick += new EventHandler(Timer_Tick);

            // show line
            SpaceGameCanvas.Children.Add(Line);

            // show player
            SpaceGameCanvas.Children.Add(PlayerRect);
            Canvas.SetLeft(PlayerRect, 375);
            Canvas.SetTop(PlayerRect, 350);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // clear the window, every object needs to be removed and eventually re-added due to the possibility of changing positions
            SpaceGameCanvas.Children.Clear();

            // show line
            SpaceGameCanvas.Children.Add(Line);

            if (Game.GameOver)  // execue when game over
            {
                // show label saying "game over"
                Label GameOverLabel = new Label
                {
                    Content = "Game over",
                    Foreground = Brushes.Red,
                    FontSize = 48
                };
                SpaceGameCanvas.Children.Add(GameOverLabel);
                Canvas.SetLeft(GameOverLabel, 300);
                Canvas.SetTop(GameOverLabel, 200);
            }
            else    // execute when game is ongoing
            {
                // show player
                SpaceGameCanvas.Children.Add(PlayerRect);
                Canvas.SetLeft(PlayerRect, 375);
                Canvas.SetTop(PlayerRect, 350);

                // the following loop creates all enemies that should be shown on screen
                // it has a mechanism which prevents creation and saving of rudimentary rectangles
                // no more rectangles will be made than maximallly needed
                // this prevents an eventual abundance of unused objects which might slow down the device on which the program is runned
                // each rectangle represents an enemy in the game, the enemy object's X and Y attributes form the rectangle's centre
                int enemyCount = 0;
                foreach (Enemy enemy in Game.EnemyQueue)
                {
                    enemyCount++;
                    if ((enemyCount) > EnemyRectList.Count)
                    {
                        // if there are not enough rectaingles in the list, simply make a new one to use
                        EnemyRectList.Add(new Rectangle
                        {
                            Width = 50,
                            Height = 50,
                            Fill = Brushes.Green
                        });
                    }

                    if ((enemyCount) > EnemyLabelList.Count)
                    {
                        // if there are not enough rectaingles in the list, simply make a new one to use
                        EnemyLabelList.Add(new Label
                        {
                            Foreground = Brushes.Red
                        });
                    }

                    // show enemy rectangle on screen on right position
                    SpaceGameCanvas.Children.Add(EnemyRectList[enemyCount - 1]);
                    Canvas.SetLeft(EnemyRectList[enemyCount - 1], enemy.X - 25);
                    Canvas.SetTop(EnemyRectList[enemyCount - 1], enemy.Y - 25);
                    EnemyLabelList[enemyCount - 1].Content = enemy.Word.Letters;
                    SpaceGameCanvas.Children.Add(EnemyLabelList[enemyCount - 1]);
                    Canvas.SetLeft(EnemyLabelList[enemyCount - 1], enemy.X - 25);
                    Canvas.SetTop(EnemyLabelList[enemyCount - 1], enemy.Y - 25);
                }
            }
        }
    }
}
