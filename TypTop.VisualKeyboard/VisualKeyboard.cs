using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.GameEngine;

namespace TypTop.VisualKeyboard
{
    public class VisualKeyboard : Entity
    {
        private readonly KeyboardLayout Layout;

        private readonly Dictionary<Key, KeyStyle> _defaultColorScheme = new Dictionary<Key, KeyStyle>()
        {
            {Key.D1, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.D2, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.Q, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.A, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.Z, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.LeftShift, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.Tab, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.CapsLock, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemTilde, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},

            {Key.D3, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.W, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.S, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.X, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},

            {Key.D4, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.E, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.D, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.C, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},

            {Key.D5, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.R, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.F, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.V, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.D6, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.T, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.G, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.B, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},


            {Key.D8, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.U, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.J, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.M, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.D7, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.Y, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.H, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},
            {Key.N, new KeyStyle(){ FaceBrush = Brushes.LightGreen, SymbolBrush = Brushes.Black }},

            {Key.D9, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.I, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.K, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},
            {Key.OemComma, new KeyStyle(){ FaceBrush = Brushes.Gold, SymbolBrush = Brushes.Black }},

            {Key.D0, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.O, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.L, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},
            {Key.OemPeriod, new KeyStyle(){ FaceBrush = Brushes.SkyBlue, SymbolBrush = Brushes.Black }},

            {Key.P, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemSemicolon, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemQuestion, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.RightShift, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.Enter, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemPipe, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemPlus, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemMinus, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.Back, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemCloseBrackets, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemOpenBrackets, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
            {Key.OemQuotes, new KeyStyle(){ FaceBrush = Brushes.Tomato, SymbolBrush = Brushes.Black }},
        };

        public void SetKeyStyle(Key key, KeyStyle color = null)
        {
            Layout.SetKeyStyle(key, color ?? _defaultColorScheme[key]);
        }

        public override void Draw(DrawingContext drawingContext)
        {
            base.Draw(drawingContext);
            Layout.Render(drawingContext);
        }

        public VisualKeyboard(Game minigame, Vector2 position) : base(minigame)
        {
            Layout = new QwertyKeyboardLayout(position);
        }
    }
}
