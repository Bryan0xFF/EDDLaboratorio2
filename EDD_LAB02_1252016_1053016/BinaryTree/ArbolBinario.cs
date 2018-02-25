using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal interface ArbolBinario<T>
    {
        T Insert(T value);
        T Insert(T value, Nodo<T> node);
        T Delete(T value);
        T Delete(T value, Nodo<T> node);
        List<T> DegeneratedOrBalanced(bool balance);
        void PreOrder();
        void InOrder();
        void PostOrder();
    }
}
