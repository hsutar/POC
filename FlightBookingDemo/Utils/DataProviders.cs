using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.Utils
{
    class DataProviders
    {

        // function returns flightdetails test data from excel
        public static IEnumerable FlightDetails
        {
            get { return Utils.ExcelReader.ReadXlsxDataDriveFile("D:\\Selenium\\TestData.xlsx", "TC01_VerifyOneWayFlightBooking"); }
                    
        }

        public static IEnumerable GenericData
        {
            get { return Utils.ExcelReader.ReadXlsxDataDriveFile("D:\\Selenium\\TestData.xlsx", "GenericData"); }

        }

    }
}
