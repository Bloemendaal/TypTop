using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using TypTop.GameEngine;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.Tutorial
{
    public class TutorialGameScreen : Game
    {
        public event EventHandler Back;
        public event EventHandler Play;

        private readonly VisualKeyboard.VisualKeyboard _visualKeyboard;

        public TutorialGameScreen(WordProvider wordProvider)
        {
            List<char> chars = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            if ((wordProvider?.LimitChars?.Count ?? 0) > 0)
            {
                chars = wordProvider.LimitChars;
            }
            else if ((wordProvider?.UsageChars?.Count ?? 0) > 0)
            {
                chars = wordProvider.UsageChars;
            }

            _visualKeyboard = new VisualKeyboard.VisualKeyboard(this, new Vector2(200, 200));
            foreach (char ch in chars)
            {
                Key key = (Key)Enum.Parse(typeof(Key), char.IsDigit(ch) ? $"D{ch}" : ch.ToString());
                _visualKeyboard.SetKeyStyle(key);
            }

            AddEntity(new Title(this));
            AddEntity(new Hands(this));

            AddEntity(_visualKeyboard);
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
