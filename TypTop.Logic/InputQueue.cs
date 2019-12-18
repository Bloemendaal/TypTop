using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    public class InputQueue : Input
    {
        public Queue<Word> Input;
        public InputQueue(Queue<Word> input)
        {
            Input = input;
        }


        public override void TextInput(char letter)
        {
            Word input = Input?.Peek();
            int index = input.Index;

            if (input != null)
            {
                if (CheckWord(letter, input))
                {
                    input?.Input.Push(letter);
                }
                else
                {
                    if (OnKeyWrong == KeyWrong.Reset)
                    {
                        input.Input.Clear();
                        input.Index = 0;
                        input.Finished = false;
                        input.Correct = null;
                    }

                    if (OnKeyWrong == KeyWrong.Remove)
                    {
                        Input?.Dequeue();
                    }

                    if (OnKeyWrong == KeyWrong.Add)
                    {
                        input.Input.Push(letter);
                        input.Finished = false;
                        input.Correct = false;
                    }

                    if (OnKeyWrong == KeyWrong.None)
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

            if (RemoveOnFinished)
            {
                Input = new Queue<Word>(Input.Where(e => !e.Finished));
            }

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
