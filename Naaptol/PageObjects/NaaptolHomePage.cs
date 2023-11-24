using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naaptol.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver? driver;
        
        public NaaptolHomePage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? SearchElement { get; set; }

        public void SearchClick(string searchtext)
        {
            SearchElement?.SendKeys(searchtext);
            SearchElement?.SendKeys(Keys.Enter);
            
        }
    }
}
