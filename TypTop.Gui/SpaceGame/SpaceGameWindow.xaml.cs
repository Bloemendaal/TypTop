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
        public SpaceGame Game { get; set; } = new SpaceGame(); // create spacegame object

        // the following rectangle represents the player
        Rectangle PlayerRect = new Rectangle
        {
            Name = "Player",
            Width = 50,
            Height = 50,
            Fill = Brushes.DarkCyan
        }; 

        public List<Rectangle> EnemyRectList = new List<Rectangle>();  // list of rectangles for the enemies, should never countain more than largest what is shown at once on screen

        public SpaceGameWindow()
        {
            InitializeComponent();

            // subscribe to event
            Game.Timer.Tick += new EventHandler(Timer_Tick);

            // show player
            SpaceGameCanvas.Children.Add(PlayerRect);
            Canvas.SetLeft(PlayerRect, 375);
            Canvas.SetTop(PlayerRect, 350);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // clear the window, every object needs to be removed and eventually re-added due to the possibility of changing positions
            SpaceGameCanvas.Children.Clear();

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

                    // show enemy rectangle on screen on right position
                    SpaceGameCanvas.Children.Add(EnemyRectList[enemyCount - 1]);
                    Canvas.SetLeft(EnemyRectList[enemyCount - 1], enemy.X - 25);
                    Canvas.SetTop(EnemyRectList[enemyCount - 1], enemy.Y - 25);
                }
            }
        }
    }
}
