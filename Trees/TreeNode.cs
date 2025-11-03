
using System;
using System.Collections.Generic;
using System.Linq;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects

        List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            this.Value = value;


        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below

            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children[childIndex];
                output += child.ToString(depth + 1, childIndex);
            }
            return output;


        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> nuevoNodo = new TreeNode<T>(value);
            Children.Add(nuevoNodo);

            return nuevoNodo;

        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree

            int contador = 1;

            foreach (TreeNode<T> child in Children)
            {
                contador = contador + child.Count();

            }


            return contador;

        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            int alturaMaxima = 0;

            if (Children.Count() == 0)
            {
                return 0;
            }

            foreach (TreeNode<T> child in Children)
            {

                int alturaRama = child.Height();

                if (alturaRama > alturaMaxima)
                {
                    alturaMaxima = alturaRama;
            
                }
            }
          
            return 1 + alturaMaxima;
        }




        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively

            for (int i = 0; i < Children.Count; i++)
            {
                TreeNode<T> child = Children[i];

                if (child.Value.Equals(value))
                {

                    Children.Remove(child);
                }

                child.Remove(value);

            }


        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            if (this.Value.Equals(value))
            {
                return this;
            }
            for (int i= 0; i < Children.Count; i++)
            {
                TreeNode<T> objetivo = Children[i];


                TreeNode<T> temporal = objetivo.Find(value);

                if (temporal != null)
                {
                    return temporal;
                }
            }
            
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value

            for (int i= 0; i < Children.Count; i++)
            {
                if (Children[i].Equals(node))
                {
                    Children.Remove(node);
                }
                else
                {
                    Children[i].Remove(node);
                }
            }
            
        }
    }
}