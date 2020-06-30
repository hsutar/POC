using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingDemo.Utils
{
    static class LogGenerator
    {


         static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
     
        // one time activity where configure the logg file 
        public static void ConnfigureLogger()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(@"C:\Users\hsutar\source\repos\FlightBookingDemo\FlightBookingDemo\log4net.config"));
        }

        public static void LogInfo(String logsMessage)
        {    
            log.Info(logsMessage);
        }

       
    }
}
