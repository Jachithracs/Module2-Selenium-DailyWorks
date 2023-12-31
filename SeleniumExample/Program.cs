﻿
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using SeleniumExample;
/*
GHPTests gHPTests = new();

/*
Console.WriteLine(" 1. Edge      2. Chrome");
int ch=Convert.ToInt32(Console.ReadLine());
switch(ch)
{
    case 1:
        gHPTests.InitializeEdgeDriver();
       break;
        case 2:
        gHPTests.InitializeChromeDriver();
        break;
}
*/
/*
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");

foreach (var d in drivers)
{
    switch(d)
    {
        case "Edge":
            gHPTests.InitializeEdgeDriver();
         break;
        case "Chrome":
            gHPTests.InitializeChromeDriver();
        break;
    }
    try
    {
        //gHPTests.TitleTest();
        //gHPTests.PageSourceTest();
        //gHPTests.PageSourceandURLTest();
        //gHPTests.GStest();
        //gHPTests.GmailLinkTest();
        //gHPTests.ImagesLinkTest();
        //gHPTests.LocalizationTest();
        gHPTests.GAppYoutubeTest();
    }
    catch (AssertionException)
    {
        Console.WriteLine("Title test - Fail");
    }
    gHPTests.Destruct();
}
*/
//**********************Amazon Test Class************************


AmazonTest amazon = new();
List<string> drivers = new List<string>();
drivers.Add("Chrome");


foreach (var d in drivers)
{
    switch (d)
    {  
        case "Chrome":
            amazon.InitializeChromeDriver();
        break;
    }
    try
    {
        //amazon.TitleTest();
        //amazon.LogoClickTest();
        //Thread.Sleep(1000);
        //amazon.SearchProductTest();
        //amazon.ReloadHomePage();
       // amazon.TodaysDealsTest();
        //amazon.SignInAccListTest();
        amazon.SearchAndFilterProductByBrandTest();
        //amazon.SortBySelectTest();
    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    amazon.Destruct();
}























