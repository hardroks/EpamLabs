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
    class Smartphones
    {
        private const string PAGE_URL = "https://xistore.by/catalog/telefony/";

        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Redmi Note 8")]
        protected readonly IWebElement RedmiNote8;

        [FindsBy(How = How.Id, Using = "bx_2369550383_10342_buy_link")]
        protected readonly IWebElement addButton;

        public Smartphones(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public Smartphones RedmiNote8Link()
        {
            RedmiNote8.Click();
            return this;
        }
        public Smartphones AddToBasketRedmiNote8()
        {
            Thread.Sleep(1000);
            addButton.Click();
            return this;
        }

    }
}
