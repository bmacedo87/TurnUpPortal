using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Helpers;
using TurnUpPortal.Pages;

namespace TurnUpPortal.Tests
{
    [TestFixture]
    [Parallelizable]
    public class EmployeesTest : CommonDriver 
    {
        [Test, Order(1), Description("Check if user is able to create Employee record with valid data")]
        public void CreateEmployee_Test()
        {
            // Home page object initialization and definition
            HomePage homePageObject = new HomePage();
            homePageObject.NavigateToEmployees(driver);

            // Create new Employee
            EmployeesPage employeeObject = new EmployeesPage();
            employeeObject.CreateEmployee(driver); 
        }

        [Test, Order(2), Description("Check if user is able to edit Employee record with valid data")]
        public void EditEmployee_Test()
        {
            // Edit existing Employee test
            EmployeesPage employeeObject = new EmployeesPage();
            employeeObject.EditEmployee(driver);
        }

        [Test, Order(3), Description("Check if user is able to delete Employee record")]
        public void DeleteEmployee_Test()
        {
            // Delete existing Employee test
            EmployeesPage employeeObject = new EmployeesPage();
            employeeObject.DeleteEmployee(driver);
        }

    }
}
