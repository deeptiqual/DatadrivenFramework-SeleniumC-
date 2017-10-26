using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Octane.Framework;
using Excel = Microsoft.Office.Interop.Excel;

namespace Octane.TestCase
{
    [TestFixture]
    class Motor_BaseClass : MainTestCase
    {
        //Declare variables
        public IWebDriver driver;
        ReadTestData objReadData = new ReadTestData();
        Dictionary<string, string> environment_Dict = new Dictionary<string, string>();
        public string driverPath = @"C:\Digital_CRO_AutomationSuite\Octane\Octane\Drivers\";
        public static string motorTestDataPath = @"C:\Digital_CRO_AutomationSuite\Octane\Octane\TestData\Test_Data.xlsx";
        public static string motorTestSheetName = "MotorNBTestData";
        public string browser = "Browser";
        public string url = "Motor_URL";

        [SetUp]
        public void Setup()
        {
            environment_Dict = getEnvDictionary();
            if (environment_Dict.Keys.Contains("Error"))
            {
                Console.Write(environment_Dict["Error"]);
                Environment.Exit(0);
            }
            // Set driver for browser
            driver = objReadData.GetBrowserType(driver, environment_Dict[browser], driverPath);
           
            //Navigate to the url
            driver.Navigate().GoToUrl(environment_Dict[url]);

        }

        [TearDown]
        public void TearDown()
        {
            //Close the browser
            driver.Close();
            driver = null;
        }

        public static IDictionary<string, string>[] GetMotorTestData_NB
        {
            get
            {
                IDictionary<string, string>[] data = ReadTestData.GetTestData(motorTestDataPath, motorTestSheetName);
                return data;
            }
        }


    }
}
