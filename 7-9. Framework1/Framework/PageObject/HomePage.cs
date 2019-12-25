using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;
using Framework.Service;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver Driver;

        private readonly string Url = "https://www.agoda.com/ru-ru/";
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        [FindsBy(How = How.XPath, Using = "//button[@id = 'cookieAcceptButton']")]
        private IWebElement CookieAcceptButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-submit']")]
        private IWebElement FindFlightsButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='page-dialog']/div/ul/li")]
        private IWebElement PageDialog;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'My bookings')]")]
        private IWebElement MyBookings;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-last-name']")]
        private IWebElement FlightsManageLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-pnr']")]
        private IWebElement FlightsManageBookingReference;
        
        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        private IWebElement FlightsOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        private IWebElement FlightsDestinationSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@value = 'RETRIEVE']")]
        private IWebElement RetrieveButtonOnMyBookings;

        [FindsBy(How = How.XPath, Using = "//label[contains(., 'One Way')]")]
        private IWebElement OneWayRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-return-date']")]
        private IWebElement FlightsReturnDate;

        [FindsBy(How = How.XPath, Using = "//span[@id = 'label_fake-adult-input']")]
        private IWebElement CustomFormSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='incInfants']/img")]
        private IWebElement IncrementInfants;

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Planning')]")]
        private IWebElement PlanningButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Help')]")]
        private IWebElement HelpButton;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Flight status')]")]
        private IWebElement FlightStatus;

        [FindsBy(How = How.XPath, Using = "//input[@value = 'CHECK FLIGHT']")]
        private IWebElement CheckFlightButton;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Check-in')]")]
        private IWebElement CheckIn;

        [FindsBy(How = How.XPath, Using = "//*[@id='flights - checkin - form']/fieldset/div[6]")]
        private IWebElement CheckInButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-last-name']")]
        private IWebElement CheckInLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-reservation-number']")]
        private IWebElement CheckInBookingReference;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-originSurrogate']")]
        private IWebElement CheckInOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Help')]")]
        private IWebElement LogIn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[12]']")]
        private IWebElement ErorrForm;

        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(Url);
            Logger.Log.Debug("HomePage");

        }

        public HomePage CookieAcceptClick()
        {
            CookieAcceptButton.Click();
            Logger.Log.Debug("CookieAcceptClick");
            return this;
        }

        public HomePage CheckInButtonClick()
        {
            CheckInButton.Click();
            Logger.Log.Debug("CheckInButtonClick");
            return this;
        }

        public ActionPage GoToPlanningPage()
        {
            PlanningButton.Click();
            Logger.Log.Debug("GoToPlanningPage");

            return new ActionPage(Driver);
        }

        public LogInPage GoToLogInPage()
        {
            LogIn.Click();
            Logger.Log.Debug("GoToLogInPage");
            return new LogInPage(Driver);
        }

        public HelpPage GoToHelpPage()
        {
            HelpButton.Click();
            Logger.Log.Debug("GoToHelpPage");
            return new HelpPage(Driver);
        }

        public HomePage GoToFlightStatus()
        {
            FlightStatus.Click();
            Logger.Log.Debug("GoToFlightStatus");
            return this;
        }

        public HomePage GoToCheckIn()
        {
            CheckIn.Click();
            Logger.Log.Debug("GoToCheckIn");
            return this;
        }

        public HomePage GoToMyBooking()
        {
            MyBookings.Click();
            Logger.Log.Debug("GoToMyBooking");

            return this;
        }

        public SelectFlightsPage FindFlightsButtonClick()
        {
            FindFlightsButton.Click();
            Logger.Log.Debug("FindFlightsButtonClick");

            return new SelectFlightsPage(Driver);
        }

        public HomePage CheckFlightsButtonClick()
        {
            CheckFlightButton.Click();
            Logger.Log.Debug("CheckFlightsButtonClick");

            return this;
        }

        public string GetPageDialogText()
        {
            Logger.Log.Debug("GetPageDialogText");

            return PageDialog.Text;
        }

        public HomePage RetrieveButtonOnMyBookingsClick()
        {
            RetrieveButtonOnMyBookings.Click();
            Logger.Log.Debug("RetrieveButtonOnMyBookingsClick");

            return this;
        }

        public HomePage InputLastNameBookingReferenceAndOriginSurrogateCheckIn(User user, Route route)
        {
            CheckInLastName.SendKeys(user.LastName);
            //CheckInBookingReference.SendKeys(user.BookingReference);
            CheckInOriginSurrogate.SendKeys(route.OriginSurrogate + Keys.Enter);
            Logger.Log.Debug("InputLastNameBookingReferenceAndOriginSurrogateCheckIn");

            return this;
        }

        public HomePage InputLastNameAndBookingReference(User user)
        {
            FlightsManageLastName.SendKeys(user.LastName);
            // FlightsManageBookingReference.SendKeys(user.BookingReference);
            Logger.Log.Debug("InputLastNameAndBookingReference");

            return this;
        }

        public HomePage InputOriginSurrogate(string originSurrogate)
        {
            FlightsOriginSurrogate.Clear();
            FlightsOriginSurrogate.SendKeys(originSurrogate);
            Logger.Log.Debug("InputOriginSurrogate");

            return this;
        }

        public HomePage InputDestinationSurrogate(string destinationSurrogate)
        {
            FlightsDestinationSurrogate.SendKeys(destinationSurrogate + Keys.Enter);
            Logger.Log.Debug("InputDestinationSurrogate");

            return this;
        }

        public HomePage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            Logger.Log.Debug("OneWayRadioButtonClick");

            return this;
        }

        public bool FlightsReturnDateIsEnabled()
        {
            Logger.Log.Debug("FlightsReturnDateIsEnabled");

            return FlightsReturnDate.Enabled;
        }

        public HomePage CustomFormSelectClick()
        {
            CustomFormSelect.Click();
            Logger.Log.Debug("CustomFormSelectClick");

            return this;
        }

        public HomePage IncrementInfantsClick()
        {
            IncrementInfants.Click();
            Logger.Log.Debug("IncrementInfantsClick");

            return this;
        }

        public string GetAttributeButtonInfants()
        {
            Logger.Log.Debug("GetAttributeButtonInfants");

            return IncrementInfants.GetAttribute("style");
        }

        public string GetAttributeErrorForm()
        {
            Logger.Log.Debug("GetAttributeErrorForm");

            return ErorrForm.GetAttribute("style");
        }
    }
}
