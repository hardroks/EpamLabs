using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverLab
{
    class Tests
    {
        IWebDriver driver;
        

        [SetUp]
        public void SetupTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://xistore.by");
        }

        [Test]
        public void AddTwoItemsToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("https://xistore.by/catalog/telefony/");

            IWebElement RedmiNote8 = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Redmi Note 8")));
            RedmiNote8.Click();

            IWebElement AddRedmiNote8ToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("bx_2369550383_10342_buy_link")));
            AddRedmiNote8ToCart.Click();

            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://xistore.by/catalog/audio/");

            IWebElement RedmiAirDots = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Беспроводные наушники Redmi AirDots")));
            RedmiAirDots.Click();

            IWebElement AddRedmiAirDotsToCart = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("bx_2369550383_8393_buy_link")));
            AddRedmiAirDotsToCart.Click();

            IWebElement BasketItems = wait.Until(ExpectedConditions.ElementExists(By.Id("basket_items")));

            string RedmiNote8Price = BasketItems.FindElement(By.XPath("tbody/tr[1]/td[3]/div[1]")).Text;
            string RedmiAirDotsPrice = BasketItems.FindElement(By.XPath("tbody/tr[2]/td[3]/div[1]")).Text;
            string SummarizedPrice = driver.FindElement(By.Id("allSum_FORMATED")).Text;

            Assert.AreEqual(GetPrice(SummarizedPrice), GetPrice(RedmiNote8Price) + GetPrice(RedmiAirDotsPrice));
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }
        int GetPrice(string price)
        {
            price = price.Split(',')[0];
            return int.Parse(new string(price.Where(t => char.IsDigit(t)).ToArray()));
        }

    }
}
