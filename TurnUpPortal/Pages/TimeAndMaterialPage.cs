using System;
using System.Threading;
using OpenQA.Selenium;

namespace TurnUpPortal.Pages
{
    public class TimeAndMaterialPage
    {
        public void CreateTimeAndMaterial(IWebDriver driver)
        {
            ////// Creating Material - without sleep unable to find code, description and price ////

            IWebElement clickCreateNewButton = driver.FindElement(By.CssSelector(".btn-primary"));
            clickCreateNewButton.Click();
            Thread.Sleep(2000);

            IWebElement typeCode = driver.FindElement(By.Id("Code"));
            IWebElement typeDescription = driver.FindElement(By.Id("Description"));
            IWebElement clickPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement typePrice = driver.FindElement(By.Id("Price"));
            IWebElement clickSaveButtonTime = driver.FindElement(By.Id("SaveButton"));


            typeCode.SendKeys("Material");
            typeDescription.SendKeys("Material description");
            clickPrice.Click();
            typePrice.SendKeys("200");
            clickSaveButtonTime.Click();
            Thread.Sleep(2000);

            //// ASSERTION ////

            IWebElement clickGoToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            clickGoToLastPageButton.Click();

            IWebElement findMaterialRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findMaterialRecord.Text == "Material")
            {
                Console.WriteLine("Material record created successfully, test passed!");
            }
            else
            {
                Console.WriteLine("Material record not created, test failed!");
            }
        }

        public void EditTimeAndMaterial(IWebDriver driver)
        {
            IWebElement clickEditButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            clickEditButton.Click();

            IWebElement editMaterialCode = driver.FindElement(By.Id("Code"));
            IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));

            editMaterialCode.SendKeys("EDITED");
            clickSaveButton.Click();
            Thread.Sleep(2000);

            IWebElement clickGoToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            clickGoToLastPageButton.Click();

            IWebElement findMaterialRecordEdited = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findMaterialRecordEdited.Text == "MaterialEDITED")
            {
                Console.WriteLine("Material record edited successfully, test passed!");
            }
            else
            {
                Console.WriteLine("Material record not edited, test failed!");
            }
        }

        public void DeleteTimeAndMaterial(IWebDriver driver)
        {
            IWebElement clickDeleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            clickDeleteButton.Click();

            // Select OK when alert pops up

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);

            // Check if item has been deleted

            IWebElement timeDeleted = driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (timeDeleted.Text != "MaterialEDITED")
            {
                Console.WriteLine("Time record deleted successfully, test passed!");
            }
            else
            {
                Console.WriteLine("Time record not deleted successfully, test failed!");
            }
        }
    }
}
