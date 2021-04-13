using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void ContainsTest()
        {
            string str = "Fer";
            string str2 = "Fernando";

            StringAssert.Contains(str2, str);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void StartsWithTest()
        {
            string str = "Fer";
            string str2 = "Fernando";

            StringAssert.StartsWith(str2, str);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void IsAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa baixa", regex);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void IsNotAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos caixa baixa", regex);
        }
    }
}
