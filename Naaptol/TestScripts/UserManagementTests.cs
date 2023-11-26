using Naaptol.PageObjects;
using Naaptol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naaptol.Utilities;

namespace Naaptol.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {
        [Test]
        [ Order(1), Category("Regression Test")]
        public void ProductSearchTest()
        {
            var homePage = new NaaptolHomePage(driver);

            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }

            try
            {
                Assert.That(driver.Url.Contains("naaptol"));
                test = extent.CreateTest("Naaptol Eyewear Product");
                test.Pass(" Naaptol Eyewear Product success");

            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Naaptol Eyewear Product Test");
                test.Fail("Naaptol Eyewear Product Search failed");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "NaaptolSearch";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchtext = excelData?.SearchText;
                string? quantity = excelData?.Quantity;

                Console.WriteLine($"Search Text : {searchtext}");
                Console.WriteLine($"Quantity : {quantity}");


                homePage.SearchClick(searchtext);
                Thread.Sleep(1000);
                TakeScreenShot();

                var resultProduct = new ProductLists(driver);
                resultProduct.ClickProduct();
                Thread.Sleep(1000);
                TakeScreenShot();

                List<string> nextwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(nextwindow[1]);

                var buyPrdt = new OrderedProductPage(driver);
                buyPrdt.SizeSelection();
                Thread.Sleep(1000);
                TakeScreenShot();

                buyPrdt.ClickBuyBtn();
                TakeScreenShot();


            }
        }

    }
}
