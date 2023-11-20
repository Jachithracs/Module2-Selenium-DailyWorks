using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class LinkedinTests :CoreCodes
    {
        [Test]
        [Author("Jachithra","CS@fgh.com")]
        [Description("checked for Valid Login")]
        [Category("Regression Testing")]
        public void Login1Test()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));

            /*
            IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
               
            IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            */
            /*
            IWebElement emailInput = wait.Until(driv=>driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));
            */
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";
            IWebElement emailInput = wait.Until(driv => driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abc@xyz.com");
            passwordInput.SendKeys("12345");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
           // Thread.Sleep(1000);
        }
        [Test]
        [Author("AAA", "AAA@fgh.com")]
        [Description("checked for InValid Login")]
        [Category("Smoke Testing")]

        public void LoginTestWithInvalidCred()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys("abc@xyz.com");
            passwordInput.SendKeys("12345");
            ClearForm(emailInput);
            ClearForm(passwordInput); 
            emailInput.SendKeys("lkg@xyz.com");
            passwordInput.SendKeys("12356");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            emailInput.SendKeys("ukg@xyz.com");
            passwordInput.SendKeys("123567");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(1000);

        }
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        [Test]
        [Author("Jaya", "CS@fgh.com")]
        [Description("checked for InValid Login")]
        [Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithvalidCred(string email,string pwd)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));

            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"abc@xyz.com", "12345"},
                new object[] {"lkg@xyz.com", "12356"},
                new object[] { "ukg@xyz.com", "123567" }
            };
        }
    }
}
