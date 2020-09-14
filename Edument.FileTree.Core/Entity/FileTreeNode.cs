using System;
using System.Collections.Generic;
using System.Text;
using TreeCore;

namespace Edument.FileTree.Core.Entity
{
    /// <summary>
    /// An INode implementation to use as a File TreeNode
    /// </summary>
    public class FileTreeNode : INode
    {
        public string Value { get;}
        public LinkedList<INode> Children { get; }
        public INode Parent { get; private set; }

        public FileTreeNode(string value, FileTreeNode parent)
        {
            Value = value;
            Parent = parent;
            Children = new LinkedList<INode>();
        }
        
        public FileTreeNode(string value)
        {
            Value = value;
            Parent = null;
            Children = new LinkedList<INode>();
        }
        public void AddChild(INode child)
        {
            ((FileTreeNode)child).Parent = this;
            Children.AddLast(child);
        }

        /// <summary>
        /// Recursively gather every child in a single list
        /// </summary>
        /// <returns></returns>
        internal LinkedList<FileTreeNode> GetAllChildren()
        {
            var children = new LinkedList<FileTreeNode>();
            children.AddLast(this);
            foreach(var child in Children)
            {
                if (child.Children.Count > 0)
                {
                    foreach(var grandchild in ((FileTreeNode)child).GetAllChildren())
                    {
                        children.AddLast(grandchild);
                    }
                }
                else
                {
                    children.AddLast((FileTreeNode)child);
                }
            }
            return children;
        }

    }
}
