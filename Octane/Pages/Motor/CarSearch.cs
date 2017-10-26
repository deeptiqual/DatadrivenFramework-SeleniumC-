using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Octane.Framework;
using Octane.TestCase;

namespace Octane.Pages.Common
{
    class CarSearch
    {
        private IWebDriver driver;
        MainTestCase maintc = new MainTestCase();
        public CarSearch(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//input[@ng-model='vm.registrationNumber']")]
        private IWebElement regNumber;

        [FindsBy(How = How.XPath, Using = ".//div[contains(@data-analytics-id,'VehicleRegistrationLookup_FindByRegestration')]")]
        private IWebElement search;

        [FindsBy(How = How.XPath, Using = ".//div[@ng-model='Car.Vehicle.Make' and contains(@class, 'ng - valid')]")]
        private IWebElement carSearched;

        public bool searchByRegNo(string RegNo)
        {
            if (RegNo != null)
            {
                ActionKeywords.EnterText(regNumber, "Registration Number", RegNo);
              
                ActionKeywords.ClickElement(search, "Search");

                if (!ActionKeywords.IsDisplayed(carSearched, "UserName", 2))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
