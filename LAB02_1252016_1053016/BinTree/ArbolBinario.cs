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
        Nodo<T> DegeneratedOrBalanced(Nodo<T> nodo);
        List<Nodo<T>> PreOrder();
        List<Nodo<T>> InOrder();
        List<Nodo<T>> PostOrder();
        List<Nodo<T>> PreOrder(Nodo<T> node);
        List<Nodo<T>> InOrder(Nodo<T> node);
        List<Nodo<T>> PostOrder(Nodo<T> node);
    }
}
