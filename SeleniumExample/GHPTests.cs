using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExample
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title "+driver.Title); 
            
            //Console.WriteLine("Title Length " + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void PageSourceTest()
        {

            //Console.WriteLine("PS : "+driver.PageSource);
            Console.WriteLine("PS Len : "+driver.PageSource.Length);
        }
        public void PageSourceandURLTest()
        {
           // Console.WriteLine("PS Len :"+driver.PageSource.Length);
           // Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("URL test - Pass");
        }
        public void GStest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            //IWebElement gsbutton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search",driver.Title);
            Console.WriteLine("Google Search Test - Pass");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            //driver.FindElement(By.PartialLinkText("ma")).Click();
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("gmail"));
            //Assert.That(driver.Title.Contains("Gmail"));
            Console.WriteLine("Gmail LINK - Pass");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);
            Assert.That(driver.Title.Contains("Images"));
            //Assert.That(driver.Title.Contains("Gmail"));
            Console.WriteLine("Images LINK - Pass");
        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);
            Assert.That(loc.Equals("India"));
            Console.WriteLine("Localization test passed");
        }
        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            driver.FindElement(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a/div/span")).Click();
            Thread.Sleep(3000);
            Assert.That("Youtube".Equals(driver.Title));
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
