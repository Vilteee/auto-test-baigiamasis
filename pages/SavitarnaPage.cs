using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace auto_test_baigiamasis

{

    public class SavitarnaPage
    {
        public SavitarnaPage() {

        }

        public void GoToSavitarna(IWebDriver driver, DefaultWait<IWebDriver> fluentWait)
        {
            By savitarnaButtonPath = By.XPath("//div[@class='myFjord notLoggedIn'][text()='SAVITARNA']");

            IWebElement savitarnaButton = fluentWait.Until(x => x.FindElement(savitarnaButtonPath));
            savitarnaButton.Click();

        }

    }
}


	


