using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using Framework.Test;
using Framework.Service;
using Framework.Models;
using System.Threading;
using log4net;

namespace Framework.Test
{
    public class TestClass : CommonConditions
    {
        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference =
            "Please enter a valid reservation number.";

        const string ErrorTextForCheckFlight =
            "Invalid flight number. Ensure it contains numbers only. For example, 123.";

        const string ErrorTextForCheckIn =
            "Please select your departure city";

        const string HelpPageUrl = "https://www.agoda.com/ru-ru/help/";

        const string PlanningPageUrl = "https://www.agoda.com/ru-ru/";

        static private ILog Log = LogManager.GetLogger(typeof(TestClass));

        [Test]
        public void EditingBookingWithChildrenTest()
        {
            Logger.InitLogger();
            HomePage home = new HomePage(Driver);
            BookAHotelPage bookAHotelPage = new BookAHotelPage(Driver);
            bookAHotelPage.Input_Sity("Минск");
            bookAHotelPage.Input_date();
            bookAHotelPage.ClickButtonHotel();
            bookAHotelPage.Check_count_people();
            bookAHotelPage.ClickButtonHotel();
            Assert.AreEqual(Driver.FindElement(By.ClassName("WarningText__highlight")).Text, "Возраст ребенка установлен на 8 лет.", "No warning about default age of childrens");
            Logger.Log.Debug("EditingBookingWithChildrenTest");

        }

        [Test]
        public void SearchHotel()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage searchkAHotelPage = new BookAHotelPage(Driver);
            searchkAHotelPage.Input_Sity("Минск");
            searchkAHotelPage.Input_date();
            searchkAHotelPage.ClickButtonHotel();
            searchkAHotelPage.Serch_Apartament("Apartments Malinovka");
            Thread.Sleep(5000);

            Assert.AreEqual(Driver.FindElement(By.ClassName("InfoBox__HotelTitle")).Text, "Малиновка Комфорт (Malinovka Comfort Apartments)", "No warning Apartments Malinovka");
            Logger.Log.Debug("SearchHotel");

        }

        [Test]
        public void BookingWithChildrenTest()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage bookAHotelPage = new BookAHotelPage(Driver);
            bookAHotelPage.Input_Sity("Минск");
            bookAHotelPage.Input_date();
            //bookAHotelPage.ClickButtonHotel();
            bookAHotelPage.Check_count_people_and_child();
            bookAHotelPage.ClickButtonHotel();
            Assert.AreEqual(Driver.FindElement(By.ClassName("WarningText__highlight")).Text, "Возраст ребенка установлен на 8 лет.", "No warning about default age of childrens");
            Logger.Log.Debug("BookingWithChildrenTest");

        }

        [Test]
        public void VerificationMobilePhone()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage verificationPage = new BookAHotelPage(Driver);
            verificationPage.Verification_Mobile_Phone("336713964","123Qwe123");
            Assert.AreEqual(Driver.FindElement(By.Id("mmb-phone-component-verified-label")).Text, "ПРОВЕРЕН", "Mobile Phone not verification");
            Logger.Log.Debug("VerificationMobilePhone");

        }

        [Test]
        public void VolidationInput()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage verificationPage = new BookAHotelPage(Driver);
            verificationPage.Volidation_Input("336713964");
            Assert.AreEqual(Driver.FindElement(By.ClassName("error-message")).Text, "Необходимо ввести пароль.", "Not Password");
            Logger.Log.Debug("VolidationInput");

        }

        [Test]
        public void FreeBreakfast()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage freebf = new BookAHotelPage(Driver);
            freebf.Input_Sity("Минск");
            freebf.Input_date();
            freebf.ClickButtonHotel();
            freebf.Free_Breakfast();
            Thread.Sleep(5000);
            Assert.AreEqual(Driver.FindElement(By.XPath("(//*[@class='Pill Pill--BenefitsPayments Pill--outlined'])[1]")).Text, "Завтрак", "Not Free BreackFast");
            Logger.Log.Debug("FreeBreakfast");

        }

        [Test]
        public void Action()
        {
            HomePage home = new HomePage(Driver);
            ActionPage act = new ActionPage(Driver);
            act.Action();
            Assert.AreEqual(Driver.FindElement(By.XPath("(//*[@class='promotions-section-header'])[1]")).Text, "Предложения для путешественников", "Not Free BreackFast");
            Logger.Log.Debug("Action");


        }

        [Test]
        public void Swimming()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage freebf = new BookAHotelPage(Driver);
            freebf.Input_Sity("Минск");
            freebf.Input_date();
            freebf.ClickButtonHotel();
            freebf.Also();
            Thread.Sleep(5000);
            Assert.AreEqual(Driver.FindElement(By.XPath("(//*[@class='filter-item-content'])[5]")).Text, "Бассейн", "Not Free BreackFast");
            Logger.Log.Debug("Swimming");

        }

        [Test]
        public void LogInWithIncorrectInformation()
        {
            UserCreator userCreator = new UserCreator();
            HomePage home = new HomePage(Driver);
            LogInPage logInPage = new LogInPage(Driver);
            logInPage.RegistrUser(userCreator.LastNameAndBookingReferenceProperties());

            Assert.AreEqual(Driver.FindElement(By.ClassName("error-message")).Text, "Формат Адреса Электронной Почты недопустим", "Not found correct warning text");
            Logger.Log.Debug("LogInWithIncorrectInformation");

        }

        [Test]
        public void OtherName()
        {
            HomePage home = new HomePage(Driver);
            BookAHotelPage verificationPage = new BookAHotelPage(Driver);
            verificationPage.Verification_Mobile_Phone("336713964", "123Qwe123");
            verificationPage.Other_LastName();
            Assert.AreEqual(Driver.FindElement(By.Id("mmb-name-component-display-name-value")).Text, "Irina AndreyukVodchits", "Mobile Phone not verification");
            Logger.Log.Debug("OtherName");

        }
    }
}
