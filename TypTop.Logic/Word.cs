using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    class Word
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
        public string Letters { get; private set; }


        //
        // Summary:
        //     Gives if the word was correctly typed.
        // Returns:
        //     If the word was typed correctly unless the typing has not yet started.
        public bool? Correct = null;


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


        public override string ToString() => Letters;
    }
}
