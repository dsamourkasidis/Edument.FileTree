using Edument.FileTree.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileTree.Testing
{
    [TestClass]
    public class UnitTest1
    {
        string[] filepaths = new string[]{"marvel/black_widow/bw.png",
                              "marvel/drdoom/the-doctor.png",
                              "fact_marvel_beats_dc.txt",
                              "dc/aquaman/mmmmmomoa.png",
                              "marvel/black_widow/why-the-widow-is-awesome.txt",
                              "dc/aquaman/movie-review-collection.txt",
                              "marvel/marvel_logo.png",
                              "dc/character_list.txt" };

        string[] filepaths2 = new string[]{"marvel/black_widow/bw.png",
                              "marvel/drdoom/the-doctor.png",
                               };
        [TestMethod]
        public void TestMethod1()
        {
            var filepathProcessor = new FileListProcessor(filepaths);
            var tree = filepathProcessor.CreateFileTree();
        }
    }
}
