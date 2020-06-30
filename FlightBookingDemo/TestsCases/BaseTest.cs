
using AventStack.ExtentReports;
using FlightBookingDemo.Resource;
using FlightBookingDemo.Utils;
using log4net;
using NUnit.Framework;
using System;

namespace FlightBookingDemo.TestsCases
{

    class BaseTest : GetBrowser
    {
        public ILog Log;
        

        //protected internal ExtentReports Extent;
        //protected internal ExtentTest ETest;
        public BaseTest(BrowserType browserType): base(browserType)
        {
            // extending the parent class by passing the browser type in parent constructor
            
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            

            LogGenerator.ConnfigureLogger();

            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);
            ReportTestManager.CreateParentTest(GetType().Name);

        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            ReportManager.Instance.Flush();
            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }


        [SetUp]
        public  void InitializeTest()
        {
            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);

            // instantiate method according to browser type input
            SetDriver(browserType);

            // set wait time to load application completely.
            Driver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            
            // set wait time for loading DOM to get element irrespective of application loaded completely or not
            // Driver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            ReportTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            

            // lounch application 
            LounchApplication();

           
        }


       

            [TearDown]
        public void Teardown()
        {
            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);

            ReportTestManager.LogStatus();
            

            // close the driver specific to thread
            Driver().Quit();
        }


        
        public void LounchApplication()
        {
            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Driver().Navigate().GoToUrl("https://www.cleartrip.com/");

        }


    }


    }

