using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFileSystem;

namespace TestMkdir
{
    [TestClass]
    public class Testmkdir
    {
        [TestMethod]
        public void TestMkdir()
        {
            Directory fichier = new Directory("test", null);
            Assert.IsTrue(fichier.mkdir("test"));
            Assert.IsTrue(fichier.Fichiers.Count == 1);
        }
    }
}
