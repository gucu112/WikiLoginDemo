using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WikiLoginDemo.Entity;
using WikiLoginDemo.Helpers;

namespace WikiLoginDemo.Pages
{
    public sealed class WikiPersonalBarSection
    {
        private const string BaseId = "p-personal";

        private readonly DriverContext driverContext;

        public WikiPersonalBarSection(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        public IWebElement UserPageLink => driverContext.Instance
            .FindElement(By.Id(BaseId))
            .FindElement(By.Id("pt-userpage"))
            .FindElement(By.TagName("a"));

        public IWebElement LoginPageLink => driverContext.Instance
            .FindElement(By.Id(BaseId))
            .FindElement(By.Id("pt-login"))
            .FindElement(By.TagName("a"));

        public bool IsUserLoggedIn(User testUser = null)
        {
            try
            {
                driverContext.Instance.FindElement(By.Id(BaseId))
                    .FindElement(By.Id("pt-anonuserpage"));
            }
            catch (WebDriverException)
            {
                if (UserPageLink.Text.Trim() == testUser?.Username)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
