using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace auto_test_baigiamasis
{
	public class VartojimoPaskolaPage
	{
		public VartojimoPaskolaPage() {}

        
        public void GoToVartojimoPaskola(IWebDriver driver, DefaultWait<IWebDriver> fluentWait)
        {
            By paskolosButtonPath = By.XPath("//a[@href='/paskolos']");

            IWebElement paskolosButton = fluentWait.Until(x => x.FindElement(paskolosButtonPath));

            // Hover over paskolos button
            new Actions(driver).MoveToElement(paskolosButton).Perform();

            fluentWait.Until(x => x.FindElement(
                By.XPath("//a[@href='/paskolos/vartojimo-paskola']"))).Click();

        }
    }
}

