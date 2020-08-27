using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TurnUpPortal.Pages
{
    public class TimeAndMaterialPage
    {
        public void CreateTimeAndMaterial(IWebDriver driver)
        {
            ////// Creating Material - without sleep unable to find code, description and price ////

           try
            {
                IWebElement clickCreateNewButton = driver.FindElement(By.CssSelector(".btn-primary"));
                clickCreateNewButton.Click();
                Thread.Sleep(2000);
            }
            catch(Exception ex)
            {
                Assert.Fail("Create new page did not launch", ex.Message);
            }


            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            IWebElement clickPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));


            codeTextbox.SendKeys("Material");
            descriptionTextbox.SendKeys("Material description");
            clickPrice.Click();
            priceTextbox.SendKeys("200");
            saveButton.Click();
            Thread.Sleep(2000);

            //// ASSERTION ////

            IWebElement clickGoToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            clickGoToLastPageButton.Click();
            Thread.Sleep(5000);

            IWebElement findMaterialRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findMaterialRecord.Text == "Material")
            {
                Assert.Pass("Material record created successfully, test passed!");
            }
            else
            {
                Assert.Fail("Material record not created, test failed!");
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
            Thread.Sleep(3000);

            IWebElement findMaterialRecordEdited = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findMaterialRecordEdited.Text == "MaterialEDITED")
            {
                Assert.Pass("Material record edited successfully, test passed!");
            }
            else
            {
                Assert.Fail("Material record not edited, test failed!");
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
                Assert.Pass("Material record deleted successfully, test passed!");
            }
            else
            {
                Assert.Fail("Material record not deleted successfully, test failed!");
            }
        }
    }
}
