using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_21_11_2023
{
    [TestFixture]
    internal class NaaptolTest : CoreCode
    {
        
        [Test]
        [Order(10)]
        [Author("Jachithra", "cs@gmail.com")]
        [Description("Searching a product")]
        [Category("Regression Testing")]
        public void ProductSearching()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";

            IWebElement searchProduct = wait.Until(driv => driv.FindElement(By.Id("header_search_text")));
            searchProduct.SendKeys("eyewear");
            searchProduct.SendKeys(Keys.Enter);
            Assert.That(driver.Title.Contains("eyewear"));

        }
        [Test]
        [Order(20)]
        [Author("Jachithra", "cs@gmail.com")]
        [Description("Select a product")]
        [Category("Regression Testing")]

        public void SelectAProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(
                By.XPath("//a[@title='Reading Glasses with LED Lights (LRG4)'][1]")));
           

            js.ExecuteScript("arguments[0].click();", driver.FindElement(
                By.XPath("//a[@title='Reading Glasses with LED Lights (LRG4)'][1]")));
            Thread.Sleep(3000);

            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);

        }
        [Test]
        [Order(30)]
        [Author("Jachithra", "cs@gmail.com")]
        [Description("Add a product")]
        [Category("Regression Testing")]

        public void AddAProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";

            IWebElement sizeProduct = wait.Until(driv => driv.FindElement(By.LinkText("Black-2.50")));
            sizeProduct.Click();
            Thread.Sleep(3000);

            IWebElement buyProduct = wait.Until(driv => driv.FindElement(By.Id("cart-panel-button-0")));
            buyProduct.Click();
            Thread.Sleep(3000);

        }
        [Test]
        [Order(40)]
        [Author("Jachithra", "cs@gmail.com")]
        [Description("View Cart product")]
        [Category("Regression Testing")]

        public void ViewProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";

            IWebElement viewProduct = wait.Until(driv => driv.FindElement(By.LinkText("Reading Glasses with LED Lights (LRG4)")));
            Assert.AreEqual(viewProduct.Text, "Reading Glasses with LED Lights (LRG4)");
            Console.WriteLine("Product is already in the cart");
            Thread.Sleep(3000);

            IWebElement closePopup = wait.Until(driv => driv.FindElement(By.XPath("//*[contains(@class,'fancybox-close')]")));
            closePopup.Click();
        }


    }
}
