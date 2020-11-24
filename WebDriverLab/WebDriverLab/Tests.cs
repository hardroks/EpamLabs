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
            IWebElement PhonesLink = driver.FindElement(By.LinkText("Телефоны"));
            PhonesLink.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Phones = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[5]/div/div/div[3]/div[2]/div/div[4]/a")));

            IWebElement goToRedmiNote8 = driver.FindElement(By.XPath("/html/body/div[2]/div[5]/div/div/div[3]/div[2]/div/div[4]/a"));
            goToRedmiNote8.Click();

            IWebElement RedmiNote8 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[5]/div[3]/div[1]/div/div/div/nav/ul/li[3]")));

            IWebElement goToAccessories = driver.FindElement(By.XPath("/html/body/div[2]/div[5]/div[3]/div[1]/div/div/div/nav/ul/li[3]"));
            goToAccessories.Click();

            IWebElement accessories = wait.Until(ExpectedConditions.ElementExists(By.Id("aces-block")));

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, 1250);");

            Assert.NotNull(driver.FindElement(By.Id("aces-block")));
        }

        [TearDown]
        public void TearDownTests()
        {
        }

    }
}
