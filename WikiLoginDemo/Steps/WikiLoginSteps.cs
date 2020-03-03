using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WikiLoginDemo.Entity;
using WikiLoginDemo.Helpers;
using WikiLoginDemo.Pages;
using Xunit;

namespace WikiLoginDemo.Steps
{
    [Binding]
    public class WikiLoginSteps
    {
        private readonly DriverContext driverContext;

        private readonly WikiPersonalBarSection personalBar;

        private readonly WikiLoginPage loginPage;

        private User testUser;

        public WikiLoginSteps(DriverContext driverContext)
        {
            this.driverContext = driverContext;
            personalBar = new WikiPersonalBarSection(driverContext);
            loginPage = new WikiLoginPage(driverContext);
        }

        [Given(@"The user that exists")]
        public void GivenTheUserThatExists()
        {
            testUser = new User
            {
                Username = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"]
            };
        }

        [Given(@"Wikipedia login page")]
        public void GivenWikipediaLoginPage()
        {
            driverContext.Instance.Navigate().GoToUrl(
                ConfigurationManager.AppSettings["BaseUrl"]);
            personalBar.LoginPageLink.Click();
        }

        [When(@"The user enters provided credentials")]
        public void WhenTheUserEntersProvidedCredentials()
        {
            loginPage.UsernameInput.SendKeys(testUser.Username);
            loginPage.PasswordInput.SendKeys(testUser.Password);
        }

        [When(@"The user clicks login button")]
        public void WhenTheUserClicksLoginButton()
        {
            loginPage.LoginButton.Click();
        }

        [When(@"The user enters ""(.*)"" in ""(.*)"" field")]
        public void WhenTheUserEntersInField(string text, string field)
        {
            switch (field.ToLower())
            {
                case "username":
                    loginPage.UsernameInput.SendKeys(text);
                    break;
                case "password":
                    loginPage.PasswordInput.SendKeys(text);
                    break;
            }
        }

        [Then(@"The user should be logged in")]
        public void ThenTheUserShouldBeLoggedIn()
        {
            Assert.True(personalBar.IsUserLoggedIn(testUser),
                "User is not logged in.");
        }

        [Then(@"The user should not be logged in")]
        public void ThenTheUserShouldNotBeLoggedIn()
        {
            Assert.False(personalBar.IsUserLoggedIn(),
                "User is logged in.");
        }

        [Then(@"Validation message for ""(.*)"" should appear")]
        public void ThenValidationMessageForShouldAppear(string field)
        {
            IWebElement element;
            switch (field.ToLower())
            {
                case "username":
                    element = loginPage.UsernameInput;
                    break;
                case "password":
                    element = loginPage.PasswordInput;
                    break;
                default:
                    element = null;
                    break;
            }
            AssertCustom.HTML5ValidationPresent(driverContext, element);
        }

        [Then(@"Validation message for incorrect credentials should appear")]
        public void ThenValidationMessageForIncorrectCredentialsShouldAppear()
        {
            Assert.True(
                new WebDriverWait(driverContext.Instance, TimeSpan.FromSeconds(3))
                    .Until((IWebDriver driver) => loginPage.ValidationMessage.Displayed),
                "Incorrect credentials validation message was not shown in 3 seconds.");
        }

    }
}
