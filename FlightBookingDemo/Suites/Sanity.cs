using FlightBookingDemo.TestsCases;
using System;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.Suites
{
     class Sanity
    {
        
        public static IEnumerable Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(typeof(HomePage));
                suite.Add(typeof(LoginPage));

                return suite;
            }
        }      }
}
