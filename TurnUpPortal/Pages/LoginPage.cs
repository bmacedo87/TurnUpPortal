using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TurnUpPortal.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
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

            // Find 'Hello hari! hyperlink

            IWebElement findUsernameOnPage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            // Validation/assertion

            if (findUsernameOnPage.Text == "Hello hari!")
            {
                Assert.Pass("Logged in succesfully, test passed!");
            }
            else
            {
                Assert.Fail("Login unsuccessful, test failed!");
            }



            // Assert.That(findUsernameOnPage.Text, Is.EqualTo("Hello hari!"));


 
        }
    }
}
