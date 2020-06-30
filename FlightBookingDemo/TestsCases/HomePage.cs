using FlightBookingDemo.PageObjects;
using FlightBookingDemo.PageObjects.PageUtils;
using FlightBookingDemo.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightBookingDemo.TestsCases
{
    
    [TestFixture(BrowserType.Chrome)]
    //[TestFixture(BrowserType.Firefox)]

   // [Parallelizable(ParallelScope.Children)]
    class HomePage : BaseTest
    {
        OneWayFlight oneWayflight;

        // constructor passing the browser type enum value from base class
        public HomePage(BrowserType browserType) : base(browserType)
        {

        }

       

        [Test]
        [Category("Sanity")]
        
        public void SC1TC01_LoadHomePage()
        {
            //            Log.Info("In to OneTimeSetUp");
            LogGenerator.LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Driver().Navigate().GoToUrl("https://www.cleartrip.com/");

        }


        [Test]
        [Category("Regression")]
        // read and return flight details test data from excel file
        [TestCaseSource(typeof(DataProviders), "FlightDetails")]
        public void SC1TC02_SearchOneWayFlight(IDictionary<string, string> parameters)
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
