using System;
using Framework.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class ActionPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.Id, Using = "start_address")]
        public IWebElement startAdress { get; set; }
        [FindsBy(How = How.Id, Using = "end_address")]
        public IWebElement endAdress { get; set; }
        [FindsBy(How = How.ClassName, Using = "moz-button ")]
        public IWebElement button { get; set; }
        [FindsBy(How = How.ClassName, Using = "Searchbox__searchButton--active")]
        public IWebElement clickSearchHotel { get; set; }
        [FindsBy(How = How.Id, Using = "SearchBoxTextDescription__child")]
        public IWebElement countPeople { get; set; }
        [FindsBy(How = How.ClassName, Using = "Autosuggest__TextEditor")]
        public IWebElement serchApartament { get; set; }
        [FindsBy(How = How.ClassName, Using = "Searchbox__searchButton--active")]
        public IWebElement cHotel { get; set; }
        [FindsBy(How = How.ClassName, Using = "SearchBoxTextEditor")]
        public IWebElement sit { get; set; }

        public ActionPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
            Logger.Log.Debug("ActionPage");
        }

        public void Action()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='LinkContainer__Link__text'])[4]")));
            Driver.FindElement(By.XPath("(//*[@class='LinkContainer__Link__text'])[4]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='promotion-card-container'])[1]")));
            Driver.FindElement(By.XPath("(//*[@class='promotion-card-container'])[1]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='btn-search-property'])[1]")));
            Driver.FindElement(By.XPath("(//*[@class='btn-search-property'])[1]")).Click();
            Logger.Log.Debug("Action");

        }

        public string GetUrl()
        {
            return this.Driver.Url;
        }
    }
}
