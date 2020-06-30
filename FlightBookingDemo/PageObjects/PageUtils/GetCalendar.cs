using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.PageObjects.PageUtils
{
    class GetCalendar
    {
        readonly By byGetYear = CommonElementGroup.selectYear;

        readonly  By byGetMonth = CommonElementGroup.selectMonth;

        readonly By byNavigateToForward = CommonElementGroup.dateNavigateForward;

        readonly By byNavigateToBackword = CommonElementGroup.dateNavigateBackword;

        // departure
        private   By byClickOnCalendar;
        private String inputYear;
        private String inputMonth;
        private String inputDay;




        public GetCalendar(By byClickOnCalendar, String inputYear, String inputMonth, String inputDay)

        {
            //driver=super.driver;
            this.byClickOnCalendar = byClickOnCalendar;
            this.inputYear = inputYear;
            this.inputMonth = inputMonth;
            this.inputDay = inputDay;

        }

        public GetCalendar(By byClickOnCalendar)

        {
            //driver=super.driver;
            this.byClickOnCalendar = byClickOnCalendar;

        }


        // method to select year
        public GetCalendar selectYear(IWebDriver driver, string year)
        {
            bool isYearSelected = false;

            // Click on date text box to select date
            //driver.FindElement(byClickOnCalendar).Click();
            UICommands.Click(driver, byClickOnCalendar);

            // check and select year
            while (!isYearSelected)
            {
                // read present year on calendar pop up
               // String webelementYear = driver.FindElement(byGetYear).Text;
                String webelementYear = UICommands.GetPresentText(driver, byGetYear);

                // provided year is higher , move next
                if (Int32.Parse(year) > Int32.Parse(webelementYear))
                {
                    //driver.FindElement(byNavigateToForward).Click();
                    UICommands.Click(driver, byNavigateToForward);
                    // TestLogs.info("OneWayFlight-  year selected");
                }
                //provided year is lesser , move backword
                else if (Int32.Parse(year) < Int32.Parse(webelementYear))
                {
                   // driver.FindElement(byNavigateToBackword).Click();
                    UICommands.Click(driver, byNavigateToBackword);
                    //TestLogs.info("OneWayFlight-  year selected");
                }
                else
                {
                    isYearSelected = true;

                }
            }
            return this;
        }

        //method to select month
        public GetCalendar selectMonth(IWebDriver driver , string month)
        {
            String webelementMonth;
            //		check and select month

           // webelementMonth = driver.FindElement(byGetMonth).Text;
            webelementMonth = UICommands.GetPresentText(driver, byGetMonth);

            if (!webelementMonth.Contains(month))
            {
                
              
                // select january first
                while (!webelementMonth.Contains("January") && UICommands.IsElementClickable(driver,byNavigateToBackword)==true) // && check back button is not disabled
                {

                    //driver.FindElement(byNavigateToBackword).Click();
                    UICommands.Click(driver, byNavigateToBackword);
                    //webelementMonth = driver.FindElement(byGetMonth).Text;
                    webelementMonth = UICommands.GetPresentText(driver, byGetMonth);
                }


                // then select the input month
                while (!webelementMonth.Contains(month))
                {
                  //  driver.FindElement(byNavigateToForward).Click();
                    UICommands.Click(driver, byNavigateToForward);
                    //webelementMonth = driver.FindElement(byGetMonth).Text;
                    webelementMonth = UICommands.GetPresentText(driver, byGetMonth);

                }
            }
            return this;
        }

        //method to select day
        public GetCalendar selectDay(IWebDriver driver, string day)
        {
            // select day

            By selectDay = By.XPath("//a[contains(text(),'" + day + "')]");
           // IWebElement selectDay = driver.FindElement(By.XPath("//a[contains(text(),'" + inputDay + "')]"));

            UICommands.Click(driver, selectDay);

            //selectDay.Click();

           // TestLogs.info("OneWayFlight-  date selected");
            return this;
        }



    }
}
