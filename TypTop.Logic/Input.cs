using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    public abstract class Input
    {
        /// <summary>
        /// The previously inputted letter with the TextInput function.
        /// </summary>
        public char PreviousChar { get; private set; }


        /// <summary>
        /// Fires when words have been updated
        /// </summary>
        public abstract event EventHandler<WordUpdateArgs> WordUpdate;


        /// <summary>
        /// What does the program do when the users inputs a wrong key.
        /// </summary>
        /// <param name="Reset">
        /// Default. Resets the current typing progress of the word.
        /// </param>
        /// <param name="Remove">
        /// Remove the current word, note that a list only removes a word when the key is wrong after typing has started.
        /// </param>
        /// <param name="Add">
        /// Adds the wrong character to the stack. User needs to backspace it to remove the wrong letter.
        /// </param>
        /// <param name="None">
        /// Ignores the mistake and keeps the current typing progress of the word.
        /// </param>
        public enum KeyWrong { Reset, Remove, Add, None }
        public KeyWrong OnKeyWrong = KeyWrong.Reset;


        /// <summary>
        /// Checks case-sensitivity of the input when comparing to the words. Default is true.
        /// </summary>
        public bool CaseSensitive = true;


        /// <summary>
        /// Ignores numbers when true, does not count them as mistake when entered. Removes all numbers from words if they contain any.
        /// </summary>
        public bool IgnoreNumbers = false;


        /// <summary>
        /// Ignores punctuation when true, does not count them as mistake when entered. Removes all interpunction from words if they contain any.
        /// </summary>
        public bool IgnorePunctuation = false;


        /// <summary>
        /// Ignores space when true, does not count as mistake when entered. Removes all whitespaces from words if they contain any.
        /// </summary>
        public bool IgnoreSpace = false;


        /// <summary>
        /// Ignores special characters marks when true, converts all special characters if possible to standard characters.
        /// </summary>
        public bool IgnoreSpecialChar = true;


        /// <summary>
        /// Allow backspacing when typing a word has started. Note that backspacing will work for all the words in the list.
        /// </summary>
        public bool AllowBackspace = false;


        /// <summary>
        /// Remove the current word when the spacebar is pressed. Only works when IgnoreSpace is false. Note that when a list is used, all words will be removed when none of the words match.
        /// </summary>
        public bool RemoveOnSpace = false;


        /// <summary>
        /// Remove the a word when it is finished.
        /// </summary>
        public bool RemoveOnFinished = false;


        /// <summary>
        /// Updates all the requested words with the given char.
        /// </summary>
        /// <param name="letter">
        /// The letter that has been entered by the users of needs to be checked.
        /// </param>
        public virtual void TextInput(char letter)
        {
            PreviousChar = letter;
        }
        /// <summary>
        /// Updates all the requested words with the given char.
        /// </summary>
        /// <param name="letters">
        /// The characters that have been entered converted to char array and tested in that specific order.
        /// </param>
        public void TextInput(string letters)
        {
            if (letters.Equals("\b"))
            {
                if (AllowBackspace)
                {
                    Backspace();
                }
            }
            else
            {
                foreach (char ch in letters.ToCharArray())
                {
                    TextInput(ch);
                }
            }
        }


        /// <summary>
        /// Abstract methods when backspace is pressed.
        /// </summary>
        public abstract void Backspace();


        /// <summary>
        /// Checks the given word for the given letter.
        /// </summary>
        /// <param name="letter">
        /// The letter that was inputted by the user.
        /// </param>
        /// <param name="word">
        /// The word needs to be checked.
        /// </param>
        /// <param name="input">
        /// If set, checks a specific letterindex of the word. If not, it takes the current index and when necessary adjusts it.
        /// </param>
        /// <returns>
        /// If the letter matches the current typing index of the word.
        /// </returns>
        public bool CheckWord(char letter, Word word, int? input = null)
        {
            int index = input ?? word.Index;
            if (CheckIgnoredChars(letter))
            {
                if (input == null)
                {
                    bool ignoring = true;
                    while (ignoring && word.ValidIndex(index))
                    {
                        if (CheckIgnoredChars(word.Letters[index]))
                        {
                            index++;
                        }
                        else
                        {
                            ignoring = false;
                        }
                    }

                    if (ignoring)
                    {
                        word.Finished = true;
                        word.Correct = true;
                    }
                }
                return true;
            }

            if (word == null)
            {
                return false;
            }

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
                if (input == null)
                {
                    word.Correct = true;
                }

                word.Finished = true;
                return true;
            }

            bool result = letter == wordCharAtIndex;

            if (char.IsLetter(letter))
            {
                if (IgnoreSpecialChar)
                {
                    letter = ConvertSpecialChar(letter);
                    wordCharAtIndex = ConvertSpecialChar(wordCharAtIndex);
                }

                result = (CaseSensitive && letter == wordCharAtIndex) || (!CaseSensitive && char.ToLower(letter) == char.ToLower(wordCharAtIndex));
            }

            if (input == null)
            {
                word.Index = index + 1;
            }

            if (result && index == word.Letters.Length - 1)
            {
                word.Finished = true;
            }

            return result;
        }


        /// <summary>
        /// Checks if the given char should be ignored according to the given settings.
        /// </summary>
        /// <param name="ch">
        /// The chararacter that needs to be checked.
        /// </param>
        /// <returns>
        /// If the char should be ignored.
        /// </returns>
        private bool CheckIgnoredChars(char ch)
        {
            return (IgnoreNumbers && char.IsDigit(ch)) || (IgnoreSpace && char.IsWhiteSpace(ch)) || (IgnorePunctuation && char.IsPunctuation(ch));
        }


        /// <summary>
        /// Tries to convert a special character to a normal character.
        /// </summary>
        /// <param name="ch">
        /// The character to convert to normal.
        /// </param>
        /// <returns>
        /// If possible the converted char, otherwise it returns the given char.
        /// </returns>
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
