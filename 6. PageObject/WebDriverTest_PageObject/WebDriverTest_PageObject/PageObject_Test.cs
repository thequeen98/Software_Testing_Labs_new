using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace WebDriverTest_PageObject
{
    class PageObject_HotelTest
    {
        IWebDriver driver;
        WebDriverWait wait;

        [FindsBy(How = How.ClassName, Using = "SearchBoxTextEditor")]
        public IWebElement sity { get; set; }
        [FindsBy(How = How.ClassName, Using = "Suggestion__geoHierarchyName")]
        public IWebElement dopSity { get; set; }
        [FindsBy(How = How.ClassName, Using = "DayPicker-Day__label")]
        public IWebElement date { get; set; }
        [FindsBy(How = How.ClassName, Using = "Searchbox__searchButton--active")]
        public IWebElement clickSearchHotel { get; set; }
        [FindsBy(How = How.Id, Using = "SearchBoxTextDescription__child")]
        public IWebElement countPeople { get; set; }
        [FindsBy(How = How.ClassName, Using = "Autosuggest__TextEditor")]
        public IWebElement serchApartament { get; set; }

        public PageObject_HotelTest(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl("http://agoda.com/");
        }
        
        public void Input_Sity(string sityy)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(sity));
            sity.Click();
            sity.SendKeys(sityy);
            wait.Until(ExpectedConditions.ElementToBeClickable(dopSity));
            dopSity.Click();
        }
        public void Input_date()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(date));
            driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[21]")).Click();
            driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[23]")).Click();

        }
        public void Check_count_people()
        {
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='IconBox__child'])[4]")));
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//*[@class='IconBox__child'])[4]")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")));
            driver.FindElement(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='sc-frDJqD AziLL'])[4]")));
            driver.FindElement(By.XPath("(//*[@class='sc-frDJqD AziLL'])[4]")).Click();
        }
        public void ClickButtonHotel()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(clickSearchHotel));
            clickSearchHotel.Click();
        }
        public void Serch_Apartament(string name_apartament)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(serchApartament));
            serchApartament.Click();
            Thread.Sleep(5000);
            serchApartament.SendKeys(name_apartament);
            serchApartament.SendKeys(Keys.Enter);
            
        }

    }
}
