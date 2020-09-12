using System;
using System.Text;

namespace Edument.FileTree.Core
{
    public class FileListProcessor
    {
        private const string ROOT = "Root";
        public string[] Filepaths { get; }
        public FileListProcessor(string[] filepaths)
        {
            Filepaths = filepaths;
        }

        public FileTree CreateFileTree()
        {
            var firstNode = new FileTreeNode(ROOT);
            var tree = new FileTree(firstNode);
            foreach(var filepath in Filepaths)
            {
                var node = ProcessFilepath(filepath);
                tree.AddNode(node);
            }
            return null;
        }

        private FileTreeNode ProcessFilepath(string filepath)
        {
            var dirs = filepath.Split('/');
            var node = new FileTreeNode(dirs[0]);
            var parentNode = node;
            if (dirs.Length == 1) return node;
            for(int i = 1; i < dirs.Length; i++)
            {
                var newNode = new FileTreeNode(dirs[i], parentNode);
                parentNode.AddChild(newNode);
                parentNode = node.Children.Last.Value;
            }
            return node;
        }
    }
}
