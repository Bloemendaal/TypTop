using System;
using System.Numerics;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.TavernMinigame
{
    public class Tile : Entity
    {
        /// <summary>
        ///     Width of the tile.
        /// </summary>
        public const double Width = 200;

        /// <summary>
        ///     Heigth offset of the Order that is drawn on top of the Tile.
        /// </summary>
        public const double HeightOffset = 100;

        /// <summary>
        ///     Width offset of the Order that is drawn on top of the Tile.
        /// </summary>
        public const double WidthOffset = 60;

        private Word _word;

        public Tile(Order.OrderType orderType, float x, Game game) : base(game)
        {
            ZIndex = 2;
            AddComponent(new PositionComponent(x, 20));
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/tile.png", UriKind.Relative)))
            {
                Width = Width
            });

            Order = new Order(orderType, Game);

            Order.GetComponent<ImageComponent>().Width = Width - WidthOffset;
            var addWidth = WidthOffset / 2;
            if (Order.GetComponent<ImageComponent>().Height > GetComponent<ImageComponent>().Height - HeightOffset)
            {
                Order.GetComponent<ImageComponent>().Height = GetComponent<ImageComponent>().Height - HeightOffset;
                Order.GetComponent<ImageComponent>().Width = null;

                addWidth = (float) (GetComponent<ImageComponent>().Width - Order.GetComponent<ImageComponent>().Width) /
                           2;
            }

            Order.GetComponent<PositionComponent>().Position = new Vector2(x + (float) addWidth,
                (float) (GetComponent<ImageComponent>().Height - Order.GetComponent<ImageComponent>().Height) / 2);

            AddComponent(new WordComponent
            {
                TransformX = (float) Width / 2,
                TransformY = (float) (HeightOffset * 1.72),
                Center = true,
                FontSize = 40,
                Typeface = ((TavernGame) Game).DefaultTypeface
            });
        }

        public Order Order { get; }

        public Word Word
        {
            get => _word;
            set
            {
                _word = value;
                GetComponent<WordComponent>().Word = Word;
            }
        }
    }
}