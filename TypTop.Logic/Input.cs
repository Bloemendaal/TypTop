***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    abstract class Input
    ***REMOVED***
        //
        // Summary:
        //     The previously inputted letter with the TextInput function.
        public char PreviousChar ***REMOVED*** get; private set; ***REMOVED***


        //
        // Summary:
        //     Fires when words have been updated
        public abstract event EventHandler<WordUpdateArgs> WordUpdate;


        //
        // Summary:
        //     What does the program do when the users inputs a wrong key.
        // Parameters:
        //     reset:
        //       Default. Resets the current typing progress of the word.
        //     remove:
        //       Remove the current word, note that a list only removes a word when the key is wrong after typing has started.
        //     add:
        //       Adds the wrong character to the stack. User needs to backspace it to remove the wrong letter.
        //     none:
        //       Ignores the mistake and keeps the current typing progress of the word.
        public enum KeyWrong ***REMOVED*** reset, remove, add, none ***REMOVED***
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
        //     Updates all the requested words with the given char.
        // Parameters:
        //     letter:
        //        The letter that has been entered by the users of needs to be checked.
        //     letters:
        //        The characters that have been entered converted to char array and tested in that specific order.
        public virtual void TextInput(char letter)
        ***REMOVED***
            PreviousChar = letter;
    ***REMOVED***
        public void TextInput(string letters)
        ***REMOVED***
            if (letters.Equals("\b"))
            ***REMOVED***
                if (AllowBackspace)
                ***REMOVED***
                    Backspace();
            ***REMOVED***
        ***REMOVED***
            else
            ***REMOVED***
                foreach (char ch in letters.ToCharArray())
                ***REMOVED***
                    TextInput(ch);
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***


        //
        // Summary:
        //     Abstract methods when backspace is pressed
        public abstract void Backspace();
       

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
        public bool CheckWord(char letter, Word word, int? input = null)
        ***REMOVED***
            if (CheckIgnoredChars(letter))
            ***REMOVED***
                return true;
        ***REMOVED***

            if (word == null)
            ***REMOVED***
                return false;
        ***REMOVED***

            int index = input == null ? word.Index : (int)input;
            char wordCharAtIndex = word.Letters[index];

            bool wrongChar = true;
            while (wrongChar && word.ValidIndex(index))
            ***REMOVED***
                wordCharAtIndex = word.Letters[index];

                if (CheckIgnoredChars(wordCharAtIndex))
                ***REMOVED***
                    index++;
                    continue;
            ***REMOVED***

                wrongChar = false;
        ***REMOVED***

            if (index >= word.Letters.Length)
            ***REMOVED***
                if (input == null)
                ***REMOVED***
                    word.Correct = true;
            ***REMOVED***

                word.Finished = true;
                return true;
        ***REMOVED***

            bool result = letter == wordCharAtIndex;

            if (char.IsLetter(letter))
            ***REMOVED***
                if (IgnoreSpecialChar)
                ***REMOVED***
                    letter = ConvertSpecialChar(letter);
                    wordCharAtIndex = ConvertSpecialChar(wordCharAtIndex);
            ***REMOVED***

                result = (CaseSensitive && letter == wordCharAtIndex) || (!CaseSensitive && char.ToLower(letter) == char.ToLower(wordCharAtIndex));
        ***REMOVED***

            if (input == null)
            ***REMOVED***
                word.Index = index;
        ***REMOVED***

            if (result && index == word.Letters.Length - 1)
            ***REMOVED***
                word.Finished = true;
        ***REMOVED***

            return result;
    ***REMOVED***


        //
        // Summary:
        //     Checks if the given char should be ignored according to the given settings.
        // Returns:
        //     If the char should be ignored.
        private bool CheckIgnoredChars(char ch)
        ***REMOVED***
            return (IgnoreNumbers && char.IsDigit(ch)) || (IgnoreSpace && char.IsWhiteSpace(ch)) || (IgnorePunctuation && char.IsPunctuation(ch));
    ***REMOVED***


        //
        // Summary:
        //     Tries to convert a special character to a normal character.
        // Returns:
        //     If possible the converted char, otherwise it returns the given char.
        // Parameters:
        //     ch:
        //       The charater to convert to normal.
        private static char ConvertSpecialChar(char ch)
        ***REMOVED***
            char[] from = "àèìòùÀÈÌÒÙ äëïöüÄËÏÖÜ âêîôûÂÊÎÔÛ áéíóúÁÉÍÓÚðÐýÝ ãñõÃÑÕšŠžŽçÇåÅøØ".ToCharArray();
            char[] to   = "aeiouAEIOU aeiouAEIOU aeiouAEIOU aeiouAEIOUdDyY anoANOsSzZcCaAoO".ToCharArray();

            for (int i = 0; i < from.Length; i++)
            ***REMOVED***
                if (ch == from[i])
                ***REMOVED***
                    return to[i];
            ***REMOVED***
        ***REMOVED***

            return ch;
    ***REMOVED***
***REMOVED***
***REMOVED***
