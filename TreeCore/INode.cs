using System;
using System.Collections.Generic;
using System.Text;

namespace TreeCore
{
    interface INode
    {
        public INode Parent { get; set; }
        public List<INode> Children { get; set; }

    }
}
