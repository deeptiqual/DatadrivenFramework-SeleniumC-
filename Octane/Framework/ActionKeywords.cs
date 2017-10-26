using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace Octane.Framework
{
    class ActionKeywords
    {
        public static bool IsDisplayed(IWebElement element, string elementName,int wait)
        {
            bool result;
            try
            {
                result = element.Displayed;   
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool IsEnabled(IWebElement element, string elementName, int wait)
        {
            bool result;
            try
            {
                result = element.Enabled;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static void EnterText(IWebElement element, string elementName, string textToEnter)
        {

            try
            {
                element.Clear();
                if (IsDisplayed(element, elementName, 2))
                {
                    element.SendKeys(textToEnter);
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
        }

        public static void ClickElement(IWebElement element, string elementName)
        {

            //try
            //{
               
                if (IsDisplayed(element, elementName, 2) && IsEnabled(element, elementName,2))
                {
                    element.Click();
                }
                else
                {

                }
            //}
            //catch (Exception)
            //{
            //}
        }

       
    }
}
