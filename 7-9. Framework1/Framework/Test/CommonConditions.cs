using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObject;
using Framework.Driver;
using NUnit.Framework.Interfaces;
using log4net;
using log4net.Config;
using Framework.Service;

namespace Framework.Test
{
    public class CommonConditions: TestListener
    {
        protected IWebDriver Driver;
        private static ILog Log = LogManager.GetLogger("LOGGER");
        protected IWebDriver Browser { get; set; }
        [SetUp]
        public void OpenBrowser()
        {
            Driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
        }
        public void Setter()
        {
            Browser = DriverSingleton.GetDriver();
            Logger.InitLogger();
            Logger.Log.Debug("Browser init");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Browser.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Error(TestContext.CurrentContext.Result.Message);
            }
            DriverSingleton.CloseDriver();
        }
    }
}
