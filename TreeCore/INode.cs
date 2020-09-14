using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    // A bit overengineered but could be used for any kind of treenode not only file treenodes
    public interface INode
    {
        public INode Parent { get; }
        public LinkedList<INode> Children { get; }
        public void AddChild(INode child);
        public string Value { get; }
    }
}
