using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Octane.Framework
{
    class ReadTestData
    {
        int flagIndex;
        public Dictionary<string,string> GetEnvironmentDetails(String excelPath,String sheetName)
        {
            int rowCnt;
            int colCnt;
            int rowIndex;
            int colIndex;
            string flag = "Flag";
            bool foundFlag = false;
            
            Dictionary<string, string> env_Dictionary = new Dictionary<string, string>(); 
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(excelPath);
            Excel.Worksheet worksheet = (Excel.Worksheet) workbook.Sheets[sheetName];
            string cellValue;
            rowCnt = worksheet.UsedRange.Rows.Count;
            colCnt = worksheet.UsedRange.Columns.Count;
            string[] arrColNames = new string[colCnt];
            int arrIndex;

            if (rowCnt > 1)
            {
                for (rowIndex = 1; rowIndex <= rowCnt; rowIndex++)
                {
                    for (colIndex = 1; colIndex <= colCnt; colIndex++)
                    {
                        if (rowIndex == 1)
                        {
                            cellValue =worksheet.Cells[rowIndex, colIndex].Text;
                            if (cellValue == flag)
                            {
                                flagIndex = colIndex;
                            }
                            //Adding column names into an array
                            arrIndex = colIndex - 1;
                            arrColNames[arrIndex] = cellValue;

                        }
                        else
                        {
                            if (worksheet.Cells[rowIndex, flagIndex].Text == "Y")
                            {
                                foundFlag = true;
                                arrIndex = colIndex - 1;
                                cellValue = worksheet.Cells[rowIndex, colIndex].Text;
                                env_Dictionary.Add(arrColNames[arrIndex], cellValue);
                                
                            }
                        }
                    }
                    if (foundFlag)
                    {
                        worksheet = null;
                        workbook = null;
                        xlApp.Quit();
                        xlApp = null;

                        return env_Dictionary;
                    }
                }
            }
            else
            {              
                env_Dictionary.Add("Error", "Environment details not present in the excel");
            }

            if (!foundFlag)
            {
                env_Dictionary.Add("Error", "None of the rows have Flag = Y");
            }
            worksheet = null;
            workbook = null;
            xlApp.Quit();
            xlApp = null;
            return env_Dictionary;
        }

        public IWebDriver GetBrowserType(IWebDriver webDriver, string browser, string driverPath)
        {
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--start-maximized");
                    webDriver = new ChromeDriver(driverPath, option);
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    FirefoxProfile profile = new FirefoxProfile();
                    profile.AcceptUntrustedCertificates = true;
                    webDriver = new FirefoxDriver(profile);
                    break;
                default:     
                    webDriver = new ChromeDriver();
                    break;
            }

            return webDriver;
        }

        public static Dictionary<string,int> GetColumnNames(string excelPath, string sheetName)
        {
         
            int colCnt;
            int rowIndex = 1;
            int colIndex;
            string cellValue;
            int arrIndex;
            Dictionary<string, int> col_Dictionary = new Dictionary<string, int>();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(excelPath);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetName];
            
            colCnt = worksheet.UsedRange.Columns.Count;
   
            for (colIndex = 1; colIndex <= colCnt; colIndex++)
            {          
                  cellValue = worksheet.Cells[rowIndex, colIndex].Text;             
                  //Adding column names into an dictionary object
                  arrIndex = colIndex - 1;
                  col_Dictionary.Add(cellValue, arrIndex);
             }

            worksheet = null;
            workbook = null;
            xlApp.Quit();
            xlApp = null;
            return col_Dictionary;
        }




      







        //public static string[][] GetTestData(String excelPath, String sheetName)
        public static IDictionary<string, string>[] GetTestData(String excelPath, String sheetName)
        {
            int rowCnt;
            int colCnt;
            int rowIndex;
            int colIndex;
            string colValue;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(excelPath);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetName];
            string cellValue;
            rowCnt = worksheet.UsedRange.Rows.Count;
            colCnt = worksheet.UsedRange.Columns.Count;
            Object range = worksheet.UsedRange;
            //string[] arrColNames = new string[colCnt];
            //string[][] testdata = new string[rowCnt-1][];
            IDictionary<string, string>[] testdata = new Dictionary<string, string>[rowCnt - 1];
            Dictionary<string, int> colNames = new Dictionary<string, int>();
            int arrRowIndex;
            int arrColIndex;
            int flagIndex;
            colNames = ReadTestData.GetColumnNames(excelPath, sheetName);
            flagIndex = colNames["Flag"]+1;
            for (rowIndex = 2; rowIndex <= rowCnt; rowIndex++)
            {
                string flag = worksheet.Cells[rowIndex, flagIndex].Text;
                if (flag == "Y")
                {
                    arrRowIndex = rowIndex - 2;
                    //testdata[arrRowIndex] = new string[colCnt];
                    testdata[arrRowIndex] = new Dictionary<string, string>();

                    for (colIndex = 1; colIndex <= colCnt; colIndex++)
                    {
                        cellValue = worksheet.Cells[rowIndex, colIndex].Text;
                        colValue = worksheet.Cells[1, colIndex].Text;
                        //Adding column names into an array
                        arrColIndex = colIndex - 1;
                        //testdata[arrRowIndex] = cellValue;
                        testdata[arrRowIndex].Add(colValue, cellValue);
                    }
                }
            }

            worksheet = null;
            workbook = null;
            xlApp.Quit();
            xlApp = null;
            return testdata;
        }
    }
}
