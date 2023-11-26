using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class OrderedProductPage
    {
        IWebDriver driver;
        public OrderedProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Brown-2.00']")]
        public IWebElement? SizeOfProductLink { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? BuyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='input_Special_2']")]
        public IWebElement? Quantity { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id=\"cartData\"]/li[1]/div[2]/p[2]/a")]
        public IWebElement? Remove { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'fancybox-close')]")]
        public IWebElement? CloseLink { get; set; }


        public void SizeSelection()
        {
            SizeOfProductLink?.Click();
        }
        public void ClickBuyBtn()
        {
            BuyBtn?.Click();
        }
        public void ClickQuantity(string quantity)
        {
            Quantity.SendKeys(quantity);
            Quantity.SendKeys(Keys.Enter);
        }

        public void ClickRemove()
        {
            Remove?.Click();
        }
        public void ClickCloseLink()
        {
            CloseLink?.Click();
        }
    }
}

