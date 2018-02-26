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
        void Insert(T value, Nodo<T> node);
        void Delete(T value);
        void Delete(T value, Nodo<T> node);
        bool Contains(T llave);
        T Obtain(T llave);
        List<T> DegeneratedOrBalanced(bool balance);
        void PreOrder();
        void InOrder();
        void PostOrder();
    }
}
