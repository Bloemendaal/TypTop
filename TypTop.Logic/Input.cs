using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    abstract class Input
    {
        //
        // Summary:
        //     What does the program do when the users inputs a wrong key
        // Parameters:
        //     reset:
        //       Default. Resets the current typing progress of the word.
        //     remove:
        //       Remove the current word, note that a list only removes a word when the key is wrong after typing has started.
        //     none:
        //       Ignores the mistake and keeps the current typing progress of the word.
        public enum KeyWrong { reset, remove, none }
        public KeyWrong OnKeyWrong;


        //
        // Summary:
        //     Checks case-sensitivity of the input when comparing to the words. Default is true.
        public bool CaseSensitive = true;


        //
        // Summary:
        //     Ignores numbers when true, does not count them as mistake when entered. Removes all numbers from words if they contain any.
        public bool IgnoreNumbers = false;


        //
        // Summary:
        //     Ignores punctuation when true, does not count them as mistake when entered. Removes all interpunction from words if they contain any.
        public bool IgnorePunctuation = false;


        //
        // Summary:
        //     Ignores space when true, does not count as mistake when entered. Removes all whitespaces from words if they contain any.
        public bool IgnoreSpace = false;


        //
        // Summary:
        //     Ignores special characters marks when true, converts all special characters if possible to standard characters.
        public bool IgnoreSpecialChar = true;


        //
        // Summary:
        //     Allow backspacing when typing a word has started. Note that backspacing will work for all the words in the list.
        public bool AllowBackspace = false;


        //
        // Summary:
        //     Remove the current word when the spacebar is pressed. Only works when IgnoreSpace is false. Note that when a list is used, all words will be removed when none of the words match.
        public bool RemoveOnSpace = false;


        //
        // Summary:
        //     Subscribe or unsubscribe to the KeyUp event
        // Parameters:
        //     mainWindow:
        //       MainWindow that fires the KeyUp event.
        public void Subscribe(MainWindow mainWindow) => mainWindow.TextInput += TextInput;
        public void Unsubscribe(TypTop.Gui.MainWindow mainWindow) => mainWindow.TextInput -= TextInput;


        public void TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
        public void TextInput(char e)
        {

        }


        //
        // Summary:
        //     Checks the given word for the given letter.
        // Returns:
        //     If the letter matches the current typing index of the word.
        // Parameters:
        //     letter:
        //       The letter that was inputted by the user.
        //     word:
        //       The word needs to be checked.
        public bool CheckWord(char letter, Word word)
        {
            if (CheckIgnoredChars(letter))
            {
                return true;
            }

            int index = word.Index;
            char wordCharAtIndex = word.Letters[index];

            bool wrongChar = true;
            while (wrongChar && word.ValidIndex(index))
            {
                wordCharAtIndex = word.Letters[index];

                if (CheckIgnoredChars(wordCharAtIndex))
                {
                    index++;
                    continue;
                }

                wrongChar = false;
            }

            if (index >= word.Letters.Length)
            {
                word.Correct = true;
                return true;
            }

            if (char.IsLetter(letter))
            {
                if (IgnoreSpecialChar)
                {
                    letter = ConvertSpecialChar(letter);
                    wordCharAtIndex = ConvertSpecialChar(wordCharAtIndex);
                }

                return (CaseSensitive && letter == wordCharAtIndex) || (!CaseSensitive && char.ToLower(letter) == char.ToLower(wordCharAtIndex));
            }

            return letter == wordCharAtIndex;
        }


        //
        // Summary:
        //     Checks if the given char should be ignored according to the given settings.
        // Returns:
        //     If the char should be ignored.
        private bool CheckIgnoredChars(char ch)
        {
            return (IgnoreNumbers && char.IsDigit(ch)) || (IgnoreSpace && char.IsWhiteSpace(ch)) || (IgnorePunctuation && char.IsPunctuation(ch));
        }

        private static char ConvertSpecialChar(char ch)
        {
            char[] from = "àèìòùÀÈÌÒÙ äëïöüÄËÏÖÜ âêîôûÂÊÎÔÛ áéíóúÁÉÍÓÚðÐýÝ ãñõÃÑÕšŠžŽçÇåÅøØ".ToCharArray();
            char[] to   = "aeiouAEIOU aeiouAEIOU aeiouAEIOU aeiouAEIOUdDyY anoANOsSzZcCaAoO".ToCharArray();

            for (int i = 0; i < from.Length; i++)
            {
                if (ch == from[i])
                {
                    return to[i];
                }
            }

            return ch;
        }
    }
}
