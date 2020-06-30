using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Runtime.CompilerServices;

namespace FlightBookingDemo.Utils
{
    class ReportTestManager
    {

        [ThreadStatic]
        private static ExtentTest _parentTest;

        [ThreadStatic]
        private static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest = ReportManager.Instance.CreateTest(testName, description);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _childTest = _parentTest.CreateNode(testName, description);
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest;
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Passed:
                    logstatus = Status.Pass;

                    break;

                case TestStatus.Failed:
                    logstatus = Status.Fail;

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;

                default:
                    logstatus = Status.Fail;
                    break;
            }

          ReportTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
          //  ReportTestManager.GetTest().AddScreenCaptureFromPath("screenshot.png");
           // ReportTestManager.GetTest().Log(logstatus,"hjhj", ReportTestManager.GetTest().AddScreenCaptureFromPath("//ABOLUTE/PATH/IMAGE.PNG"));
        }




    }
}
