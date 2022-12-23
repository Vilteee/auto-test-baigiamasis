using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace auto_test_baigiamasis
{
	public class NaujienosIrStraipsniaiPage
    {
		public NaujienosIrStraipsniaiPage()
		{
		}

        public void goToNaujienosIrStraipsniai(IWebDriver driver, DefaultWait<IWebDriver> fluentWait)
        {
            By apieMusButtonPath = By.XPath("//a[@href='/apie-mus']");

            IWebElement apieMusButton = fluentWait.Until(x => x.FindElement(apieMusButtonPath));

            // Hover over apieMus button
            new Actions(driver).MoveToElement(apieMusButton).Perform();

            fluentWait.Until(x => x.FindElement(
                By.XPath("//a[@href='/naujienos']"))).Click();

        }
    }
}

