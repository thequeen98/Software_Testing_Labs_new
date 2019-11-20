using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverTest_PageObject
{
    [TestFixture]
    public class HotelTest1
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
            search_avia.Check_count_people();
            search_avia.ClickButtonHotel();
            Assert.AreEqual(driver.FindElement(By.ClassName("WarningText__highlight")).Text, "Возраст ребенка установлен на 8 лет.", "No warning about default age of childrens");
        }
    }
}
