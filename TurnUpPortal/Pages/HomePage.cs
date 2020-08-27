using System;
using OpenQA.Selenium;
using SeleniumExtras;
using TurnUpPortal.Helpers;

namespace TurnUpPortal.Pages
{
    public class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            ////// Navigate to Time and Materials page //////

            IWebElement clickAdministrationDropbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            IWebElement clickTimeAndMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

            clickAdministrationDropbox.Click();
            clickTimeAndMaterialsOption.Click();
        }

        public void NavigateToEmployees(IWebDriver driver)
        {
            ////// Navigate to Employees page //////

            IWebElement clickAdministrationDropbox = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            IWebElement clickEmployeesOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));

            clickAdministrationDropbox.Click();
            clickEmployeesOption.Click();
        }
    }
}
