using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class ProductLists
    {
        IWebDriver driver;
        public ProductLists(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"productItem5\"]/div[1]/a")]
        public IWebElement? SelectingProduct { get; set; }

        public ProductLists ClickProduct()
        {
            SelectingProduct.Click();
            return new ProductLists(driver);
        }
    }
}
