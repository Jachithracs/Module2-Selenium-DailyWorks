using Assignment_2_14_11_2023;
using NUnit.Framework;

Yahoo yahoo = new();

yahoo.InitializeChromeDriver();
try
{
   
    yahoo.TitleTest();
    yahoo.YahooTest();
    yahoo.BackToPage();
    yahoo.YahooTest();
    yahoo.BackToPage();
    yahoo.YahooLogin();



}
catch(AssertionException)
{
    Console.WriteLine(" Fail");
}
yahoo.Destruct();