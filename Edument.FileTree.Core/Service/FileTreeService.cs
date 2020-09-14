using Edument.FileTree.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edument.FileTree.Core.Service
{
    /// <summary>
    /// Service for exposing and accessing all File Tree functionalities.
    /// Can be used by all other components, e.g. a Desktop app, a web app, a Web API etc.
    /// </summary>
    public class FileTreeService
    {
        private FileTreeProcessor fileTreeProcessor;
        public FileTreeService(string[] filepaths)
        {
            fileTreeProcessor = new FileTreeProcessor(filepaths);
        }

        public Entity.FileTree GetFileTree()
        {
            var tree = fileTreeProcessor.CreateFileTree();
            return tree;
        }


    }
}
