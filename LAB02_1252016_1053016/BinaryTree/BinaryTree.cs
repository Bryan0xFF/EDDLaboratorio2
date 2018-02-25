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
        private Nodo<T> cabeza;

        public BinaryTree()
        {
            cabeza = default(Nodo<T>);
        }

        public bool Contains(T llave)
        {
            throw new NotImplementedException();
        }

        public List<T> DegeneratedOrBalanced(bool balance)
        {
            throw new NotImplementedException("Alex Implementar");
        }

        public T Delete(T value)
        {
            throw new NotImplementedException();
        }

        public T Delete(T value, Nodo<T> node)
        {
            throw new NotImplementedException();
        }

       

        public void InOrder()
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            Insert(value, cabeza);
        }

        public void Insert(T value, Nodo<T> node)
        {
            
            if (cabeza == null)
            {
                cabeza.Value = value;
            }
            else
            {
                if (node.Value.CompareTo(value) > 0)
                {
                    node.Left.Parent = node;
                    Insert(value, node.Left);
                }
                if (node.Value.CompareTo(value) < 0)
                {
                    node.Right.Parent = node;
                    Insert(value, node.Right);
                }
                else
                {
                    throw new InvalidOperationException("Ya contiene una llave igual");
                }
            }
        }

        public T Obtain(T llave)
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
