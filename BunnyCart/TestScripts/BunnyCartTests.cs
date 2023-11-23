using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {
        [Test]
        public void SignInTest()
        {
            BunnyCartHomePage bchp = new(driver);
            bchp.ClickCreateAnAccountLink();
            Thread.Sleep(3000);

            try
            {

           
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                bchp.SignUp("John", "Doe", "john.doe@example.com", "12345", "12345", "9876543210");

            }
            catch (AssertionException ex)
            {
                Console.WriteLine("Sign Up Failed");
            }
            
            
        }

    }
}

