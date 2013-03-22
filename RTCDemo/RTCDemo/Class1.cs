using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace RTCDemo
{
    [TestFixture]
    public class TestGoogle
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new InternetExplorerDriver();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleSomething()
        {
            //open browser and go to google
            driver.Navigate().GoToUrl("http://www.google.com");
            
            //find the text input element by the name
            IWebElement query = driver.FindElement(By.Name("q"));

            //enter a search query
            query.SendKeys("Selenium");

            query.Submit();

            //wait for 10 seconds, or the page title to start with selenium, whichever comes first
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            w.Until((d) => { return d.Title.StartsWith("selenium"); });
            
            Assert.AreEqual("selenium - Google Search", driver.Title);
        }

        [Test]
        public void FeelingLucky()
        {
            //open browser and go to google
            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement b = driver.FindElements(By.ClassName("gbqfba"))[1];
            b.Click();

            //wait for 10 seconds, or the page title to start with selenium, whichever comes first
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            w.Until((d) => { return d.Title.StartsWith("Doodles"); });

            Assert.AreNotEqual("selenium - Google Search", driver.Title);

        }
    }
}
