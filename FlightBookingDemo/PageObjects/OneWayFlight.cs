
using FlightBookingDemo.PageObjects.CommonAction;
using FlightBookingDemo.PageObjects.PageUtils;
using System.Globalization;
using OpenQA.Selenium;
using System;

namespace FlightBookingDemo.PageObjects
{
    class OneWayFlight : BasePage
    {

        public OneWayFlight(IWebDriver driver) : base(driver)
        {

        }

        // select type of flight 
        private By btnSelectOneWayFlightType = By.Id("OneWay");

        // select module
        public OneWayFlight LaunchModule()
        {

            // launch flight module   
            CommonActions.launchModule(driver, CommonElementGroup.btnSelectFlightModule);
		return this;
	}

    // select flight mode
    public OneWayFlight SelectFlightMode()
    {


            CommonActions.selectFlightMode(driver, btnSelectOneWayFlightType);
        //TestLogs.info("OneWayFlight- mdule selected");
        return this;
    }




    // finction to select date 
    public OneWayFlight SelectDepartureDate(String inputYear, String inputMonth, String inputDay)
    {
            // use Calendar class object for using calendar functions to select dates
       GetCalendar cal = new GetCalendar(CommonElementGroup.dateSelectDepartureDate);

            // pass the datepicket textbox 

            cal
        // select year
        .selectYear(driver, inputYear)
        //select month
        .selectMonth(driver, inputMonth)
        //select day
        .selectDay(driver, inputDay);

        return this;



    }

    // enter text and search and select city
    public OneWayFlight SelectCity(By byTxtEnterCity, String searchText) 
    {
            CommonActions.selectCity(driver, byTxtEnterCity, searchText);

		return this;

    }

    // function to select traveller details
    public OneWayFlight SelectAndApplyTravellersDetails()
    {

            // select and apply traveller details
            UICommands.Click(driver,CommonElementGroup.selectAdultTraveller);

            UICommands. Click(driver,CommonElementGroup.selectChildrenTraveller);

            UICommands.Click(driver,CommonElementGroup.selectInfantTraveller);

        //TestLogs.info("OneWayFlight-  traveler details selected");

        return this;

    }

    // submit the information and search the flights
    public OneWayFlight SubmitCriteriaAndSearchFlight()
    {
   
        bool isSubmit=    UICommands.Submit(driver, CommonElementGroup.btnSearchFlight);

        return this;
    }


}
}
