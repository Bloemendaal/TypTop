using System;
using System.Collections.Generic;
using System.Text;

namespace BasicGameEngine
{
    interface IResizable
    {
        public bool Relative { get; set; }

        void Resize();
    }
}
