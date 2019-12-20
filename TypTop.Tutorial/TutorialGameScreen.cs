using System;
using System.Numerics;
using System.Windows;

using TypTop.GameEngine;
using TypTop.MinigameEngine;

namespace TypTop.Tutorial
{
    public class TutorialGameScreen : Game
    {
        public event EventHandler Back;
        public event EventHandler Play;

        public TutorialGameScreen(string keys)
        {
            AddEntity(new VisualKeyboard.VisualKeyboard(this, new Vector2(200, 200)));
            var backButton = new Button(new Rect(new Point(50, 900), new Size(100, 100)), this, "backButton.png", "backButton_hover.png");
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);

            var playButton = new Button(new Rect(new Point(1800, 900), new Size(100f, 100f)),
                this, "play.png", "play_hover.png");
            playButton.Clicked += PlayButtonOnClicked;
            AddEntity(playButton);
        }

        private void PlayButtonOnClicked(object sender, EventArgs e)
        {
            Play?.Invoke(this, EventArgs.Empty);
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
