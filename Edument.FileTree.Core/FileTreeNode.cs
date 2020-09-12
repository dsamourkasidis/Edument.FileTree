using System;
using System.Collections.Generic;
using System.Text;

namespace Edument.FileTree.Core
{
    public class FileTreeNode : IComparable
    {
        public string Value { get;}
        public LinkedList<FileTreeNode> Children { get;}
        public FileTreeNode Parent { get; }
        public FileTreeNode(string value, FileTreeNode parent)
        {
            Value = value;
            Parent = parent;
            Children = new LinkedList<FileTreeNode>();
        }
        public FileTreeNode(string value, FileTreeNode parent, LinkedList<FileTreeNode> children)
        {
            Value = value;
            Parent = parent;
            Children = children;
        }

        public FileTreeNode(string value)
        {
            Value = value;
            Parent = null;
            Children = new LinkedList<FileTreeNode>();
        }

        public void AddChild(FileTreeNode node)
        {
            Children.AddLast(node);
        }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(((FileTreeNode)obj).Value);
        }
    }
}
