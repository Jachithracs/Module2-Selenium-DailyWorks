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
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "NaaptolSearch";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchtext = excelData?.SearchText;

                Console.WriteLine($"Search Text : {searchtext}");


                homePage.SearchClick(searchtext);

                var resultProduct = new ProductLists(driver);
                resultProduct.ClickProduct();

                List<string> nextwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(nextwindow[1]);

                var buyPrdt = new OrderedProductPage(driver);
                buyPrdt.SizeSelection();

                buyPrdt.ClickBuyBtn();


            }
        }

    }
}
