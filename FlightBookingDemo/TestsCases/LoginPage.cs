using FlightBookingDemo.PageObjects;
using FlightBookingDemo.PageObjects.PageUtils;
using FlightBookingDemo.Utils;
using NUnit.Framework;
using System.Collections.Generic;

namespace FlightBookingDemo.TestsCases
{
    [TestFixture(BrowserType.Chrome)]

    class LoginPage : BaseTest
    {
        OneWayFlight oneWayflight;

        public LoginPage(BrowserType browserType) : base(browserType)
        {

        }


        [Test]
        [Category("Sanity")]
        public void SC2TC01_LaunchOneWayFlightModule()
        {
            // instantiate required page 
            oneWayflight = new OneWayFlight(Driver());

            // launch module
            oneWayflight.LaunchModule();

            // verify module launched
            Assert.AreEqual("Flight bookings, Cheap flights, Lowest Air tickets @Cleartrip", Driver().Title);

        }


        [Test]
        [Category("Regression")]
       // [Category("Sanity")]
        // read and return flight details test data from excel file
        [TestCaseSource(typeof(DataProviders), "FlightDetails")]
        public void SC2TC02_SearchOneWayFlight(IDictionary<string, string> parameters)
        {
            // instantiate required page 
            oneWayflight = new OneWayFlight(Driver());

            string baseURL = Driver().Url.ToString();


            oneWayflight

        // select flight mode
        .SelectFlightMode()


        // enter fromCity
        .SelectCity(CommonElementGroup.txtFromCity, parameters["fromCity"])

        //enter toCity
        .SelectCity(CommonElementGroup.txToCity, parameters["toCity"])

        // select date

        .SelectDepartureDate(parameters["year"], parameters["month"], parameters["day"])


            // set traveller details 
         .SelectAndApplyTravellersDetails()

        //search with selected criteria
        .SubmitCriteriaAndSearchFlight();

            // check next page retrived after submit
            Assert.AreNotEqual(Driver().Url.ToString(), baseURL);


        }




    }
}
