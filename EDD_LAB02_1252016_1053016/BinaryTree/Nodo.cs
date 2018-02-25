using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Nodo<T>
    {
        public Nodo<T> Left { get; set; }
        public Nodo<T> Right { get; set; }
        public T Value { get; set; }

    }
}
