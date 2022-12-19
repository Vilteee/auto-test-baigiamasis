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


        [SetUp]
        public void setup()
        {
            this.driver = new ChromeDriver();
            NavigateURL("https://www.fjordbank.lt/");
            

            this.fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.Message = "Element to be searched not found";

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void tear()
        {
            //try
            //{
            //    Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //    //DateTime time = new DateTime();

            //    string time = "_" + DateTime.Now.ToString("HH:mm");
            //    Console.WriteLine("_" + time);
            //    time = time.Replace(':', '_');

            //    TakeScreenshot.SaveAsFile("C:\\Users\\Martynas\\Documents\\Zoom\\TestName\\" + TestName + time + ".png");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.StackTrace);
            //}

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

        public void EnterTextByXpath(string xpath, string text)
        {
            CheckElementExistsByXpath(xpath);

            By element = By.XPath(xpath);
            driver.FindElement(element).SendKeys(text);
        }

        public string getTextByXpath(string xpath)
        {

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

            return searchResult.Text;
        }

        public void ClickElementByBy(By element)
        {
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(element));
            searchResult.Click();

        }

        public void ScrollAndClickElementByXpath(string xpath)
        {
            CheckElementExistsByXpath(xpath);


            By by = By.XPath(xpath);
            IWebElement element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            try
            {
                actions.Perform();
            }
            catch (Exception ex) { }

            Thread.Sleep(500);

            ClickElementByBy(by);
        }



    }
}

