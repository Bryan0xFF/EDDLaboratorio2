using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree<T> : ArbolBinario<T>,IEnumerable<T> where T : IComparable<T>
    {
        public List<T> DegeneratedOrBalanced(bool balance)
        {
            throw new NotImplementedException();
        }

        public T Delete(T value)
        {
            throw new NotImplementedException();
        }

        public T Delete(T value, Nodo<T> node)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void InOrder()
        {
            throw new NotImplementedException();
        }

        public T Insert(T value)
        {
            throw new NotImplementedException();
        }

        public T Insert(T value, Nodo<T> node)
        {
            throw new NotImplementedException();
        }

        public void PostOrder()
        {
            throw new NotImplementedException();
        }

        public void PreOrder()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
