using BunnyCart.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class SearchTests : CoreCodes
    {
        [Test]
        [TestCase("Water")]
        public void SearchProductAndAddToCartTest(string searchtext)
        {
            BunnyCartHomePage bchp = new BunnyCartHomePage(driver);
            var searchrespage = bchp?.TypeSearchInput(searchtext);
            Assert.That(searchtext.Contains(searchrespage.GetFirstProductLink()));
            var productpage = searchrespage?.ClickFirstProductLink();
            Assert.That(searchtext.Equals(productpage?.GetProductTitleLabel()));
            productpage?.ClickIncQtyLink();
            productpage?.ClickAddToCartBtn();
            Thread.Sleep(3000);

        }
    }
}
