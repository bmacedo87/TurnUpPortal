using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TurnUpPortal
{
    class TimeAndMaterialTest
    {
        static void Main(string[] args)
        {
            // Initializing and defining WebDriver

            IWebDriver driver = new ChromeDriver();

            // Navigating to URL

            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            // Maximize the browser

            driver.Manage().Window.Maximize();

            ////// Login //////
            
            IWebElement typeUsernameTextbox = driver.FindElement(By.Id("UserName"));
            IWebElement typePasswordTextbox = driver.FindElement(By.Id("Password"));
            IWebElement clickLoginButton = driver.FindElement(By.CssSelector(".btn-default"));
            

            typeUsernameTextbox.SendKeys("hari");
            typePasswordTextbox.SendKeys("123123");
            clickLoginButton.Click();

            //// ASSERTION ////

            IWebElement findUsernameOnPage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if(findUsernameOnPage.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in succesfully, test passed!");
            }
            else
            {
                Console.WriteLine("Login unsuccessful, test failed!");
            }

            ////// Go to Employees page //////

            IWebElement clickAdministrationDropbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            IWebElement clickEmployeesOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));

            clickAdministrationDropbox.Click();
            clickEmployeesOption.Click();

            ////// Create employee //////

            IWebElement clickCreateButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            clickCreateButton.Click();
            Thread.Sleep(2000);

            IWebElement typeNameTextbox = driver.FindElement(By.Id("Name"));
            IWebElement typeUserNameTextbox = driver.FindElement(By.Id("Username"));
            IWebElement typePassword = driver.FindElement(By.Id("Password"));
            IWebElement retypePassword = driver.FindElement(By.Id("RetypePassword"));
            IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
            IWebElement clickBackToList = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            



            typeNameTextbox.SendKeys("Stanley");
            typeUserNameTextbox.SendKeys("stanleyIC");
            typePassword.SendKeys("Stanley9!");
            retypePassword.SendKeys("Stanley9!");
            clickSaveButton.Click();
            clickBackToList.Click();
            

            IWebElement clickGoToLastPage = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            clickGoToLastPage.Click();
            Thread.Sleep(10000);

            ////// ASSERTION //////

            IWebElement findNewEmployee = driver.FindElement(By.XPath(".//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findNewEmployee.Text == "Stanley")
            {
                Console.WriteLine("New employee record has been created successfully, test passed!");
            }
            else
            {
                Console.WriteLine("New employee has not been created, test failed!");
            }


            //// ALL WORKING. DO ASSERTION!! ////



            /*  ////// Go to Time and Material page //////

              IWebElement clickAdministrationDropbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
              IWebElement clickTimeAndMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

              clickAdministrationDropbox.Click();
              clickTimeAndMaterialsOption.Click();

              ////// Creating Material - without sleep unable to find code, description and price ////

              IWebElement clickCreateNewButton = driver.FindElement(By.CssSelector(".btn-primary"));
              clickCreateNewButton.Click();
              Thread.Sleep(2000);

              IWebElement typeCode = driver.FindElement(By.Id("Code"));
              IWebElement typeDescription = driver.FindElement(By.Id("Description"));
              CLICK HERE AND THEN TYPE IN VALUE IWebElement typePrice = driver.FindElement(By.XPath("//*[@id=TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
              IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));


              typeCode.SendKeys("Material");
              typeDescription.SendKeys("Material description");
              typePrice.SendKeys("200");
              clickSaveButton.Click();
              Thread.Sleep(2000);
           */

        }



    }

}
