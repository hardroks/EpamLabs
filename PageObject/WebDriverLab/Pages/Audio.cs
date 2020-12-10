using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebDriverLab.Pages
{
    class Audio
    {
        private const string PAGE_URL = "https://xistore.by/catalog/audio/";

        private IWebDriver driver;
        [FindsBy(How = How.LinkText, Using = "Беспроводные наушники Redmi AirDots")]
        protected readonly IWebElement RedmiAirDots;

        [FindsBy(How = How.Id, Using = "bx_2369550383_8393_buy_link")]
        protected readonly IWebElement addButton;

        public Audio(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public Audio RedmiAirDotsLink()
        {
            Thread.Sleep(1000);
            RedmiAirDots.Click();
            return this;
        }
        public Audio AddToBasketRedmiAirDots()
        {
            Thread.Sleep(1000);
            addButton.Click();
            return this;
        }
    }
}
