using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest
{
    [TestFixture]
    public class WebDriverTest
    {
        [Test]

        public void Display_of_found_hotels()
        {
            IWebDriver driver = new FirefoxDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); ;
            driver.Navigate().GoToUrl("http://agoda.com/");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("SearchBoxTextEditor")));
            driver.FindElement(By.ClassName("SearchBoxTextEditor")).Click();
            driver.FindElement(By.ClassName("SearchBoxTextEditor")).SendKeys("Минск");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("Suggestion__geoHierarchyName")));
            driver.FindElement(By.ClassName("Suggestion__geoHierarchyName")).Click();
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("DayPicker-Day__label")));
            driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[21]")).Click();           
            driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[23]")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")));
            driver.FindElement(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[2]")));
            driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[1]")).Click();
            driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[4]")).Click();
            driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[5]")).Click();
            driver.FindElement(By.ClassName("Searchbox__searchButton--active")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("WarningText__highlight")));
            Assert.AreEqual(driver.FindElement(By.ClassName("WarningText__highlight")).Text, "Возраст детей был установлен на 8 лет.", "No warning about default age of childrens");
            driver.Quit();
        }
    }
}
