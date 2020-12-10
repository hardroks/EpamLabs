using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebDriverLab.Pages
{
    class XiStoreMainPage
    {
        private static readonly string HOMEPAGE_URL = @"https://xistore.by/";
        private IWebDriver driver;

        public XiStoreMainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public XiStoreMainPage OpenHomePage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            return this;
        }

        public Smartphones OpenSmartphones()
        {
            return new Smartphones(driver);
        }
        public Audio OpenAudio()
        {
            return new Audio(driver);
        }
        public Basket OpenBasketPage()
        {
            return new Basket(driver);
        }
    }
}
