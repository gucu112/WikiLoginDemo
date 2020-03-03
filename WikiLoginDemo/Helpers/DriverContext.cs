using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikiLoginDemo.Helpers
{
    public class DriverContext : IDisposable
    {
        private bool instanceCreated = false;

        public DriverContext()
        {
            instanceCreated = true;
            InitChromeDriver();
        }

        public IWebDriver Instance { get; set; }

        public IJavaScriptExecutor JSExecutor => (IJavaScriptExecutor)Instance;

        protected void InitChromeDriver()
        {
            Instance = new ChromeDriver();
        }

        public void Dispose()
        {
            if (instanceCreated)
            {
                Instance.Dispose();
                Instance = null;
                instanceCreated = false;
            }
        }
    }
}
