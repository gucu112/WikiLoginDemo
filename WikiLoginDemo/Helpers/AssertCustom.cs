using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Xunit;

namespace WikiLoginDemo.Helpers
{
    public static class AssertCustom
    {
        public static void HTML5ValidationPresent(DriverContext driverContext, IWebElement element)
        {
            if (Convert.ToBoolean(element.GetAttribute("required")))
            {
                Assert.False((bool)driverContext.JSExecutor
                    .ExecuteScript("return arguments[0].validity.valid;", element),
                    "HTML5 validation pop-up is not present.");
            }
        }
    }
}
