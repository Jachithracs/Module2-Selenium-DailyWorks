using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTest :CoreCodes
    {
        //Asserts
        /*
        [Test, Order(1), Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.CreateAccounLinkClick();
            Thread.Sleep(3000);
            Console.WriteLine(driver.Url);
            Assert.That(driver.Url.Contains("register"));
        }
        [Test, Order(2), Category("Smoke Test")]
        public void SignInLinkTest()
        {

            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homepage.SignInLinkClick();
            Thread.Sleep(3000);
            Console.WriteLine(driver.Url);
            Assert.That(driver.Url.Contains("login"));
        }
        */
        /*
        [Test, Order(1), Category("Regression Test")]
        public void CreateAccountTest()
        {

            var homepage = new RediffHomePage(driver);
            if(!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            
            var createaccountpage=homepage.CreateAccountClick();
            Thread.Sleep(3000);
            createaccountpage.FullNameType("Jaganadha varma");
            createaccountpage.RediffmailType("jagan");
            createaccountpage.CheckAvailabilityBtnClick();
            Thread.Sleep(3000);
            createaccountpage.CreateMyAccountBtnClick();

            //Console.WriteLine(driver.Url);
            //Assert.That(driver.Url.Contains("register"));
        }
        */
        [Test, Order(2), Category("Regression Test")]
        public void SignInTest()
        {

            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }

            var signinpage = homepage.SignInClick();
            Thread.Sleep(3000);
            signinpage.TypeUserName("AAA");
            signinpage.TypePassword("password");
            signinpage.ClickRememberMeChkbx();
            Assert.False(signinpage.RememberMeChkbx?.Selected);
            Thread.Sleep(2000);

            signinpage.ClickSignInBtn();

            Assert.True(true);

            //Console.WriteLine(driver.Url);
            //Assert.That(driver.Url.Contains("register"));
        }
    }
}
