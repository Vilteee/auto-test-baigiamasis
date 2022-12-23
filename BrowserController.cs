using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace auto_test_baigiamasis
{
    public class BrowserController
    {

        public IWebDriver driver = new ChromeDriver();

        public string TestName = "Default Test Name";

        public DefaultWait<IWebDriver> fluentWait;

        // Wrap all test cases in this wrapper so that when there is
        // a failed test, the catch block would trigger a screenshot creation
        protected void ExceptionWrapper(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();

                string time = "_" + DateTime.Now.ToString("HH:mm");
                time = time.Replace(':', '_');
                TakeScreenshot.SaveAsFile("/Users/viltingai/Desktop/auto-test-baigiamasis/screenshots/" + TestName + time + ".png");

                throw;
            }
        }

        [SetUp]
        public void setup()
        {
            this.driver = new ChromeDriver();
            NavigateURL("https://www.fjordbank.lt/");
            

            this.fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.Message = "Element to be searched not found";

            driver.Manage().Window.Maximize();

            int numberOfNotfComponents = returnNumOfElementsExistsByXpath("//*[@class='close' and local-name()='svg']");
            if (numberOfNotfComponents > 0)
            {
                ClickElementByXpath("//*[@class='close' and local-name()='svg']");

            }
        }

        [TearDown]
        public void tear()
        {

            driver.Quit();

        }

        public void NavigateURL(string newURL)
        {
            driver.Url = newURL;
        }

        public void ClickElementByXpath(string xPath)
        {
            By element = By.XPath(xPath);

            driver.FindElement(element).Click();
        }

        public void CheckElementExistsByXpath(string xPath)
        {
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xPath)));
        }

        public int returnNumOfElementsExistsByXpath(string xPath)
        {
            int count = fluentWait.Until(x => x.FindElements(By.XPath(xPath))).Count;

            return count;
        }

        public IWebElement[] getElementsByXpath(string xPath)
        {
            IWebElement[] elements = fluentWait.Until(x => x.FindElements(By.XPath(xPath))).ToArray();

            return elements;
        }

        public void EnterTextByXpath(string xpath, string text)
        {
            CheckElementExistsByXpath(xpath);

            By element = By.XPath(xpath);
            driver.FindElement(element).SendKeys(text);
            driver.FindElement(element).SendKeys(Keys.Return);
        }

        public string getTextByXpath(string xpath)
        {

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

            return searchResult.Text;
        }

        public IWebElement getElementByXpath(string xpath)
        {

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

            return searchResult;
        }

    }
}

