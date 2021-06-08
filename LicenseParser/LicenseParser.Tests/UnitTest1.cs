using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LicenseParser.LicenseFolder;

namespace LicenseParser.Tests
{
    [TestClass]
    public class ParserGrammarTest
    {
        [TestMethod]
        public void DateStampTest()
        {

            var entity = RowEntity.Parse("10:58:27 (lmgrd) (@lmgrd-SLOG@) Start-Date: Mon Jan 11 2021 10:58:27 Romance Standard Time");

           // Assert.IsTrue(entity.GetType() == typeof(AnyRow));
            Assert.IsTrue(entity.GetType() == typeof(DateStamp));
            //Assert.IsFalse(entity.GetType() == typeof(LicenseUsage));
        }
    }
}
