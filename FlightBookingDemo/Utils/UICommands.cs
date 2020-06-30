using OpenQA.Selenium;
using System;

namespace FlightBookingDemo.PageObjects.PageUtils
{
    class UICommands 
    {

        

        public static void Click(IWebDriver driver, By by)
        {
            if (IsElementDisplayed(driver, by) == true)
            {
               

                try
                {
                    // wait 10 seconds untill clickable
                    Wait.WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by), 10, driver);
                    
                    // click
                    driver.FindElement(by).Click();
                }
                catch (TimeoutException )
                {
                  //  test.log(logStatus.Error, "Element identified by " + by.toString() + " was not clickable after 10 seconds");
                }

               
            }
            else
            {

            }

            
        }

        public static string GetPresentText(IWebDriver driver, By by)
        {
            return driver.FindElement(by).Text;
        }



        public static bool IsElementDisplayed(IWebDriver driver, By by)
        {
            // wait untill 30 seconds to get displayed
            Wait.WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by), 30, driver);

            return driver.FindElement(by).Displayed;
        }

        public static bool IsElementClickable(IWebDriver driver, By by)
        {
            try
            {
                // wait untill 30 seconds to get displayed
                Wait.WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by), 4, driver);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
         
        }

        public static bool Submit(IWebDriver driver, By by)
        {
            bool isSubmitted = false;
            string currentURL=string.Empty;

            if (IsElementDisplayed(driver, by) == true)
            {

                try
                {
                    // wait 10 seconds untill clickable
                    Wait.WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by), 10, driver);

                    // get existing url before submit
                    currentURL = driver.Url.ToString();

                    // submit the form
                    driver.FindElement(by).Submit();

                    // check next page loaded or not
                    if(currentURL != driver.Url.ToString())
                    {

                        return isSubmitted = true;
                    }
                    
                    
                }
                catch (TimeoutException toe)
                {
                    //  test.log(logStatus.Error, "Element identified by " + by.toString() + " was not clickable after 10 seconds");
                    return isSubmitted = false;
                }

                
            }
            else
            {

            }
            return isSubmitted;
        }






    }
}
