using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1aarsproeve.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace _1aarsproeveTests
{
    [TestClass()]
    public class AnsatteTests
    {
        private Ansatte _ansatte;

        [TestInitialize]
        public void BeforeTest()
        {
            _ansatte = new Ansatte();
        }

        [TestMethod()]
        public void AnsatteTest()
        {
            string navn3 = "";
            string navn4 = "";

            for (int i = 0; i < 2; i++)
            {
                navn3 = navn3 + "a";
            }

            for (int i = 0; i < 31; i++)
            {
                navn4 = navn4 + "a";
            }

            _ansatte.Navn = navn3;
            Assert.AreEqual(navn3, _ansatte.Navn);

            try
            {
                _ansatte.Navn = navn4;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("navn er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void AnsatteTest1()
        {
            string navn3 = "";
            string navn4 = "a";

            for (int i = 0; i < 4; i++)
            {
                navn3 = navn3 + "a";
            }



            _ansatte.Navn = navn3;
            Assert.AreEqual(navn3, _ansatte.Navn);

            try
            {
                _ansatte.Navn = navn4;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("navn er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void AnsatteTest2()
        {
            string navn3 = "";
            string navn4 = "";

            for (int i = 0; i < 30; i++)
            {
                navn3 = navn3 + "a";
            }

            for (int i = 0; i < 0; i++)
            {
                navn4 = navn4 + "a";
            }

            _ansatte.Navn = navn3;
            Assert.AreEqual(navn3, _ansatte.Navn);

            try
            {
                _ansatte.Navn = navn4;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("navn er forkert", e.Message);
            }
        }


        [TestMethod()]
        public void CheckPasswordTest()
        {
            string password1 = "";


            for (int i = 0; i < 30; i++)
            {
                password1 = password1 + "a";
            }



            _ansatte.Password = password1;
            Assert.AreEqual(password1, _ansatte.Password);

            try
            {
                _ansatte.Password = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("password er forkert", e.Message);
            }
        }
        [TestMethod()]
        public void CheckPasswordTest1()
        {
            string password1 = "";
            string password2 = "";

            for (int i = 0; i < 30; i++)
            {
                password1 = password1 + "a";
            }



            _ansatte.Password = password1;
            Assert.AreEqual(password1, _ansatte.Password);

            try
            {
                _ansatte.Password = password2;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("password er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckPasswordTest2()
        {
            string password1 = "";
            string password2 = "";

            for (int i = 0; i < 30; i++)
            {
                password1 = password1 + "a";
            }

            for (int I = 0; I < 31; I++)
            {
                password2 = password2 + "a";
            }


            _ansatte.Password = password1;
            Assert.AreEqual(password1, _ansatte.Password);

            try
            {
                _ansatte.Password = password2;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("password er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckPasswordTest3()
        {
            string password1 = "";
            string password2 = "";

            for (int i = 0; i < 6; i++)
            {
                password1 = password1 + "a";
            }

            for (int I = 0; I < 5; I++)
            {
                password2 = password2 + "a";
            }


            _ansatte.Password = password1;
            Assert.AreEqual(password1, _ansatte.Password);

            try
            {
                _ansatte.Password = password2;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("password er forkert", e.Message);
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



            _ansatte.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _ansatte.Brugernavn);

            try
            {
                _ansatte.Brugernavn = brugernavn3;
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



            _ansatte.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _ansatte.Brugernavn);

            try
            {
                _ansatte.Brugernavn = null;
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


            _ansatte.Brugernavn = brugernavn4;
            Assert.AreEqual(brugernavn4, _ansatte.Brugernavn);

            try
            {
                _ansatte.Brugernavn = brugernavn3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("brugernavn er forkert", e.Message);
            }
        }



        //[TestMethod()]
        //public void ChecknavnTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void CheckEmailTest()
        {
            string email4 = "";
            for (int i = 0; i < 10; i++)
            {
                email4 = email4 + "a";
            }


            _ansatte.Email = email4;
            Assert.AreEqual(email4, _ansatte.Email);

            try
            {
                _ansatte.Email = null;
                
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("email er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckEmailTest1()
        {

            string email3 = "";
            string email4 = "";

            for (int i = 0; i < 5; i++)
            {
                email3 = email3 + "a";
            }

            for (int i = 0; i < 10; i++)
            {
                email4 = email4 + "a";
            }


            _ansatte.Email = email4;
            Assert.AreEqual(email4, _ansatte.Email);

            try
            {
                _ansatte.Email = email3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("email er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckEmailTest2()
        {

            string email3 = "";
            string email4 = "";

            for (int i = 0; i < 21; i++)
            {
                email3 = email3 + "a";
            }

            for (int i = 0; i < 10; i++)
            {
                email4 = email4 + "a";
            }


            _ansatte.Email = email4;
            Assert.AreEqual(email4, _ansatte.Email);

            try
            {
                _ansatte.Email = email3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("email er forkert", e.Message);
            }
        }

        [TestMethod()]
        public void CheckAdresseTest()
        {
            string adresse3 = "a";
            string adresse4 = "";



            for (int i = 0; i < 50; i++)
            {
                adresse4 = adresse4 + "a";
            }


            _ansatte.Adresse = adresse4;
            Assert.AreEqual(adresse4, _ansatte.Adresse);

            try
            {
                _ansatte.Adresse = adresse3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("adresse er for kort ", e.Message);
            }
        }

        [TestMethod()]
        public void CheckAdresseTest1()
        {

            string adresse4 = "";



            for (int i = 0; i < 50; i++)
            {
                adresse4 = adresse4 + "a";
            }


            _ansatte.Adresse = adresse4;
            Assert.AreEqual(adresse4, _ansatte.Adresse);

            try
            {
                _ansatte.Adresse = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("adresse er for kort ", e.Message);
            }
        }
        [TestMethod()]
        public void CheckAdresseTest2()
        {
            string adresse3 = "";
            string adresse4 = "";

            for (int i = 0; i < 51; i++)
            {
                adresse3 = adresse3 + "a";
            }

            for (int i = 0; i < 50; i++)
            {
                adresse4 = adresse4 + "a";
            }


            _ansatte.Adresse = adresse4;
            Assert.AreEqual(adresse4, _ansatte.Adresse);

            try
            {
                _ansatte.Adresse = adresse3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("adresse er for kort ", e.Message);
            }
        }

        [TestMethod()]
        public void CheckMobilTest()
        {
            string telefonnummer3 = "";
            string telefonnummer4 = "";

            for (int i = 0; i < 7; i++)
            {
                telefonnummer3 = telefonnummer3 + "a";
            }

            for (int i = 0; i < 8; i++)
            {
                telefonnummer4 = telefonnummer4 + "a";
            }


            _ansatte.Mobil = telefonnummer4;
            Assert.AreEqual(telefonnummer4, _ansatte.Mobil);

            try
            {
                _ansatte.Mobil = telefonnummer3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("mobil nummer er for kort", e.Message);
            }
        }

        [TestMethod()]
        public void CheckMobilTest1()
        {
            string telefonnummer3 = "";
            string telefonnummer4 = "";

            for (int i = 0; i < 9; i++)
            {
                telefonnummer3 = telefonnummer3 + "a";
            }

            for (int i = 0; i < 8; i++)
            {
                telefonnummer4 = telefonnummer4 + "a";
            }


            _ansatte.Mobil = telefonnummer4;
            Assert.AreEqual(telefonnummer4, _ansatte.Mobil);

            try
            {
                _ansatte.Mobil = telefonnummer3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("mobil nummer er for kort", e.Message);
            }
        }

        [TestMethod()]
        public void CheckMobilTest3()
        {

            string telefonnummer4 = "";



            for (int i = 0; i < 8; i++)
            {
                telefonnummer4 = telefonnummer4 + "a";
            }


            _ansatte.Mobil = telefonnummer4;
            Assert.AreEqual(telefonnummer4, _ansatte.Mobil);

            try
            {
                _ansatte.Mobil = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("mobil nummer er for kort", e.Message);
            }
        }

        [TestMethod()]
        public void CheckPostnummerTest()
        {
            string postnummer3 = "";
            string postnummer4 = "";

            for (int i = 0; i < 5; i++)
            {
                postnummer3 = postnummer3 + "a";
            }

            for (int i = 0; i < 4; i++)
            {
                postnummer4 = postnummer4 + "a";
            }


            _ansatte.Postnummer = postnummer4;
            Assert.AreEqual(postnummer4, _ansatte.Postnummer);

            try
            {
                _ansatte.Postnummer = postnummer3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("postnummer skal være 4 tegn", e.Message);
            }
        }

        [TestMethod()]
        public void CheckPostTest1()
        {
            string postnummer3 = "";
            string postnummer4 = "";

            for (int i = 0; i < 3; i++)
            {
                postnummer3 = postnummer3 + "a";
            }

            for (int i = 0; i < 4; i++)
            {
                postnummer4 = postnummer4 + "a";
            }


            _ansatte.Postnummer = postnummer4;
            Assert.AreEqual(postnummer4, _ansatte.Postnummer);

            try
            {
                _ansatte.Postnummer = postnummer3;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("postnummer skal være 4 tegn", e.Message);
            }
        }

        [TestMethod()]
        public void CheckPostTest3()
        {

            string postnummer4 = "";



            for (int i = 0; i < 4; i++)
            {
                postnummer4 = postnummer4 + "a";
            }


            _ansatte.Postnummer = postnummer4;
            Assert.AreEqual(postnummer4, _ansatte.Postnummer);

            try
            {
                _ansatte.Postnummer = null;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

                Assert.AreEqual("postnummer skal være 4 tegn", e.Message);
            }
        }

    }
}