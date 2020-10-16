using System;
using System.Collections.Generic;
using NUnit.Framework;
using SSquared_Winform;

namespace TestProject
{
    [TestFixture]
    public class SanitizationTests
    {
        [Test]
        public void NumbersAndCharsTest()
        {
            var addWinForm = new AddEmployeeWindow();
            List<string> cleanList = new List<string>()
            {
                "12",
                "first",
                "last"
            };

            string dirtyId = "12test";
            string dirtyFirst = "first99";
            string dirtyLast = "9last9";

            List<string> sanitizedList = addWinForm.SanitizeEmployeeInputs(dirtyId, dirtyFirst, dirtyLast);
            
            Assert.AreEqual(cleanList, sanitizedList);
        }
        
        [Test]
        public void PunctuationTest()
        {
            var addWinForm = new AddEmployeeWindow();
            List<string> cleanList = new List<string>()
            {
                "12",
                "first",
                "last"
            };

            string dirtyId = "12?";
            string dirtyFirst = "first//";
            string dirtyLast = "..last...";

            List<string> sanitizedList = addWinForm.SanitizeEmployeeInputs(dirtyId, dirtyFirst, dirtyLast);
            
            Assert.AreEqual(cleanList, sanitizedList);
        }
       
        [Test]
        public void WhiteSpaceTest()
        {
            var addWinForm = new AddEmployeeWindow();
            List<string> cleanList = new List<string>()
            {
                "12",
                "first",
                "last"
            };

            string dirtyId = "1 2";
            string dirtyFirst = "fi r s t ";
            string dirtyLast = "l as      t";

            List<string> sanitizedList = addWinForm.SanitizeEmployeeInputs(dirtyId, dirtyFirst, dirtyLast);
            
            Assert.AreEqual(cleanList, sanitizedList);
        }
        
        // Normally I add a "null" or "no data" test, so I'll do an empty string test here
        [Test]
        public void EmptyStringsTest()
        {
            var addWinForm = new AddEmployeeWindow();
            List<string> cleanList = new List<string>()
            {
                "",
                "",
                ""
            };

            string dirtyId = "";
            string dirtyFirst = "";
            string dirtyLast = "";

            List<string> sanitizedList = addWinForm.SanitizeEmployeeInputs(dirtyId, dirtyFirst, dirtyLast);
            
            Assert.AreEqual(cleanList, sanitizedList);
        }
        
        [Test]
        public void EveryWrongCharTest()
        {
            var addWinForm = new AddEmployeeWindow();
            List<string> cleanList = new List<string>()
            {
                "12",
                "first",
                "last"
            };

            string dirtyId = "12 ? /. < pass!";
            string dirtyFirst = "first ? ' , __ 56";
            string dirtyLast = "last ? 3 #$%%^&*@!";

            List<string> sanitizedList = addWinForm.SanitizeEmployeeInputs(dirtyId, dirtyFirst, dirtyLast);
            
            Assert.AreEqual(cleanList, sanitizedList);
        }
      
    }
}