using System;
using System.Collections.Generic;
using System.Linq;

namespace TypTop.Logic
{
    public class InputWord : Input
    {
        public Word Input;

        public InputWord(Word input)
        {
            Input = input;
        }


        public override void TextInput(char letter)
        {
            var index = Input.Index;

            if (CheckWord(letter, Input))
            {
                Input.Input.Push(letter);
            }
            else
            {
                if (OnKeyWrong == KeyWrong.Reset)
                {
                    Input.Input.Clear();
                    Input.Index = 0;
                    Input.Finished = false;
                    Input.Correct = null;
                }

                if (OnKeyWrong == KeyWrong.Remove) Input = null;

                if (OnKeyWrong == KeyWrong.Add)
                {
                    Input.Input.Push(letter);
                    Input.Finished = false;
                    Input.Correct = false;
                }

                if (OnKeyWrong == KeyWrong.None) Input.Index = index;
            }

            WordUpdate?.Invoke(this, new WordUpdateArgs
            {
                Words = new List<Word>(),
                PreviousChar = PreviousChar,
                CurrentChar = letter
            });

            if (RemoveOnFinished && Input.Finished) Input = null;

            base.TextInput(letter);
        }

        public override void Backspace()
        {
            Input?.Backspace();

            var correct = true;
            for (var i = 0; i < Input.Input.Count; i++)
                if (!CheckWord(Input.Input.ElementAt(i), Input, i))
                {
                    correct = false;
                    break;
                }

            Input.Correct = correct;
        }

        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}