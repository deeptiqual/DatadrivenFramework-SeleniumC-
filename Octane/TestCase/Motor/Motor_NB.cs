using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Octane.Framework;
using OpenQA.Selenium;


namespace Octane.TestCase.Motor
{
    [TestFixture]
    class Motor_NB : Motor_BaseClass
    {
        ReadTestData ReadDataObj = new ReadTestData();
        Motor_BaseClass MotorObj = new Motor_BaseClass();
        
        Dictionary<string, int> col_Dict = new Dictionary<string, int>();
       
        [TestCaseSource(typeof(Motor_BaseClass), "GetMotorTestData_NB")]
        [Test]
        public void Create_NB_MotorPolicy(IDictionary<string,string> Motor_Row_NB)
        {
            // TestData Variables
            string tc = Motor_Row_NB["TC"];
            string loginID = Motor_Row_NB["LoginID"];
            string password = Motor_Row_NB["Password"];
            string Flow = Motor_Row_NB["Flow"];
            string Registration_No = Motor_Row_NB["Registration_No"];
            string Searched_Car = Motor_Row_NB["Searched_Car"];
            string SearchError = Motor_Row_NB["SearchError"];
            string Make = Motor_Row_NB["Make"];
            string Model = Motor_Row_NB["Model"];
            string Year = Motor_Row_NB["Year"];
            string Body = Motor_Row_NB["Body"];
            string Variant = Motor_Row_NB["Variant"];
            string Address = Motor_Row_NB["Address"];
            
            //Login LoginObj = new Login(driver);
            //if (LoginObj.LoginFirefly(loginID, password))
            //    Assert.Pass("Successfully logged into Firefly using login ID= " + loginID + " and password= " + password);
            

        }  
    }
}
