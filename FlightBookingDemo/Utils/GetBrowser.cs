using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace FlightBookingDemo.Resource
{

    public class GetBrowser
    {
        // store thread-specific pieces of data driver
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //get browsertype string value from enum
        public BrowserType browserType;

        // enum to maintain the browser types
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }

        // constructor which calls the getDriver method
        public GetBrowser(BrowserType browserType)
        {
            // pass the browsertype value in constructor
            this.browserType = browserType;
        }



        // GetDriver method which returns driver instance
        public IWebDriver SetDriver(BrowserType browserType)
        {
            // instantiate the driver
            switch (browserType)
            {
                case BrowserType.Firefox:

                    GetFireFoxDriver();
                    break;

                case BrowserType.Chrome:
                    GetChromeDriver();

                    break;

                default:
                    GetChromeDriver();
                    break;
            }


            // return the driver instance
            return Driver();

        }



        // method to return driver instance
        public IWebDriver Driver()
        {
            return driver.Value;
        }


        // get chrome driver
        private void GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver.Value = new ChromeDriver("D:\\Selenium\\Unit", options);

        }
        // get chrome driver
        private void GetFireFoxDriver()
        {
            driver.Value = new FirefoxDriver("D:\\Selenium\\Unit");

        }





    }
}
