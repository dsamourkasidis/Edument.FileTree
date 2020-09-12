using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Edument.FileTree.Core
{
    public class FileTree
    {
        public FileTreeNode Root { get;}
        public FileTree(FileTreeNode root)
        {
            Root = root;
        }

        internal void AddNode(FileTreeNode node)
        {
            var locatedNode = Root;
            var nodeValue = node.Value;
            var found = FindNodeWithValue(nodeValue, Root);
            while (found != null)
            {

            }


            if (locatedNode == null)
            {
                Root.AddChild(node);
            }
            else
            {
                locatedNode.AddChild(node.Children.First());
            }
        }
        
        private FileTreeNode FindNodeWithValue(string value, FileTreeNode parent)
        {
            if (parent.Value == value) return parent;
            foreach (var child in parent.Children)
            {
                var nodeFound = FindNodeWithValue(value, child);
                return nodeFound;
            }
            return null;
        }
    }
}
