using System;
using System.Collections.Generic;

namespace TypTop.Logic
{
    public class WordUpdateArgs : EventArgs
    {
        /// <summary>
        ///     The currently inputted letter with the TextInput function.
        /// </summary>
        public char CurrentChar;

        /// <summary>
        ///     The previously inputted letter with the TextInput function.
        /// </summary>
        public char PreviousChar;

        public List<Word> Words;
    }
}