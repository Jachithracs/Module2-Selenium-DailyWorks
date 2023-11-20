using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_20_11_2023
{
    [TestFixture]
    internal class Flipkart : CoreCode
    {
        [Test]
        [Order(10)]
        [Author("Jachithra","cs@gmail.com")]
        [Description("Close Pop Up")]
        [Category("Regression Testing")]

        public void ClosePopUp()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";

            IWebElement closePopUp = wait.Until(driv => driv.FindElement(By.XPath("//span[@role='button']")));
            closePopUp.Click();
 
        }
        [Test]
        [Order(20)]
        [Author("Jachithra", "cs@gmail.com")]
        [Description("Searching a product")]
        [Category("Regression Testing")]

        public void ProductSearching()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";

            IWebElement searchProduct = wait.Until(driv => driv.FindElement(By.ClassName("Pke_EE")));
            searchProduct.SendKeys("Laptop");
            searchProduct.SendKeys(Keys.Enter);
           
        }


    }
}
