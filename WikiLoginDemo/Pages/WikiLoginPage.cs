using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WikiLoginDemo.Helpers;

namespace WikiLoginDemo.Pages
{
    public sealed class WikiLoginPage
    {
        private const string BaseXPath = "//div[@id='userloginForm']/form[@name='userlogin']";

        private readonly DriverContext driverContext;

        public WikiLoginPage(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        public IWebElement UsernameInput => driverContext.Instance
            .FindElement(By.XPath(BaseXPath))
            .FindElement(By.Id("wpName1"));

        public IWebElement PasswordInput => driverContext.Instance
            .FindElement(By.XPath(BaseXPath))
            .FindElement(By.Id("wpPassword1"));

        public IWebElement LoginButton => driverContext.Instance
            .FindElement(By.XPath(BaseXPath))
            .FindElement(By.Id("wpLoginAttempt"));

        public IWebElement ValidationMessage => driverContext.Instance
            .FindElement(By.XPath(BaseXPath))
            .FindElement(By.ClassName("errorbox"));
    }
}
