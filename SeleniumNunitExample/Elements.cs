using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class Elements : CoreCodes
    {
        //[Test]
       /* public void TestCheckBox()
        {
            Thread.Sleep(1000);
            
            driver.FindElement(By.Id("close_button_svg")).Click();
            IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Elements']//parent::div"));
            elements.Click();
            */

           // IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']//parent::li"));
            //cbmenu.Click();

           // List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
           /* foreach (var item in expandcollapse)
            {
                item.Click();
            }

            IWebElement commandsheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandsheckbox.Click();

            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);

                
        }*/
        [Test]
        public void TestFormElements()
        {
            Thread.Sleep(1000);
            /*
            driver.FindElement(By.Id("close_button_svg")).Click();
            IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Elements']//parent::div"));
            elements.Click();
            */

            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("Shirin");
           Thread.Sleep(1000);

            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Shiyas");
            Thread.Sleep(1000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("Shirin@gmail.com");
            Thread.Sleep(1000);

            IWebElement genderRadio = driver.FindElement(By.XPath("//label[text()='Female']"));
            genderRadio.Click();
            Thread.Sleep(1000);

            IWebElement mobileNumberField = driver.FindElement(By.Id("userNumber"));
            mobileNumberField.SendKeys("1234567890");
            Thread.Sleep(1000);

            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(1000);

            IWebElement dobMonth = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(1000);

            IWebElement dobYear = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1991");
            Thread.Sleep(1000);

            IWebElement dobDay = driver.FindElement(By.XPath("//div[text()='5']"));
            dobDay.Click();
            Thread.Sleep(1000);

            IWebElement subjectsField = driver.FindElement(By.Id("subjectsInput"));
            subjectsField.SendKeys("Maths");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            subjectsField.SendKeys("Chemistry");
            subjectsField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            IWebElement hobbiesCheckbox = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesCheckbox.Click();
            Thread.Sleep(1000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Desktop");
            Thread.Sleep(1000);

            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 Street, City, Country");
            Thread.Sleep(1000);

            /*
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();
            */



            /*

            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach (var item in expandcollapse)
            {
                item.Click();
            }

            IWebElement commandsheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandsheckbox.Click();

            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);

            */
        }
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent Window's handle -> " + parentWindowHandle);

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(var i=0;i<3;i++)
            {
                clickElement.Click();
                Thread.Sleep(1000);
            }
            List<string> lstWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window ->"+handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(1000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(1000);

                lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }

        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            IAlert simpleAlert = driver.SwitchTo().Alert();

            Console.WriteLine("Alert text is " + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(3000);
            element.Click();

            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;

            Console.WriteLine("Alert Text is "+alertText);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText= promptAlert.Text;
            Console.WriteLine("Alert Text is "+alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promptAlert.Accept();

        }
        
    }
}
