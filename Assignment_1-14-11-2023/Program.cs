


using Assignment_1_14_11_2023;
using NUnit.Framework;

Amazon amazon = new ();
amazon.InitializeChromeDriver();
try
{
    amazon.TitleTest();
    amazon.OrganizationTypeTest();
}
catch (AssertionException)
{
    Console.WriteLine(" Fail");
}
amazon.Destruct ();