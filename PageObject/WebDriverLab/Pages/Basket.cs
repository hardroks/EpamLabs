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
    class Basket
    {
        private const string PAGE_URL = "https://xistore.by/personal/basket/";

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "allSum_FORMATED")]
        protected readonly IWebElement totalPrice;

        [FindsBy(How = How.ClassName, Using = "basket-empty-title")]
        protected readonly IWebElement basketEmpty;

        [FindsBy(How=How.ClassName, Using = "icon-close")]
        protected readonly IWebElement removeItemFromBasket;

        public Basket(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            Thread.Sleep(1000);
            PageFactory.InitElements(driver, page: this);
        }

        public string GetStatusBasketPage()
        {
            return basketEmpty.Text;
        }

        public int GetTotalPrice()
        {
            return int.Parse(totalPrice.Text.Split(',')[0]);
        }

        public Basket RemoveItemFromBasket()
        {
            Thread.Sleep(1000);
            removeItemFromBasket.Click();
            return this;
        }
    }
}
