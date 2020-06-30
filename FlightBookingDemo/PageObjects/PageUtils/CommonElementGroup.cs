using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.PageObjects.PageUtils
{
    class CommonElementGroup
    {
        // gotToHomePage
        public static By btnGoToHomePage = By.Id("GlobalNav");

        public static By btnSelectFlightModule = By.PartialLinkText("Flights");



        //fromCity
        public static By txtFromCity = By.Id("FromTag");

        //toCity
        public static By txToCity = By.Id("ToTag");

        //select city from list
        public static By selectCity = By.LinkText("Pune, IN - Lohegaon (PNQ)");
        //select city from list
        public static By selectToCity = By.LinkText("New Delhi, IN - Indira Gandhi Airport (DEL)");

        //departure date 
        public static By dateSelectDepartureDate = By.Id("DepartDate");
        //departure date 
        public static By dateSelectReturnDate = By.Id("ReturnDate");


        // select year 
        public static By selectYear = By.ClassName("ui-datepicker-year");

        //select month
        public static By selectMonth = By.ClassName("ui-datepicker-month");

        // select day 
        public static By selectDay = By.XPath("//a[contains(text(),'day')]");

        // date navigation forward
        public static By dateNavigateForward = By.XPath("//*[@class='nextMonth ']");

        //date navigation backword
        public static By dateNavigateBackword = By.XPath("//*[@class='prevMonth']");


        // select  number of adult tavellers
        public static By selectAdultTraveller = By.Id("Adults");

        // select  number of chuldren tavellers
        public static By selectChildrenTraveller = By.Id("Childrens");

        // select  number of infant tavellers
        public static By selectInfantTraveller = By.Id("Infants");

        // submit button of traveller info
        public static By btnSearchFlight = By.Id("SearchBtn");
    }
}
