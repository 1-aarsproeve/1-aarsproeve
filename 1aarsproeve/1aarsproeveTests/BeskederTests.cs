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
    public class BeskederTests
    {
        private HovedmenuView _beskeder;

        [TestInitialize]
        public void BeforeTest()
        {
            _beskeder = new HovedmenuView();
        }

        [TestMethod()]
        public void CheckBeskrivelseTest()
        {
            string beskrivelse3 = "";
            string beskrivelse4 = "";

            for (int i = 0; i < 30; i++)
            {
                beskrivelse4 = beskrivelse4 + "a";
            }



            _beskeder.Beskrivelse = beskrivelse4;
            Assert.AreEqual(beskrivelse4, _beskeder.Beskrivelse);

            try
            {
                _beskeder.Beskrivelse = beskrivelse3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual(" fejl i beskrivelse ", e.Message);
            }
        }

        [TestMethod()]
        public void CheckBeskrivelseTest1()
        {

            string beskrivelse4 = "";

            for (int i = 0; i < 10; i++)
            {
                beskrivelse4 = beskrivelse4 + "a";
            }



            _beskeder.Beskrivelse = beskrivelse4;
            Assert.AreEqual(beskrivelse4, _beskeder.Beskrivelse);

            try
            {
                _beskeder.Beskrivelse = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual(" fejl i beskrivelse ", e.Message);
            }
        }

        [TestMethod()]
        public void CheckBeskrivelseTest2()
        {
            string beskrivelse3 = "";
            string beskrivelse4 = "";

            for (int i = 0; i < 10; i++)
            {
                beskrivelse4 = beskrivelse4 + "a";
            }

            for (int i = 0; i < 9; i++)
            {
                beskrivelse3 = beskrivelse3 + "a";
            }


            _beskeder.Beskrivelse = beskrivelse4;
            Assert.AreEqual(beskrivelse4, _beskeder.Beskrivelse);

            try
            {
                _beskeder.Beskrivelse = beskrivelse3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual(" fejl i beskrivelse ", e.Message);
            }
        }
        [TestMethod()]
        public void CheckBeskrivelseTest3()
        {
            string beskrivelse3 = "";
            string beskrivelse4 = "";

            for (int i = 0; i < 30; i++)
            {
                beskrivelse4 = beskrivelse4 + "a";
            }

            for (int i = 0; i < 201; i++)
            {
                beskrivelse3 = beskrivelse3 + "a";
            }


            _beskeder.Beskrivelse = beskrivelse4;
            Assert.AreEqual(beskrivelse4, _beskeder.Beskrivelse);

            try
            {
                _beskeder.Beskrivelse = beskrivelse3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual(" fejl i beskrivelse ", e.Message);
            }
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



            _beskeder.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _beskeder.Brugernavn);

            try
            {
                _beskeder.Brugernavn = brugernavn3;
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



            _beskeder.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _beskeder.Brugernavn);

            try
            {
                _beskeder.Brugernavn = null;
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


            _beskeder.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _beskeder.Brugernavn);

            try
            {
                _beskeder.Brugernavn = brugernavn3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("brugernavn er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckOverskriftTest()
        {

            string Overskrift3 = "";
            string Overskrift4 = "";

            for (int i = 0; i < 10; i++)
            {
                Overskrift4 = Overskrift4 + "a";
            }

            for (int i = 0; i < 9; i++)
            {
                Overskrift3 = Overskrift3 + "a";
            }


            _beskeder.Overskrift = Overskrift4;
            Assert.AreEqual(Overskrift4, _beskeder.Overskrift);

            try
            {
                _beskeder.Overskrift = Overskrift3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("fejl i overskrift", e.Message);
            }
        }

        [TestMethod()]
        public void CheckOverskriftTest1()
        {

            string Overskrift3 = "";
            string Overskrift4 = "";

            for (int i = 0; i < 50; i++)
            {
                Overskrift4 = Overskrift4 + "a";
            }

            for (int i = 0; i < 51; i++)
            {
                Overskrift3 = Overskrift3 + "a";
            }


            _beskeder.Overskrift = Overskrift4;
            Assert.AreEqual(Overskrift4, _beskeder.Overskrift);

            try
            {
                _beskeder.Overskrift = Overskrift3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("fejl i overskrift", e.Message);
            }
        }

        [TestMethod()]
        public void CheckOverskriftTest2()
        {

            string Overskrift3 = "";
            string Overskrift4 = "";

            for (int i = 0; i < 10; i++)
            {
                Overskrift4 = Overskrift4 + "a";
            }

            _beskeder.Overskrift = Overskrift4;
            Assert.AreEqual(Overskrift4, _beskeder.Overskrift);

            try
            {
                _beskeder.Overskrift = Overskrift3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("fejl i overskrift", e.Message);
            }
        }

        [TestMethod()]
        public void CheckOverskriftTest3()
        {


            string Overskrift4 = "";

            for (int i = 0; i < 10; i++)
            {
                Overskrift4 = Overskrift4 + "a";
            }




            _beskeder.Overskrift = Overskrift4;
            Assert.AreEqual(Overskrift4, _beskeder.Overskrift);

            try
            {
                _beskeder.Overskrift = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("fejl i overskrift", e.Message);
            }
        }


    }
}
