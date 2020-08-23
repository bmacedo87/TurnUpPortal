using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Pages;

namespace TurnUpPortal
{
    class TimeAndMaterialTest
    {
        static void Main(string[] args)
        {

            // Initializing and defining WebDriver

            IWebDriver driver = new ChromeDriver();

            // Login page object initialization and definition

            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);

            // Home page initialization and definition

            HomePage homePageObject = new HomePage();
            homePageObject.NavigateToTM(driver);

            // Time and Material page object initialization and definition

            TimeAndMaterialPage timeAndMaterialObject = new TimeAndMaterialPage();
            timeAndMaterialObject.CreateTimeAndMaterial(driver);

            // Edit existing Time and Material test
            timeAndMaterialObject.EditTimeAndMaterial(driver);

            // Delete existing Time and Material test

            timeAndMaterialObject.DeleteTimeAndMaterial(driver);


        }



    }

}
