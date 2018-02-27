using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    public class BinaryTree<T> : ArbolBinario<T>,IEnumerable<T> where T : IComparable<T>
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

        public void Delete(T value)
        {
            Delete(value, cabeza);
        }

        public void Delete(T value, Nodo<T> node)
        {
            Nodo<T> Min;
            if (value == null)
            {
                throw new NullReferenceException();
            }

            else if (value.CompareTo(node.Value) == -1)
            {
                Delete(value, node.Left);
            } //look in the left

            else if (value.CompareTo(node.Value) > 0)
            {
                Delete(value, node.Right);
            } //look in the right

            else
            { //found node to delete

                if (node.Left != null && node.Right != null) //two children
                {
                    Min = FindMin(node.Right);
                    node.Value = Min.Value;
                    Delete(node.Value, node.Right);

                }

                else
                { //one or zero child

                    if (node.Left == null)//The root node is to be deleted
                    {
                        if (node.Parent == null)
                        {
                            cabeza = node.Right;
                        }
                        else
                        {
                            if (node.Right != null)
                            {
                                node.Right.Parent = node.Parent;
                            }

                            if (node == node.Parent.Left)
                            {
                                node.Parent.Left = node.Right;
                            }

                            else
                            {
                                node.Parent.Right = node.Right;
                            }
                        }

                    }
                    else if (node.Right == null)
                    {
                        if (node.Parent == null)
                        {
                            cabeza = node.Left;
                        }
                        else
                        {

                            node.Left.Parent = node.Parent;

                            if (node == node.Parent.Left)
                            {
                                node.Parent.Left = node.Left;
                            }
                            else
                            {
                                node.Parent.Right = node.Left;
                            }
                        }
                    }
                }
            }
        }

        public Nodo<T> FindMin(Nodo<T> root)
        {
            if (root == null)
            {
                return null;
            }

            else if (root.Left == null)
            {
                return root;
            }

            else
            {
                return FindMin(root.Left);
            }
        }

        private bool isLeaf(Nodo<T> node)
        {
            if (node.Left == null && node.Right == null)
            {
                return true;
            }
            return false;
        }

        public List<T> InOrder()
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
            if (node == null)
            {
                node = new Nodo<T>();
                node.Value = value;
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

        public List<T> PostOrder()
        {
            throw new NotImplementedException();
        }

        public List<T> PreOrder()
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
