using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Pages;

namespace TurnUpPortal.Helpers
{
    public class CommonDriver
    {

        // Initializing WebDriver
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginActions()
        {
            // Defining Web Driver
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);

        }

        [OneTimeTearDown]
        public void ClosingSteps()
        {
            // Kills driver instances
            driver.Quit();
        }
    }
}
