using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region Assert Equal
        [TestMethod]
        public void AreEqualTest()
        {
            string str = "Fernando";
            string str1 = "Fernando";

            Assert.AreEqual(str, str1);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str = "Fernando";
            string str1 = "fernando";

            Assert.AreEqual(str, str1, false);
        }

        [TestMethod]
        public void AreNotEqualTest()
        {
            string str = "Fernando";
            string str1 = "Daiana";

            Assert.AreNotEqual(str, str1);
        }

        #endregion

        #region Assert Same
        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

   

    }
}
