namespace Framework.Tests.Steps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumDriver;
    using System.Linq;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using Infrastructure.Pages;
    using Infrastructure.Controls;
    using System;

    [Binding]
    class PageObjectTestSteps
    {
        MainPage mainPage = PageFactory.GetPage<MainPage>();

        [Given(@"Main page is opened")]
        public void GivenMainPageIsOpened()
            => SeleniumDriver.GetDriver().Navigate().GoToUrl(mainPage.URL);

        [When(@"I search  (\S+)")]
        public void WhenISearchМонитор(string text)
        {
            mainPage.SearchField.SendKeys(text);
        }


        [Then(@"it works!")]
        public void ThenItWorks()
        {
            Console.WriteLine("pageObject is working!");
        }

    }
}
