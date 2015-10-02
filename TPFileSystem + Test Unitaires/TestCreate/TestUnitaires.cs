using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFileSystem;

namespace TestCreate
{
    [TestClass]
    public class TestUnitaires
    {

        Directory courant = new Directory("/", null);

        [TestInitialize]
        public void TestInitialize() 
        {

        }

        [TestMethod]
        public void TestCreateNewFile()
        {
            Directory fichier = new Directory("test",null);
            Assert.IsTrue(fichier.createNewFile("test"));
            Assert.IsTrue(fichier.Fichiers.Count == 1);
            
        }

        [TestMethod]
        public void TestNotCreateNewFile()
        {
            Directory fichier = new Directory("test", null);
            Assert.IsFalse(fichier.createNewFile("test"));
            Assert.IsFalse(fichier.Fichiers.Count == 1);

        }

        [TestMethod]
        public void TestMkdir()
        {
            Directory fichier = new Directory("test", null);
            Assert.IsTrue(fichier.mkdir("test"));
            Assert.IsTrue(fichier.Fichiers.Count == 1);
        }

        [TestMethod]
        public void TestNotMkdir()
        {
            Directory fichier = new Directory("test", null);
            Assert.IsFalse(fichier.mkdir("test"));
            Assert.IsFalse(fichier.Fichiers.Count == 1);
        }

        [TestMethod]
        public void MethodTestCd()
        {
            Directory racine = new Directory("/", null);
            Directory fichier = new Directory("test", racine);
            racine.Fichiers.Add(fichier);
            Assert.AreEqual(fichier, racine.cd("test"));
        }

        [TestMethod]
        public void TestMethodLs()
        {
            Directory test1 = new Directory("test1", null);
            Fichier test2 = new Fichier("test",test1);
            test1.Fichiers.Add(test2);
            Assert.AreEqual(test1.Fichiers, test1.ls());

        }

        [TestMethod]
        public void TestMethodIsDirectory()
        {
            Directory test = new Directory("test", null);
            Assert.IsTrue(test.isDirectory());
        }

        [TestMethod]
        public void TestMethodNotIsDirectory()
        {
            Directory test = new Directory("test", null);
            Assert.IsFalse(test.isDirectory());
        }

        [TestMethod]
        public void TestMethodIsFile()
        {
            Fichier test = new Fichier("test", null);
            Assert.IsTrue(test.isFile());
        }

        [TestMethod]
        public void TestMethodNotIsFile()
        {
            Fichier test = new Fichier("test", null);
            Assert.IsFalse(test.isFile());
        }

        [TestMethod]
        public void TestDelete()
        {
            Directory test1 = new Directory("test1", null);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.IsTrue(test1.delete("test2"));
        }

        [TestMethod]
        public void TestNotDelete()
        {
            Directory test1 = new Directory("test1", null);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.IsFalse(test1.delete("test2"));
        }

        [TestMethod]
        public void TestRename()
        {
            Directory test1 = new Directory("test1", null);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.IsTrue(test1.rename("test2", "test3"));
        }

        [TestMethod]
        public void TestNotRename()
        {
            Directory test1 = new Directory("test1", null);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.IsFalse(test1.rename("test2", "test3"));
        }

        [TestMethod]
        public void TestSearch()
        {
           Directory test = new Directory("test", null);
           test.mkdir("test1");
           test.mkdir("test2");
           test.mkdir("test3");
           test.mkdir("test3");
           Assert.AreEqual(2, test.search("test3").Count);
        }

        [TestMethod]
        public void TestGetPath()
        {
            Directory test1 = new Directory("test1", courant);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.AreEqual(test1.Nom + "/" + test2.Nom + "/", test2.getPath());
        }

        [TestMethod]
        public void TestGetParent()
        {
            Directory test1 = new Directory("test1", null);
            Directory test2 = new Directory("test2", test1);
            test1.Fichiers.Add(test2);
            Assert.AreEqual(test1,test2.getParent());
        }


        [TestMethod]
        public void TestChmod1()
        {
            Directory test = new Directory("test", null);
            int newPermission = 1;
            test.chmod(newPermission);
            Assert.AreEqual(1, test.permission);
        }
        [TestMethod]
        public void TestChmod2()
        {
            Directory test = new Directory("test", null);
            int newPermission = 2;
            test.chmod(newPermission);
            Assert.AreEqual(2, test.permission);
        }
        [TestMethod]
        public void TestChmod3()
        {
            Directory test = new Directory("test", null);
            int newPermission = 3;
            test.chmod(newPermission);
            Assert.AreEqual(3, test.permission);
        }
        [TestMethod]
        public void TestChmod4()
        {
            Directory test = new Directory("test", null);
            int newPermission = 4;
            test.chmod(newPermission);
            Assert.AreEqual(4, test.permission);
        }
        [TestMethod]
        public void TestChmod5()
        {
            Directory test = new Directory("test", null);
            int newPermission = 5;
            test.chmod(newPermission);
            Assert.AreEqual(5, test.permission);
        }
        [TestMethod]
        public void TestChmod6()
        {
            Directory test = new Directory("test", null);
            int newPermission = 6;
            test.chmod(newPermission);
            Assert.AreEqual(6, test.permission);
        }
        [TestMethod]
        public void TestChmod7()
        {
            Directory test = new Directory("test", null);
            int newPermission = 7;
            test.chmod(newPermission);
            Assert.AreEqual(7, test.permission);
        }
        [TestMethod]
        public void TestCanRead()
        {
            Directory test = new Directory("test", null);
            test.permission = 4;
            Assert.IsTrue(test.canRead());
        }
        [TestMethod]
        public void TestCanWrite()
        {
            Directory test = new Directory("test",null);
            test.permission = 2;
            Assert.IsTrue(test.canWrite());
        }
        [TestMethod]
        public void TestCanExecute()
        {
            Directory test = new Directory("test", null);
            test.permission = 1;
            Assert.IsTrue(test.canExecute());
        }

        [TestMethod]
        public void TestNotCanRead()
        {
            Directory test = new Directory("test", null);
            test.permission = 4;
            Assert.IsFalse(test.canRead());
        }
        [TestMethod]
        public void TestNotCanWrite()
        {
            Directory test = new Directory("test", null);
            test.permission = 2;
            Assert.IsFalse(test.canWrite());
        }
        [TestMethod]
        public void TestNotCanExecute()
        {
            Directory test = new Directory("test", null);
            test.permission = 1;
            Assert.IsFalse(test.canExecute());
        }
    }
    
}
