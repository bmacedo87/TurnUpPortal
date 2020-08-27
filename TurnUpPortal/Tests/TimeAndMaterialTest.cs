using NUnit.Framework;
using TurnUpPortal.Helpers;
using TurnUpPortal.Pages;

namespace TurnUpPortal
{
    [TestFixture]
    [Parallelizable]
    public class TimeAndMaterialTest : CommonDriver
    {

    [Test, Order (1), Description("Check if user is able to create Time record with valid data")]
    public void CreateMaterial_Test()
        {

            // Home page object initialization and definition
            HomePage homePageObject = new HomePage();
            homePageObject.NavigateToTM(driver);

            // Time and Material page object initialization and definition
            TimeAndMaterialPage timeAndMaterialObject = new TimeAndMaterialPage();
            timeAndMaterialObject.CreateTimeAndMaterial(driver);
        }

    [Test, Order (2), Description("Check if user is able to edit Time record with valid data")]
    public void EditMaterial_Test()
        {
            // Edit existing Time and Material test
            TimeAndMaterialPage timeAndMaterialObject = new TimeAndMaterialPage();
            timeAndMaterialObject.EditTimeAndMaterial(driver);
        }

    [Test, Order (3), Description("Check if user is able to delete Time record")]
    public void DeleteMaterial_Test()
        { 
            // Delete existing Time and Material test
            TimeAndMaterialPage timeAndMaterialObject = new TimeAndMaterialPage();
            timeAndMaterialObject.DeleteTimeAndMaterial(driver);
        }

    
    }

}
