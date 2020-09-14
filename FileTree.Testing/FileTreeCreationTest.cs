using Edument.FileTree.Core;
using Edument.FileTree.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileTree.Testing
{
    [TestClass]
    public class FileTreeCreationTest
    {
        string[] filepaths_same_dirname = new string[]
        {   "marvel/marvel/black_widow/bw.png",
            "marvel/drdoom/the-doctor.png",
            "dc/marvel/character_list.txt",
         };
        
        string[] filepaths_nochildren = new string[]
        {   "marvel/black_widow/bw.png",
            "marvel/the-doctor.png",
            "character_list.txt",
         };
        
        [TestMethod]
        public void TestTreeSameDirName()
        {
            var fileTreeService = new FileTreeService(filepaths_same_dirname);
            var tree = fileTreeService.GetFileTree();
            Assert.IsTrue(tree.Root.Children.First.Value.Value == "marvel");
            //test marvel/marvel
            Assert.IsTrue(tree.Root.Children.First.Value.Value == tree.Root.Children.First.Value.Children.First.Value.Value);
            // test dc/marvel
            Assert.IsTrue(tree.Root.Children.Last.Value.Children.First.Value.Value == "marvel");
        }

        [TestMethod]
        public void TestTreeNoChildren()
        {
            var fileTreeService = new FileTreeService(filepaths_nochildren);
            var tree = fileTreeService.GetFileTree();
            Assert.IsTrue(tree.Root.Children.First.Value.Children.First.Value.Children.First.Value.Value == "bw.png");
            Assert.IsTrue(tree.Root.Children.First.Value.Children.First.Value.Children.First.Value.Children.Count == 0);
            
            Assert.IsTrue(tree.Root.Children.First.Value.Children.First.Value.Value == "the-doctor.png");
            Assert.IsTrue(tree.Root.Children.First.Value.Children.First.Value.Children.Count == 0);
            
            Assert.IsTrue(tree.Root.Children.Last.Value.Value == "character_list.txt");
            Assert.IsTrue(tree.Root.Children.Last.Value.Children.Count == 0);
        }
    }
}
