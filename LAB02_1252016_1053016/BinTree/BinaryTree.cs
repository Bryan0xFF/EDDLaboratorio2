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
        public Nodo<T> cabeza;
        private static List<Nodo<T>> inOrden = new List<Nodo<T>>();
        private static List<Nodo<T>> preOrden=  new List<Nodo<T>>();
        private static List<Nodo<T>> postOrden = new List<Nodo<T>>();

        public BinaryTree()
        {            
            cabeza = new Nodo<T>();
        }

        public bool Contains(T llave)
        {
            throw new NotImplementedException();
        }

        public Nodo<T> DegeneratedOrBalanced(Nodo<T> nodo)
        {
            int L = Height(nodo.Left);
            int R = Height(nodo.Right);
            int diference = Math.Abs(L - R);
            Nodo<T> desbalance = null;           

            if (diference > 1)
            {
                if (L > R)
                {
                    while (nodo.Left != null)
                    {
                        nodo = nodo.Left;
                        desbalance = nodo;                       
                    }
                    return desbalance;
                }
                else if (R > L)
                {
                    while (nodo.Right != null)
                    {
                        nodo = nodo.Right;
                        desbalance = nodo;
                       
                    }
                    return desbalance; 
                }
                else
                {
                    while (nodo.Right != null)
                    {
                        nodo = nodo.Right;
                        desbalance = nodo;
                    }
                    return desbalance;
                }              
            }
            else
                return null;       
             
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

        public List<Nodo<T>> InOrder()
        {
            return InOrder(cabeza);
        }

        public void Insert(T value)
        {
            Insert(value, cabeza);
        }

        public Nodo<T> Insert(T value, Nodo<T> node)
        {
            
            if (cabeza.Value == null)
            {
                cabeza.Value = value;
                return cabeza;
            }

            if (cabeza.Value.CompareTo(value) == 0)
            {
                cabeza.Value = value;
                return cabeza;
            }

            else if (node == null)
            {
                node = new Nodo<T>();
                node.Value = value;
            }
            else
            {
                if (node.Value.CompareTo(value) > 0)
                {
                   // node = new Nodo<T>();                   
                    node.Left = Insert(value, node.Left);
                    node.Left.Parent = node;
                    return node;
                }
                if (node.Value.CompareTo(value) < 0)
                {
                   // node = new Nodo<T>();                  
                    node.Right = Insert(value, node.Right);
                    node.Right.Parent = node;
                    return node;
                }
                else
                {
                    throw new InvalidOperationException("Ya contiene una llave igual");
                }
            }
            return node;
        }

        public T Obtain(T llave)
        {
            throw new NotImplementedException();
        }

        public List<Nodo<T>> PostOrder()
        {
            return PostOrder(cabeza);
        }

        public List<Nodo<T>> PreOrder()
        {
            return PreOrder(cabeza);
        }

        public int Height(Nodo<T> nodo)
        {
          int height = 0;
            
          if (nodo != null)
            {
                int L = Height(nodo.Left);
                int R = Height(nodo.Right);
                int Max = Math.Max(L, R);
                height = Max + 1;
            }
            return height;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<Nodo<T>> PreOrder(Nodo<T> node)
        {
            if (node != null)
            {
                preOrden.Add(node);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
            return preOrden;
        }

        public List<Nodo<T>> InOrder(Nodo<T> node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                inOrden.Add(node);
                InOrder(node.Right);
            }
            return inOrden;
        }

        public List<Nodo<T>> PostOrder(Nodo<T> node)
        {
            if (node != null)
            {
                PostOrder(node.Left);
                PostOrder(node.Right);
                postOrden.Add(node);
            }
            return postOrden;
        }

        public bool Limpiar()
        {
            try
            {
                inOrden.Clear();
                preOrden.Clear();
                postOrden.Clear();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Nodo<T> Search(Nodo<T> nodo, T value)
        {
            if (nodo == null)
                return null;
            else if (nodo.Value.CompareTo(value) == 0)        
                return nodo;
            
            else if (nodo.Value.CompareTo(value) > 0)
                Search(nodo.Left, value);
            else if (nodo.Value.CompareTo(value) < 0)
                Search(nodo.Right, value);
            return nodo;
        }      
    }
}
