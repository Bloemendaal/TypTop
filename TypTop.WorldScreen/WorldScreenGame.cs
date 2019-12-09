using System;
using System.ComponentModel;
using System.Windows;
using TypTop.GameEngine;
using TypTop.MinigameEngine;

namespace TypTop.WorldScreen
{
    public class WorldScreenGame : Game
    {
        public WorldScreenGame()
        {
            AddEntity(new Background("main_background.png",this));
            
            var backButton = new Button("backButton.png", new Rect(new Point(50, 900), new Size(100,100)), this);
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);

            var spaceGameButton = new Button("spaceButton.png", new Rect(new Point(400, 400), new Size(600, 500)), this);
            spaceGameButton.Clicked += SpaceGameButtonOnClicked;
            AddEntity(spaceGameButton);

            var tavernGameButton = new Button("tavernButton.png", new Rect(new Point(1100, 400), new Size(600, 500)), this);
            tavernGameButton.Clicked += TavernGameButtonOnClicked;
            AddEntity(tavernGameButton);
        }

        private void TavernGameButtonOnClicked(object sender, EventArgs e)
        {
            MessageBox.Show("TavernButtonClicked");
        }

        private void SpaceGameButtonOnClicked(object sender, EventArgs e)
        {
            MessageBox.Show("SpaceButtonClicked");
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            MessageBox.Show("BackButtonClicked");
        }
    }
}
