using System;
using System.Windows;
using TypTop.GameEngine;
using TypTop.GameGui;
using TypTop.Logic;
using TypTop.MinigameEngine;

namespace TypTop.LevelScreen
{
    public class LevelScreenGame : Game
    {
        private readonly IGameLoader _gameLoader;
        private readonly World _world;
        private readonly InfoPanel _infoPanel;

        public LevelScreenGame(World world, IGameLoader gameLoader)
        {
            _world = world;
            _gameLoader = gameLoader;

            AddEntity(new Background(world.Background, this));


            _infoPanel = new InfoPanel(this)
            {
                Text = "Lorem Ipsum is slechts een proeftekst uit het drukkerij- en" +
                                                    " zetterijwezen. Lorem Ipsum is de standaard proeftekst in deze b" +
                                                    "edrijfstak sinds de 16e eeuw, toen een onbekende drukker een zethaak met letter" +
                                                    "s nam en ze door elkaar husselde om een font-catalogus te maken. Het heeft niet allee" +
                                                    "n vijf eeuwen overleefd maar is ook, vrijwel onveranderd, overgenomen in elektronische" +
                                                    " letterzetting. Het is in de jaren '60 populair geworden met de introductie van Letra" +
                                                    "set vellen met Lorem Ipsum passages en meer recentelijk door desktop publishing softwa" +
                                                    "re zoals Aldus PageMaker die versies van Lorem Ipsum bevatten."
            };

            AddEntity(_infoPanel);

            for (var index = 0; index < world.Levels.Count; index++)
            {
                Level worldLevel = world.Levels[index];
                var button = new TextButton((index+1).ToString(),Utils.GetRectangle(index, world.Levels.Count, 5, 50f, 100f, 100f),
                    this, "levelOpen.png", "levelOpen_hover.png");
                button.Data = worldLevel;
                button.Clicked += ButtonOnClicked;
                AddEntity(button);
            }

            var infoButton = new Button(new Rect(new Point(1800, 900), new Size(100f, 100f)),
                this, "vraagTeken.png", "vraagTeken_hover.png");
            infoButton.Clicked += InfoButtonOnClicked;
            AddEntity(infoButton);

            var backButton = new Button(new Rect(new Point(50, 900), new Size(100, 100)), this, "backButton.png", "backButton_hover.png");
            backButton.Clicked += BackButtonOnClicked;
            AddEntity(backButton);
        }

        private void InfoButtonOnClicked(object sender, EventArgs e)
        {
            _infoPanel.Visible = !_infoPanel.Visible;
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            _gameLoader.LoadMinigame(((Button)sender).Data as Level);
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            _gameLoader.LoadWorldMap();
        }
    }
}