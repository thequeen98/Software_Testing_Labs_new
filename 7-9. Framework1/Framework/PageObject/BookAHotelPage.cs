using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using System.Threading;
using Framework.Service;

namespace Framework.PageObject
{
    public class BookAHotelPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

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

        [FindsBy(How = How.ClassName, Using = "sc-gqjmRU xwqmv")]
        public IWebElement inputInAccount { get; set; }
        [FindsBy(How = How.Id, Using = "switcher-tab-mobile")]
        public IWebElement checkMobilePhone { get; set; }
        [FindsBy(How = How.ClassName, Using = "phoneNumber__input")]
        public IWebElement mobilePhone { get; set; }
        [FindsBy(How = How.Id, Using = "mobile-signin-button")]
        public IWebElement register { get; set; }

        [FindsBy(How = How.Id, Using = "login-input-box")]
        public IWebElement passvord { get; set; }
        [FindsBy(How = How.Id, Using = "sign-in-submit-button")]
        public IWebElement threeStripe { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "signin-text")]
        public IWebElement button { get; set; }
        [FindsBy(How = How.ClassName, Using = "profile-menu__text")]
        public IWebElement profile { get; set; }
        
        public void Verification_Mobile_Phone (string mobile_phone, string passvordd)
        {
            
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sign-in-btn")));
            Driver.FindElement(By.Id("sign-in-btn")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(checkMobilePhone));
            checkMobilePhone.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(mobilePhone));
            mobilePhone.Click();
            mobilePhone.SendKeys(mobile_phone);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='login-input-box'])[3]")));
            Driver.FindElement(By.XPath("(//*[@class='login-input-box'])[3]")).Click();
            Driver.FindElement(By.XPath("(//*[@class='form-control iconable-textinput '])[3]")).SendKeys("123Qwe123");
            
            Wait.Until(ExpectedConditions.ElementToBeClickable(register));
            register.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(button));
            button.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(profile));
            profile.Click();
            Logger.Log.Debug("Verification_Mobile_Phone");

        }

        public void Free_Breakfast()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='c-toggle__switch'])[2]")));
            Driver.FindElement(By.XPath("(//*[@class='c-toggle__switch'])[2]")).Click();
            Logger.Log.Debug("Click Free_Breakfast");

        }

        public void Volidation_Input(string mobile_phone)
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sign-in-btn")));
            Driver.FindElement(By.Id("sign-in-btn")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(checkMobilePhone));
            checkMobilePhone.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(mobilePhone));
            mobilePhone.Click();
            mobilePhone.SendKeys(mobile_phone);
            Wait.Until(ExpectedConditions.ElementToBeClickable(register));
            register.Click();
            Logger.Log.Debug("Volidation_Mobile_Phone");

        }

        public BookAHotelPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            Logger.Log.Debug("BookAHotelPage");

        }

        public void Input_Sity(string sityy)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(sity));
            sity.Click();
            sity.SendKeys(sityy);
            Wait.Until(ExpectedConditions.ElementToBeClickable(dopSity));
            dopSity.Click();
            Logger.Log.Debug("Input_Sity");

        }

        public void Input_date()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(date));
            Driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[27]")).Click();
            Driver.FindElement(By.XPath("(//*[@class='DayPicker-Day__label'])[29]")).Click();
            Logger.Log.Debug("Input_date");

        }
        public void Check_count_people()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='IconBox__child'])[4]")));
            Thread.Sleep(5000);
            Driver.FindElement(By.XPath("(//*[@class='IconBox__child'])[4]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__description'])[3]")));
            Driver.FindElement(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__description'])[3]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='sc-hmzhuo buMYHM'])[4]")));
            Driver.FindElement(By.XPath("(//*[@class='sc-hmzhuo buMYHM'])[4]")).Click();
            Logger.Log.Debug("Check_count_people");

        }
        public void Check_count_people_and_child()
        {

            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")));
            Driver.FindElement(By.XPath("(//*[@class='TravellerSegment__row TravellerSegment__title'])[3]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='sc-hmzhuo buMYHM'])[2]")));
            Driver.FindElement(By.XPath("(//*[@class='sc-hmzhuo buMYHM'])[1]")).Click();
            Driver.FindElement(By.XPath("(//*[@class='sc-hmzhuo buMYHM'])[4]")).Click();
            Logger.Log.Debug("Check_count_people_and_child");

        }
        public void ClickButtonHotel()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(clickSearchHotel));
            clickSearchHotel.Click();
            Logger.Log.Debug("ClickButtonHotel");

        }
        public void Serch_Apartament(string name_apartament)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(serchApartament));
            serchApartament.Click();
            Thread.Sleep(5000);
            serchApartament.SendKeys(name_apartament);
            serchApartament.SendKeys(Keys.Enter);
            Logger.Log.Debug("Serch_Apartament");


        }
        public void Also()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='btn PillDropdown__Button'])[5]")));
            Driver.FindElement(By.XPath("(//*[@class='btn PillDropdown__Button'])[5]")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//*[@class='filter-item-content'])[5]")));
            Driver.FindElement(By.XPath("(//*[@class='filter-item-content'])[5]")).Click();
            Logger.Log.Debug("Also");

        }
        public void Other_LastName()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mmb-name-component-display-edit-label")));
            Driver.FindElement(By.Id("mmb-name-component-display-edit-label")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mmb-name-component-change-lastname")));
            Driver.FindElement(By.Id("mmb-name-component-change-lastname")).Click();
            Driver.FindElement(By.Id("mmb-name-component-change-lastname")).SendKeys("Vodchits");
            Thread.Sleep(5000);
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mmb-name-component-change-save")));
            Driver.FindElement(By.Id("mmb-name-component-change-save")).Click();
            Thread.Sleep(5000);
            Logger.Log.Debug("Other_LastName");
        }
    }
}
