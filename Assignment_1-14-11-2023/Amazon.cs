using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_14_11_2023
{
    internal class Amazon
    {
        IWebDriver? driver;

        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();

        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title :  " + driver.Title);
            Assert.That(driver.Title == "Amazon.com. Spend less. Smile more.");
            Console.WriteLine("Title test - Pass");
        }
        public void OrganizationTypeTest()
        {
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Organization Type - Pass");
        }
        public void Destruct()
        {
            driver.Close();
        }

    }
}
