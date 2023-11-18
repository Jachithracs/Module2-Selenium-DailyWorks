using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            Thread.Sleep(2000);

            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        [Ignore("other")]
        [Test]
        [Order(20)]
        public void GStest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(2000);
            //IWebElement gsbutton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("Google Search Test - Pass");
        }
        [Test]
        public void CheckAllLinksStatusTest()
        {
            List<IWebElement> alllinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in alllinks)
            {
                string url = link.GetAttribute("href");
                if(url==null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                        Console.WriteLine(url + "is working");
                    else
                        Console.WriteLine(url + "is NOT working");
                }
            }
        }
    }
}
