***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    class Word
    ***REMOVED***
        //
        // Summary:
        //     Index of the character that is currently being checked by the program.
        public int Index
        ***REMOVED***
            get => _index;
            set
            ***REMOVED***
                _index = value;
                if (_index >= Letters.Length)
                ***REMOVED***
                    _index = Letters.Length - 1;
            ***REMOVED***
                if (_index < 0)
                ***REMOVED***
                    _index = 0;
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
        private int _index = 0;


        //
        // Summary:
        //     The word saved as a string.
        public string Letters ***REMOVED*** get; private set; ***REMOVED***


        //
        // Summary:
        //     Gives the input given by the user for this word.
        public Stack<char> Input ***REMOVED*** get; set; ***REMOVED***


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
        ***REMOVED***
            Letters = letters;
    ***REMOVED***


        //
        // Summary:
        //     Checks if the given index is valid for this word.
        // Returns:
        //     True if valid.
        public bool ValidIndex(int index)
        ***REMOVED***
            return index >= 0 && index < Letters.Length;
    ***REMOVED***


        //
        // Summary:
        //     Removes the last character from the Input and lowers the input by one
        public void Backspace()
        ***REMOVED***
            Input.Pop();
            Index--;
    ***REMOVED***


        public override string ToString() => Letters;
***REMOVED***
***REMOVED***
