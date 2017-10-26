using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Octane.Framework;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

namespace Octane.TestCase
{
  
    class MainTestCase
    {    
        ReadTestData objReadData = new ReadTestData();
        Dictionary<string, string> environment_Dict = new Dictionary<string, string>();
        public string envPath = @"C:\Digital_CRO_AutomationSuite\Octane\Octane\TestData\EnvironmentSetUp.xlsx";
        public string envSheetName = "EnvironmentDetails";
     
        public Dictionary<string, string> getEnvDictionary()
        {
            environment_Dict = objReadData.GetEnvironmentDetails(envPath, envSheetName);
            return environment_Dict;
        }     
    }
}
