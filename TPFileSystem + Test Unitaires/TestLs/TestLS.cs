using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFileSystem;

namespace TestLs
{
    [TestClass]
    public class TestLS
    {
        [TestMethod]
        public void TestMethodLs()
        {
            Directory Fichier = new Directory("test", null);
            Directory dedans = new Directory("coucou", Fichier);
            Assert.AreEqual(Fichier.Fichiers.Count, 1);
        }
    }
}
