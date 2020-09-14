using System;
using System.Collections.Generic;

namespace TreeCore
{
    // A bit overengineered but could be used for any kind of tree not only filetrees
    public interface ITree
    {
        public INode Root { get;}
        void AddNode(INode node);
    }
}
