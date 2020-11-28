using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement PhonesLink = driver.FindElement(By.LinkText("Телефоны"));
            PhonesLink.Click();

            IWebElement RedmiNote8Link = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Redmi Note 8")));
            RedmiNote8Link.Click();

            IWebElement AccessoriesBlock = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("accesuary-item")));
            AccessoriesBlock.Click();

            Assert.NotNull(driver.FindElement(By.Id("aces-block")));
        }

        [TearDown]
        public void TearDownTests()
        {
        }

    }
}
