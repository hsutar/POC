using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace FlightBookingDemo.PageObjects.PageUtils
{
    class Wait  
    {

        // explicit wait specific to webelement with any kind of conditions 
        public static IWebElement WaitUntil(Func<IWebDriver, IWebElement> expectedCondtions, 
            int timeoutInSeconds , IWebDriver driver)
        {
            // instantiate webdriver wait  
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            // wait until input wait conditions
            return webDriverWait.Until(expectedCondtions);
        }

        // stop execution and wait for required time in seconds
        public static void HardWait(int timeInSeconds)
        {
            Thread.Sleep(timeInSeconds);
        }

        

    }
}
