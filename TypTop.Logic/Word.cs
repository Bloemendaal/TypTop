using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    public class Word
    {
        //
        // Summary:
        //     Index of the character that is currently being checked by the program.
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                if (_index >= Letters.Length)
                {
                    _index = Letters.Length - 1;
                }
                if (_index < 0)
                {
                    _index = 0;
                }
            }
        }
        private int _index = 0;


        //
        // Summary:
        //     The word saved as a string.
        public string Letters { get; set; }


        //
        // Summary:
        //     Gives the input given by the user for this word.
        public Stack<char> Input { get; private set; } = new Stack<char>();


        //
        // Summary:
        //     Gives if the word was correctly typed until the current index.
        // Returns:
        //     If the word was typed correctly unless the typing has not yet started.
        public bool? Correct = null;


        //
        // Summary:
        //     Gives if the word was completely correctly typed.
        // Returns:
        //     If the word was correctly typed.
        public bool Finished = false;


        public Word(string letters)
        {
            Letters = letters;
        }


        //
        // Summary:
        //     Checks if the given index is valid for this word.
        // Returns:
        //     True if valid.
        public bool ValidIndex(int index)
        {
            return index >= 0 && index < Letters.Length;
        }


        //
        // Summary:
        //     Removes the last character from the Input and lowers the input by one
        public void Backspace()
        {
            Input.Pop();
            Index--;
        }


        public override string ToString() => Letters;
        public override bool Equals(object obj)
        {
            if (obj is Word word)
            {
                return word.Letters != null && Letters != null && word.Letters.Equals(Letters);
            }

            return false;
        }
    }
}
