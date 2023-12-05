using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan
{
    struct InputOption
    {
        public string input { get; set; }
        public Action action { get; set; }

        public InputOption(string input, Action action) : this()
        {
            this.input = input;
            this.action = action;
        }
    }
}