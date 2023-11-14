using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace Assignment_2_14_11_2023
{
    internal class Yahoo
    {
        IWebDriver? driver;

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title " + driver.Title);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void YahooTest()
        {
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
        }
        public void BackToPage()
        {
            Thread.Sleep(2000);
            driver.Navigate().Back();
            Assert.AreEqual("Google",driver.Title);
            Console.WriteLine("Back to page - Pass");
        }
        public void YahooLogin()
        {
            
            IWebElement searchinput = driver.FindElement(By.Id("APjFqb"));
            searchinput.SendKeys("What's the new for Diwali 2023 ?");
            Thread.Sleep(2000);
          
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("What's the new for Diwali 2023 ? - Google Search", driver.Title);
            Console.WriteLine("Yahoo Search Test - Pass");
            driver.Navigate().Refresh();
        }
        public void Destruct()
        {
            driver.Close();
        }

    }
}
