using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TurnUpPortal.Pages
{
    public class EmployeesPage
    {
        public void CreateEmployee(IWebDriver driver)
        {

         
            IWebElement createButton = driver.FindElement(By.CssSelector(".btn-primary"));
            createButton.Click();
        
            
            IWebElement nameTextbox = driver.FindElement(By.Id("Name"));
            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            IWebElement retypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id='container']/div/a"));

            
            nameTextbox.SendKeys("Stanley");
            usernameTextbox.SendKeys("stanleyIC");
            passwordTextbox.SendKeys("Caralho9!");
            retypePasswordTextbox.SendKeys("Caralho9!");
            saveButton.Click();
            backToListButton.Click();

            //// ASSERTION ////
            
            try
            {
                IWebElement GoToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]"));

                Thread.Sleep(2000);
                GoToLastPageButton.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Did not navigate to last page", ex.Message);
            }

            // Check if Employee record has been created

            IWebElement findNewEmployeeCreated = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]")); 

            if (findNewEmployeeCreated.Text == "Stanley")
            {
                Assert.Pass("Employee record created successfully, test passed!");
            }
            else
            {
                Assert.Fail("Employee record not created, test failed!");
            }
        }


        public void EditEmployee(IWebDriver driver)
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            IWebElement editNameTextbox = driver.FindElement(By.Id("Name"));
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id='container']/div/a"));

            editNameTextbox.SendKeys("EDITED");
            saveButton.Click();
            backToListButton.Click();


            //// ASSERTION ////

            try
            {
                IWebElement GoToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]"));

                Thread.Sleep(2000);
                GoToLastPageButton.Click();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Assert.Fail("Did not navigate to last page", ex.Message);
            }

            // Validate if Employee record has been edited

            IWebElement findNewEmployeeEdited = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findNewEmployeeEdited.Text == "StanleyEDITED")
            {
                Assert.Pass("Employee record edited successfully, test passed!");
            }
            else
            {
                Assert.Fail("Employee record not edited, test failed!");
            }
        }

        public void DeleteEmployee(IWebDriver driver)
        {
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteButton.Click();

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            // Check if item has been deleted

            IWebElement employeeDeleted = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]")); 

            if (employeeDeleted.Text != "StanleyEDITED")
            {
                Assert.Pass("Employee record deleted successfully, test passed!");
            }
            else
            {
                Assert.Fail("Employee record not deleted successfully, test failed!");
            }
        }
    }
}