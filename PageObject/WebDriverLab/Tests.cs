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
using WebDriverLab.Pages;

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
            XiStoreMainPage page = new XiStoreMainPage(driver);
            Smartphones smartphonesPage = page.OpenHomePage()
                .OpenSmartphones()
                .RedmiNote8Link()
                .AddToBasketRedmiNote8();
            Audio audioPage = page.OpenHomePage()
                .OpenAudio()
                .RedmiAirDotsLink()
                .AddToBasketRedmiAirDots();
            int totalItemsPrice =
                page.OpenBasketPage()
                .GetTotalPrice();
            Assert.AreEqual(564, totalItemsPrice);
        }

        [Test]
        public void OrderZeroItems()
        {
            XiStoreMainPage page = new XiStoreMainPage(driver);
            Smartphones smartphonesPage = page.OpenHomePage()
                .OpenSmartphones()
                .RedmiNote8Link()
                .AddToBasketRedmiNote8();
            Audio audioPage = page.OpenHomePage()
                .OpenAudio()
                .RedmiAirDotsLink()
                .AddToBasketRedmiAirDots();
            string noItemsInBasket = page
                .OpenBasketPage()
                .RemoveItemFromBasket()
                .RemoveItemFromBasket()
                .GetStatusBasketPage();
            Assert.AreEqual("Вы ничего не добавили в корзину", noItemsInBasket);
        }

        [TearDown]
        public void TearDownTests()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
