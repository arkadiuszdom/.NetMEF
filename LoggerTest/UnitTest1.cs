using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AppInterfaces;
using FileLoggerProject;
using DBLoggerProject;
using DBProject;

namespace LoggerTest
{
    [TestClass]
    public class LoggerTests
    {
        private static string logPath = "TestLog.txt";
        
        [TestInitialize]
        public void Init()
        {
            if (File.Exists(logPath))
                File.Delete(logPath);
        }

        [TestMethod]
        public void TestFileLogExists()
        {
            bool expected = true;
            ILogger log = new FileLogger();
            log.Log("test_test_test");
            Boolean actual = File.Exists(logPath);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFileLog()
        {
            if (File.Exists(logPath))
                File.Delete(logPath);

            string actual = "";
            string expected = "raz dwa trzy proba mikrofonu";
            ILogger log = new FileLogger();
            log.Log(expected);
            using (StreamReader sr = new StreamReader(logPath))
            {
                actual = sr.ReadToEnd().Substring(22).TrimEnd();
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDBLogExists()
        {
            bool expected = true;
            ILogger log = new FileLogger();
            log.Log("test_test_test");
            Boolean actual = File.Exists(logPath);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDBLog()
        {
            if (File.Exists(logPath))
                File.Delete(logPath);

            string actual = "";
            string expected = "raz dwa trzy proba mikrofonu";
            ILogger log = new DBLogger();
            log.Log(expected);
            using (var db = new TPAEntities())
            {
               // var query = from Log in db.LogSet
                      //      select Log.Message;

               // actual = query.FirstOrDefault<Log>();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
