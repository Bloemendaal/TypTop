﻿using System.ComponentModel;
using System.Numerics;
using System.Windows;
using System.Windows.Input;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyFactory
    ***REMOVED***
        public KeyboardKey CreateKey(Key key, KeyStyle style)
        ***REMOVED***
            var normalKeySize = new Size(50, 50);//A key
            var ctrlKeySize = new Size(62.5D, 50);//A key
            var tabSize = new Size(75, 50);//Caps key
            var capsSize = new Size(90, 50); //Enter and shift key
            var enterSize = new Size(115, 50); //Enter and shift key
            var shiftSize = new Size(100, 50); // Left Shift
            var rightShiftSize = new Size(160, 50); // Right Shift
            var spaceSize = new Size(312.5D, 50);
            if (key >= Key.A && key <= Key.Z)
            ***REMOVED***
                return CreateSingleSymbolKey(key, normalKeySize, style);
        ***REMOVED***

            switch (key)
            ***REMOVED***
                case Key.D1:
                    return CreateDualSymbolKey(key, "!", "1", normalKeySize, style);
                case Key.D2:
                    return CreateDualSymbolKey(key, "@", "2", normalKeySize, style);
                case Key.D3:
                    return CreateDualSymbolKey(key, "#", "3", normalKeySize, style);
                case Key.D4:
                    return CreateDualSymbolKey(key, "$", "4", normalKeySize, style);
                case Key.D5:
                    return CreateDualSymbolKey(key, "%", "5", normalKeySize, style);
                case Key.D6:
                    return CreateDualSymbolKey(key, "^", "6", normalKeySize, style);
                case Key.D7:
                    return CreateDualSymbolKey(key, "&", "7", normalKeySize, style);
                case Key.D8:
                    return CreateDualSymbolKey(key, "*", "8", normalKeySize, style);
                case Key.D9:
                    return CreateDualSymbolKey(key, "(", "9", normalKeySize, style);
                case Key.D0:
                    return CreateDualSymbolKey(key, ")", "0", normalKeySize, style);
                case Key.OemMinus:
                    return CreateDualSymbolKey(key, "-", "_", normalKeySize, style);
                case Key.OemPlus:
                    return CreateDualSymbolKey(key, "+", "=", normalKeySize, style);
                case Key.OemTilde:
                    return CreateDualSymbolKey(key, "~", "`", normalKeySize, style);
                case Key.OemOpenBrackets:
                    return CreateDualSymbolKey(key, "***REMOVED***", "[", normalKeySize, style);
                case Key.OemCloseBrackets:
                    return CreateDualSymbolKey(key, "***REMOVED***", "]", normalKeySize, style);
                case Key.OemPipe:
                    return CreateDualSymbolKey(key, "|", "\\", tabSize, style);
                case Key.OemSemicolon:
                    return CreateDualSymbolKey(key, ":", ";", normalKeySize, style);
                case Key.OemQuotes:
                    return CreateDualSymbolKey(key, "\"", "'", normalKeySize, style);

                case Key.OemComma:
                    return CreateDualSymbolKey(key, "<", ",", normalKeySize, style);
                case Key.OemPeriod:
                    return CreateDualSymbolKey(key, ">", ".", normalKeySize, style);
                case Key.OemQuestion:
                    return CreateDualSymbolKey(key, "?", "/", normalKeySize, style);

                case Key.LeftCtrl:
                case Key.RightCtrl:
                    return CreateTextKey(key, "Ctrl", normalKeySize, style, HorizontalAlignment.Center, VerticalAlignment.Center);

                case Key.LeftAlt:
                case Key.RightAlt:
                    return CreateTextKey(key, "Alt", normalKeySize, style, HorizontalAlignment.Center, VerticalAlignment.Center);


                case Key.LWin:
                case Key.RWin:
                    return CreateTextKey(key, "⊞", normalKeySize, style, HorizontalAlignment.Center, VerticalAlignment.Center);

                case Key.Enter:
                    return CreateTextKey(key, "↵ Enter", enterSize, style, HorizontalAlignment.Right, VerticalAlignment.Center, new Vector2(-5, 0));
                case Key.Back:
                    return CreateTextKey(key, "⌫", shiftSize, style, HorizontalAlignment.Right, VerticalAlignment.Center, new Vector2(-5,0));
                case Key.RightShift:
                    return CreateTextKey(key, "Shift", rightShiftSize, style, HorizontalAlignment.Right,
                        VerticalAlignment.Center, new Vector2(-5, 0));

                case Key.Tab:
                    return CreateTextKey(key, "~", tabSize, style, HorizontalAlignment.Left, VerticalAlignment.Center, new Vector2(5, 0));
                case Key.CapsLock:
                    return CreateTextKey(key, "Caps", capsSize, style, HorizontalAlignment.Left, VerticalAlignment.Center, new Vector2(5, 0));
                case Key.LeftShift:
                    return CreateTextKey(key, "Shift", shiftSize, style, HorizontalAlignment.Left,
                        VerticalAlignment.Center, new Vector2(5, 0));

                case Key.Space:
                    return new BlankKey(Key.Space, spaceSize, style);

                default:
                    throw new InvalidEnumArgumentException();
        ***REMOVED***
    ***REMOVED***

        private KeyboardKey CreateTextKey(Key key, string text, Size size, KeyStyle style,
            HorizontalAlignment horizontalAlignment = default,
            VerticalAlignment verticalAlignment = default,
            Vector2 offset = default
            )
        ***REMOVED***
            var textPrintDrawer = new TextPrintDrawer(text, style)
            ***REMOVED***
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = verticalAlignment,
                Offset = offset
        ***REMOVED***;
            var keyboardKey = new PrintedKey(key, size, style, textPrintDrawer);
            keyboardKey.StyleChanged += (o, e) => ***REMOVED*** textPrintDrawer.Style = e.KeyStyle; ***REMOVED***;
            return keyboardKey;
    ***REMOVED***

        private KeyboardKey CreateSingleSymbolKey(Key key,Size size, KeyStyle style)
        ***REMOVED***
            return CreateTextKey(key,key.ToString(), size,style, offset: new Vector2(3,3));
    ***REMOVED***

        private KeyboardKey CreateDualSymbolKey(Key key,string firstSymbol, string secondSymbol, Size size, KeyStyle style)
        ***REMOVED***
            var firstSymbolPrinter = new TextPrintDrawer(firstSymbol, style)
            ***REMOVED***
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Offset = new Vector2(3, 0)
        ***REMOVED***;

            var secondSymbolPrinter = new TextPrintDrawer(secondSymbol, style)
            ***REMOVED***
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Offset = new Vector2(3, -7)
        ***REMOVED***;
            var keyboardKey = new PrintedKey(key, size, style, firstSymbolPrinter, secondSymbolPrinter);
            keyboardKey.StyleChanged += (o, e) =>
            ***REMOVED***
                firstSymbolPrinter.Style = e.KeyStyle;
                secondSymbolPrinter.Style = e.KeyStyle;
        ***REMOVED***;
            return keyboardKey;
    ***REMOVED***
***REMOVED***
***REMOVED***