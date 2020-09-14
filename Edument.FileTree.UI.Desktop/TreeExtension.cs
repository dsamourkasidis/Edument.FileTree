using Edument.FileTree.Core;
using Edument.FileTree.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using TreeCore;

namespace Edument.FileTree.UI.Desktop
{
    public static class TreeExtension
    {
        /// <summary>
        /// Convert FileTreeNode to a TreeNode windows forms control
        /// </summary>
        /// <param name="fileTreeNode"></param>
        /// <returns></returns>
        public static TreeNode ToTreeNode(this INode fileTreeNode) 
        {
            List<TreeNode> treeNodeChildren = new List<TreeNode>();
            foreach(var child in fileTreeNode.Children)
            {
                var childTreeNode = ((FileTreeNode)child).ToTreeNode();
                treeNodeChildren.Add(childTreeNode);
            }
            TreeNode treeNode = new TreeNode(fileTreeNode.Value, treeNodeChildren.ToArray());
            return treeNode;
        }
    }
}
