
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
namespace WebDriverTest_PageObject
{
    [TestFixture]
    public class HotelTest2
    {
        public IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }

        [Test]
        public void Choise_0_passengers()
        {
            PageObject_HotelTest search_avia = new PageObject_HotelTest(driver);
            search_avia.Navigate();
            search_avia.Input_Sity("Минск");
            search_avia.Input_date();
            search_avia.ClickButtonHotel();
            search_avia.Serch_Apartament("Apartments Malinovka");
            Thread.Sleep(5000);
         
            Assert.AreEqual(driver.FindElement(By.ClassName("InfoBox__HotelTitle")).Text, "Apartments Malinovka", "No warning Apartments Malinovka");
        }
    }
}
