using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest
{
    [TestFixture]
    public class WebDriverTest1
    {
        [Test]

        public void Register_a_new_account()
        {
            IWebDriver driver = new FirefoxDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); ;
            driver.Navigate().GoToUrl("http://agoda.com/");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sign-up-btn")));
            driver.FindElement(By.Id("sign-up-btn")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("iconable-textinput")));
            driver.FindElement(By.ClassName("iconable-textinput")).SendKeys("iraan@mail.r");
            driver.FindElement(By.ClassName("iconable-textinput")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[2]")).Click();
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[2]")).SendKeys("12345678");
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[2]")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[3]")).Click();
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[3]")).SendKeys("Ирина");
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[3]")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[4]")).Click();
            driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[4]")).SendKeys("Андреюк");
            driver.FindElement(By.Id("sign-up-submit-button")).Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("DayPicker-Day__label")));
            //driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[21]")).Click();
            //driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[23]")).Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")));
            //driver.FindElement(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")).Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[2]")));
            //driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[1]")).Click();
            //driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[4]")).Click();
            //driver.FindElement(By.XPath("(//*[@class='sc-kvZOFW bmskzg'])[5]")).Click();
            //driver.FindElement(By.ClassName("Searchbox__searchButton--active")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("error-message")));
            Assert.AreEqual(driver.FindElement(By.ClassName("error-message")).Text, "Формат Адреса Электронной Почты недопустим", "Not found correct warning text");
            driver.Quit();
        }
    }
}
