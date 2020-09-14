using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using TreeCore;

namespace Edument.FileTree.Core.Entity
{
    /// <summary>
    /// An ITree implementation to use as a File Tree
    /// </summary>
    public class FileTree : ITree
    {
        public INode Root { get;}
        public FileTree(FileTreeNode root)
        {
            Root = root;
        }

        /// <summary>
        /// Adds a node to the tree. If the node's topmost dir does not already exist, it is added after the tree Root.
        /// If the node's topmost dir is found inside the tree, we repeat the process for every subsequent node/dir
        /// until we can't find it or we reach the filename.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(INode node)
        {
            var nodeChildren = ((FileTreeNode)node).GetAllChildren();
            var nodeToSearchFor = nodeChildren.First;
            FileTreeNode found = SearchAllNodes(nodeToSearchFor.Value.Value, (FileTreeNode)Root);
            if (found == null)
            {
                Root.AddChild(node);
            }
            else
            {
                var locatedNode = found;
                while (found != null && nodeToSearchFor.Next != null)
                {
                    found = SearchNextLevel(nodeToSearchFor.Next.Value.Value, locatedNode);
                    if (found != null)
                    {
                        locatedNode = found;
                    }
                    nodeToSearchFor = nodeToSearchFor.Next;
                }
                if (locatedNode.Children.Count != 0)
                {
                    locatedNode.AddChild(nodeToSearchFor.Value);
                }
            }
        }
        
        private FileTreeNode SearchAllNodes(string valueToSearchFor, FileTreeNode nodeToSearch)
        {
            if (nodeToSearch.Value == valueToSearchFor) return nodeToSearch;
            foreach (var child in nodeToSearch.Children)
            {
                var nodeFound = SearchAllNodes(valueToSearchFor, (FileTreeNode)child);
                if (nodeFound != null) return nodeFound;
            }
            return null;
        }

        private FileTreeNode SearchNextLevel(string valueToSearchFor, FileTreeNode nodeToSearch)
        {
            return (FileTreeNode)nodeToSearch.Children.FirstOrDefault(n => n.Value == valueToSearchFor);
        }
    }
}
