using System.Collections.Generic;

namespace TypTop.Logic
{
    public class Word
    {
        private int _index;
        private string _letters;


        /// <summary>
        ///     Gives if the word was correctly typed until the current index. Returns if the word was typed correctly unless the
        ///     typing has not yet started.
        /// </summary>
        public bool? Correct = null;


        /// <summary>
        ///     Gives if the word was completely correctly typed. Returns if the word was correctly typed.
        /// </summary>
        public bool Finished = false;


        public Word(string letters)
        {
            Letters = letters;
        }

        /// <summary>
        ///     Index of the character that is currently being checked by the program.
        /// </summary>
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                if (_index >= Letters.Length) _index = Letters.Length - 1;
                if (_index < 0) _index = 0;
            }
        }


        /// <summary>
        ///     The word saved as a string.
        /// </summary>
        public string Letters
        {
            get => _letters;
            set => _letters = value.Trim();
        }


        /// <summary>
        ///     Gives the input given by the user for this word.
        /// </summary>
        public Stack<char> Input { get; } = new Stack<char>();


        /// <summary>
        ///     Checks if the given index is valid for this word.
        /// </summary>
        /// <param name="index">
        ///     Index of the letter in this word.
        /// </param>
        /// <returns>
        ///     True if valid.
        /// </returns>
        public bool ValidIndex(int index)
        {
            return index >= 0 && index < Letters.Length;
        }


        /// <summary>
        ///     Removes the last character from the Input and lowers the input by one
        /// </summary>
        public void Backspace()
        {
            Input.Pop();
            Index--;
        }


        public override string ToString()
        {
            return Letters;
        }

        public override bool Equals(object obj)
        {
            if (obj is Word word) return word.Letters != null && Letters != null && word.Letters.Equals(Letters);

            return false;
        }
    }
}