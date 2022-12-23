using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace auto_test_baigiamasis;

public class NaujienosIrStraipsniaiTests : BrowserController
{

    [Test]
    public void checkElementsNumber()
    {
        TestName = "checkElementsNumber";

        ExceptionWrapper(() =>
        {
            NaujienosIrStraipsniaiPage nis = new NaujienosIrStraipsniaiPage();
            nis.goToNaujienosIrStraipsniai(driver, fluentWait);
            int numOfElements = returnNumOfElementsExistsByXpath("//div[@class='newsWrapper']//div[@class='item ']");
            Assert.AreEqual(6, numOfElements);

            // Check number of elements in second page
            ClickElementByXpath("//a[@class='pageButton ' and @href='/naujienos/?page=2']");
            numOfElements = returnNumOfElementsExistsByXpath("//div[@class='newsWrapper']//div[@class='item ']");
            Assert.AreEqual(6, numOfElements);
        });
    }

    [Test]
    public void InspectNewsFiltersWorksCorrectly()
    {
        TestName = "InspectNewsFiltersWorksCorrectly";

        ExceptionWrapper(() =>
        {
            NaujienosIrStraipsniaiPage nis = new NaujienosIrStraipsniaiPage();
            nis.goToNaujienosIrStraipsniai(driver, fluentWait);
            IWebElement heading = getElementByXpath("//*[@id='root']/div[1]/div/div[1]/div[1]/h1");

            new Actions(driver).MoveToElement(heading).Perform();
            ClickElementByXpath("//div[@class='inputBlock selectBlock reactSelect inputBlocknewsFilter']");
            ClickElementByXpath("//*[@id='react-select-2-option-0']");
            string firstNewsHeading = getTextByXpath("//*[@id='root']/div[1]/div/div[2]/div[1]/a/div[2]/div");

            ClickElementByXpath("//div[@class='inputBlock selectBlock reactSelect inputBlocknewsFilter']");
            ClickElementByXpath("//*[@id='react-select-2-option-1']");
            Thread.Sleep(1000);
            string firstArticleHeading = getTextByXpath("//*[@id=\"root\"]/div[1]/div/div[2]/div[1]/a/div[2]/div");

            Assert.AreNotEqual(firstNewsHeading, firstArticleHeading);
        });
    }

    [Test]
    public void CheckDates()
    {
        TestName = "CheckDates";

        ExceptionWrapper(() =>
        {
            NaujienosIrStraipsniaiPage nis = new NaujienosIrStraipsniaiPage();
            nis.goToNaujienosIrStraipsniai(driver, fluentWait);
            IWebElement[] elements = getElementsByXpath("//div[@class='newsWrapper']//div[@class='date']");
            for (int i = 0; i < elements.Length - 1; i++)
            {
                DateTime date1 = DateTime.ParseExact(elements[i].Text, "d", null);
                DateTime date2 = DateTime.ParseExact(elements[i+1].Text, "d", null);
          
                if (date1 < date2)
                {
                    Assert.Fail("Dates are listed not in a correct sequence");
                }
            }
        });
    }
}
