using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Utilities
{
    public class Task1Exception : Exception
    {
        public Task1Exception()
        {
        }

        public Task1Exception(string message)
            : base(message)
        {
        }

        public Task1Exception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}