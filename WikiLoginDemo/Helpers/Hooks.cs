﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace WikiLoginDemo.Helpers
{
    [Binding]
    public static class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(DriverContext driverContext)
        {
            driverContext.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driverContext.Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
    }
}
