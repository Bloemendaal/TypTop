using System;
using System.Collections.Generic;
using System.Text;

namespace TypTop.Logic
{
    class WordUpdateArgs : EventArgs
    {
        public List<Word> Words;

        //
        // Summary:
        //     The previously/currently inputted letter with the TextInput function.
        public char PreviousChar;
        public char CurrentChar;
    }
}
