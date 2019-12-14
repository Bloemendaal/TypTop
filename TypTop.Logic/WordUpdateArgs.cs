using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.Logic
{
    public class WordUpdateArgs : EventArgs
    {
        public List<Word> Words;

        /// <summary>
        /// The previously inputted letter with the TextInput function.
        /// </summary>
        public char PreviousChar;

        /// <summary>
        /// The currently inputted letter with the TextInput function.
        /// </summary>
        public char CurrentChar;
    }
}
