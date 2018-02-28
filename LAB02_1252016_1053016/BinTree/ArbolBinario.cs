using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    internal interface ArbolBinario<T>
    {
        void Insert(T value);
        Nodo<T> Insert(T value, Nodo<T> node);
        void Delete(T value);
        void Delete(T value, Nodo<T> node);
        bool Contains(T llave);
        T Obtain(T llave);
       string DegeneratedOrBalanced(Nodo<T> nodo);
        List<T> PreOrder();
        List<T> InOrder();
        List<T> PostOrder();
    }
}
