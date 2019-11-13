using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Game
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
        //     Ignores interpunction when true, does not count them as mistake when entered. Removes all interpunction from words if they contain any.
        public bool IgnoreInterpunction = false;


        //
        // Summary:
        //     Ignores space when true, does not count as mistake when entered. Removes all whitespaces from words if they contain any.
        public bool IgnoreSpace = false;


        //
        // Summary:
        //     Ignores punctuation marks when true, converts all characters with punctuation to standard characters.
        public bool IgnorePunctuation = true;


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
        public void Unsubscribe(MainWindow mainWindow) => mainWindow.TextInput -= TextInput;


        public void TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
        public void TextInput(char e)
        {

        }
    }
}
