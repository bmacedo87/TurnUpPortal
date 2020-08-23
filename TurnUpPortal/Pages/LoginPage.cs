using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            IWebElement findUsernameOnPage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (findUsernameOnPage.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in succesfully, test passed!");
            }
            else
            {
                Console.WriteLine("Login unsuccessful, test failed!");
            }
        }
    }
}
