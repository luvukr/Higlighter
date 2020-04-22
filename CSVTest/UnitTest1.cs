using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAllRecords()
        {
            var res = new CSVHelper().GetAllRecords();
        }
    }
}
