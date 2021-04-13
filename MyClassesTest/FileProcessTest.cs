using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"\BadFileName.bat";
        private const string FILE_NAME = @"FileToDeploy.txt";
        private string _GoodFileName;


        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File :{ _GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Text Appended");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File :{ _GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }


        [TestMethod]
        [Description("Verifica se o arquivo existe")]
        [Owner("Fernando Henrique Leme")]
        [Priority(0)]
        [TestCategory("Critério de Aceite")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File :{ _GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Verifica se o arquivo existe")]
        [Owner("Fernando Henrique Leme")]
        [Priority(0)]
        [TestCategory("Critério de Aceite")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";

            TestContext.WriteLine($"Checking File :{ fileName}");
            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesExistsSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File :{ _GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall, "File '{0}' Does Not Exist.", _GoodFileName);
            //Assert.IsFalse(fromCall, "File '{0}' Does Not Exist.",_GoodFileName);
        }

        [TestMethod]
        [Description("Verifica se o arquivo não existe")]
        [Owner("Fernando Henrique Leme")]
        [Priority(0)]
        [TestCategory("Critério de Aceite")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Description("Verifica se a exception é acionada")]
        [Owner("Fernando Henrique Leme")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Timeout(3000)]
        [Priority(1)]
        [TestCategory("Regra de Negócio")]
        public void FileNameNullOrEmpty_TrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Description("Verifica se a exception é acionada com try catch")]
        [Owner("Fernando Henrique Leme")]
        [Priority(1)]
        [TestCategory("Regra de Negócio")]
        [Ignore]
        public void FileNameNullOrEmpty_TrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentException)
            {
                //Success
                return;
            }
            Assert.Fail("Fail expected");

        }
    }
}
