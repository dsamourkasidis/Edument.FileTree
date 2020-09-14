using Edument.FileTree.Core.Entity;
using System;
using System.Text;

namespace Edument.FileTree.Core
{
    /// <summary>
    /// Gets an array of filepaths and constructs a tree from them
    /// </summary>
    class FileTreeProcessor
    {
        private const string ROOT = "Root";
        internal string[] Filepaths { get; }
        internal FileTreeProcessor(string[] filepaths)
        {
            Filepaths = filepaths;
        }

        internal Entity.FileTree CreateFileTree()
        {
            var firstNode = new FileTreeNode(ROOT);
            var tree = new Entity.FileTree(firstNode);
            foreach(var filepath in Filepaths)
            {
                var node = ProcessFilepath(filepath);
                tree.AddNode(node);
            }
            return tree;
        }

        /// <summary>
        /// Creates a FileTreeNode from a filepath by spliting on '/'. Each directory is a child node of the parent dir node
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private Entity.FileTreeNode ProcessFilepath(string filepath)
        {
            var dirs = filepath.Split('/');
            var node = new FileTreeNode(dirs[0]);
            var parentNode = node;
            if (dirs.Length == 1) return node;
            for(int i = 1; i < dirs.Length; i++)
            {
                var newNode = new FileTreeNode(dirs[i], parentNode);
                parentNode.AddChild(newNode);
                parentNode = (FileTreeNode)parentNode.Children.Last.Value;
            }
            return node;
        }
    }
}
