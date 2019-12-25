using System;
using Framework.Models;
using Framework.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class LogInPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signup-email-input']")]
        private IWebElement Email;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signup-password-input']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signup-firstname-input']")]
        private IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'signup-lastname-input']")]
        private IWebElement LastName;
        [FindsBy(How = How.XPath, Using = " //button[@id = 'sign-up-submit-button']")]
        private IWebElement LogInButton;

        //[FindsBy(How = How.XPath, Using = "//*[@id='Login']/div/div/div[@class = 'form-error-block']/div")]
        //private IWebElement ErrorForm;

        public LogInPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
            Logger.Log.Debug("LogInPage");

        }

        public void RegistrUser(User user)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sign-up-btn")));
            Driver.FindElement(By.Id("sign-up-btn")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(Email));
            Email.Click();
            Email.SendKeys(user.Email);
            Driver.FindElement(By.ClassName("iconable-textinput")).SendKeys(Keys.Tab);
            Wait.Until(ExpectedConditions.ElementToBeClickable(Password));
            Password.Click();
            Password.SendKeys(user.Password);
            Wait.Until(ExpectedConditions.ElementToBeClickable(FirstName));
            FirstName.Click();
            FirstName.SendKeys(user.FirstName);
            Wait.Until(ExpectedConditions.ElementToBeClickable(LastName));
            LastName.Click();
            LastName.SendKeys(user.LastName);
            Driver.FindElement(By.Id("sign-up-submit-button")).Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("error-message")));
            Logger.Log.Debug("RegistrUser");

        }

        public LogInPage LogInButtonClick()
        {
            LogInButton.Click();
            Logger.Log.Debug("LogInButtonClick");

            return this;
        }

        //public bool ErrorFormIsEnabled()
        //{
        //    return ErrorForm.Enabled;
        //}
    }
}
