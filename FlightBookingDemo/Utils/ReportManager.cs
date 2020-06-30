using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.IO;

namespace FlightBookingDemo.Utils
{
    class ReportManager
    {
        private static readonly Lazy<ExtentReports> _lazy
            = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }

        static ReportManager()
        {
            var htmlReporter = new ExtentHtmlReporter(SetReportPath());
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "Extent/NUnit Samples";
            htmlReporter.Configuration().ReportName = "Extent/NUnit Samples";
            htmlReporter.Configuration().Theme = Theme.Standard;

            Instance.AttachReporter(htmlReporter);
        }

        private ReportManager()
        {
        }


        private static string SetReportPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", string.Empty);
            DirectoryInfo di = Directory.CreateDirectory(path + "\\Test_Execution_Reports\\" + DateTime.Now.ToString("yyyyMMM") + "\\" + DateTime.Now.ToString("dd") + "\\" + DateTime.Now.ToString("dd_HHmm"));
            string reportpath = path + "Test_Execution_Reports\\" + DateTime.Now.ToString("yyyyMMM") + "\\" + DateTime.Now.ToString("dd") + "\\" + DateTime.Now.ToString("dd_HHmm") + "\\AutomationReport.html";
            return reportpath;
        }
    }
}
