﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_V1
{
    /*
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public Node()
        {

        }
        public Node(int data)
        {
            this.Data = data;

        }
    }
    public class BinaryTree
    {
        private Node _root;
        public BinaryTree()
        {
            _root = null;
        }
        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                
            }
                

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                    
                }
                else
                {
                    InsertRec(root.Left, newNode);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                
                }
                else
                {
                    InsertRec(root.Right, newNode);
                }
                    
            }
        }

        private void DisplayTree(Node root)
        {
            if (root == null) return;
            DisplayTree(root.Left);
            Console.WriteLine(root.Data + " ");
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {

            DisplayTree(_root);
        }

    }
    */
}
