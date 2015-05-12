using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using _1aarsproeve.Model;
namespace _1aarsproeveTests
{
    [TestClass()]
    public class VagterTests
    {
        private VagtplanView _vagter;

        [TestInitialize]
        public void BeforeTest()
        {
            _vagter = new VagtplanView();
        }

        [TestMethod()]
        public void CheckBrugernavnTest()
        {
            string brugernavn3 = "";
            string brugernavn4 = "";

            for (int i = 0; i < 30; i++)
            {
                brugernavn4 = brugernavn4 + "a";
            }



            _vagter.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _vagter.Brugernavn);

            try
            {
                _vagter.Brugernavn = brugernavn3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("brugernavn er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckBrugernavnTest1()
        {

            string brugernavn4 = "";

            for (int i = 0; i < 30; i++)
            {
                brugernavn4 = brugernavn4 + "a";
            }



            _vagter.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _vagter.Brugernavn);

            try
            {
                _vagter.Brugernavn = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("brugernavn er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckBrugernavnTest2()
        {
            string brugernavn3 = "";
            string brugernavn4 = "";

            for (int i = 0; i < 30; i++)
            {
                brugernavn4 = brugernavn4 + "a";
            }

            for (int i = 0; i < 31; i++)
            {
                brugernavn3 = brugernavn3 + "a";
            }


            _vagter.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _vagter.Brugernavn);

            try
            {
                _vagter.Brugernavn = brugernavn3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("brugernavn er forkert", e.Message);
            }
        }
    }
}