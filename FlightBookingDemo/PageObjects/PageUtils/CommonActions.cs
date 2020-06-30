using FlightBookingDemo.PageObjects.PageUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.PageObjects.CommonAction
{
    class CommonActions
    {
        public static void launchModule(IWebDriver driver, By byLocator)
        {
            try
            {
                driver.FindElement(byLocator).Click();
            }
            catch (Exception e)
            {

                //System.out.println("failed to launch module");
            }
        }

        // go to home page 
        public static void gotoHomePage(IWebDriver driver, By byLocator)
        {
            driver.FindElement(byLocator).Click();
        }

        // select flightType
        public static void selectFlightMode(IWebDriver driver, By byLocator)
        {
            driver.FindElement(byLocator).Click();
        }

        // search button 
        public static void submitCriteriaAndSearchFlights(IWebDriver driver, By byLocator)
        {
            driver.FindElement(byLocator).Submit();
        }

        // search city with autocomplete
        public static void selectCity(IWebDriver driver,By byTxtEnterCity, String searchText)
        {
            // find textbox to enter value
            IWebElement txtSelectTextBox = driver.FindElement(byTxtEnterCity);

            // clear the text if existing
            txtSelectTextBox.Clear();

            // enter text in textbox
            txtSelectTextBox.SendKeys(searchText);

            // always select the firet option from autocomplete
            By selectFirstoption = By.XPath("//*[@class='autoComplete']/li[1]/a[1 and contains(text(), '" + searchText + "')]");

            UICommands.Click(driver, selectFirstoption);

            //TestLogs.info("OneWayFlight-  city selected");
            

        }

    }
}
