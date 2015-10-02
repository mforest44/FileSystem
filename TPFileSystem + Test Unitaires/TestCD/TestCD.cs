using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFileSystem;

namespace TestCD
{
    [TestClass]
    public class TestCD
    {
        [TestMethod]
        public void MethodTestCd()
        {
            Directory fichier = new Directory("test", null);
            Assert.AreEqual("test", fichier.Nom);
            
        }
    }
}
