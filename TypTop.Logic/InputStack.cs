using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    public class InputStack : Input
    {
        public Stack<Word> Input;
        public InputStack(Stack<Word> input)
        {
            Input = input;
        }


        public override void TextInput(char letter)
        {
            Word input = Input?.Peek();
            int index = input.Index;

            if (char.IsWhiteSpace(letter))
            {
                Input?.Pop();
                return;
            }

            if (input != null)
            {
                if (CheckWord(letter, input))
                {
                    input?.Input.Push(letter);
                }
                else
                {
                    if (OnKeyWrong == KeyWrong.reset)
                    {
                        input.Input.Clear();
                        input.Index = 0;
                        input.Finished = false;
                        input.Correct = null;
                    }

                    if (OnKeyWrong == KeyWrong.remove)
                    {
                        Input?.Pop();
                    }

                    if (OnKeyWrong == KeyWrong.add)
                    {
                        input.Input.Push(letter);
                        input.Finished = false;
                        input.Correct = false;
                    }

                    if (OnKeyWrong == KeyWrong.none)
                    {
                        input.Index = index;
                    }
                }
            }

            WordUpdate?.Invoke(this, new WordUpdateArgs()
            {
                Words = new List<Word>(),
                PreviousChar = PreviousChar,
                CurrentChar = letter
            });

            base.TextInput(letter);
        }
        public override void Backspace()
        {
            Word input = Input?.Peek();
            input?.Backspace();

            bool correct = true;
            for (int i = 0; i < input.Input.Count; i++)
            {
                if (!CheckWord(input.Input.ElementAt(i), input, i))
                {
                    correct = false;
                    break;
                }
            }

            input.Correct = correct;
        }
        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}
