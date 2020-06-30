using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.PageObjects
{
    class BasePage
    {
        // base page local driver
        protected IWebDriver driver;
        


        // get driver instance from calling class in basepage constructor
        public BasePage(IWebDriver driver)
        {
            // set the driver
            this.driver = driver;

        }


       



    }
}
