namespace auto_test_baigiamasis;

public class SavitarnaTests : BrowserController
{

    [Test]
    public void CheckIfIncorrectPersonalCodeShowsErrorLabel ()
    {
        TestName = "CheckIfIncorrectPersonalCodeShowsErrorLabel";

        ExceptionWrapper(() =>
        {
            SavitarnaPage savitarnaPage = new SavitarnaPage();
            savitarnaPage.GoToSavitarna(driver, fluentWait);
            EnterTextByXpath("//input[@id='personalCode']", "4353453536");
            ClickElementByXpath("//button[@class='button']");
            string incorrectPersonalNumberLabel = "Netinkamo formato asmens kodas";
            Assert.AreEqual(incorrectPersonalNumberLabel, getTextByXpath("//div[@class='inputError']"));
        });
    }

    [Test]
    public void CheckSafetyInstructionsSection ()
    {
        TestName = "CheckSafetyInstructionsSection";

        ExceptionWrapper(() =>
        {
                SavitarnaPage savitarnaPage = new SavitarnaPage();
            savitarnaPage.GoToSavitarna(driver, fluentWait);
            CheckElementExistsByXpath("//div[@class='blueBox blueBoxWidth']");
            ClickElementByXpath("//span[@class='accentLink']");
            string safetyInstructionsText = "Nesiųskite el. paštu konfidencialios informacijos" +
                                        " (prisijungimo prie interneto banko slaptažodžių ir pan. duomenų)." +
                                        " Suabejoję elektroninės paslaugos ar kompiuterio patikimumu," +
                                        " nutraukite darbą ir nedelsdami praneškite apie tai bankui.";

            Assert.AreEqual(safetyInstructionsText, getTextByXpath("//div[@class='cmsParagraph_SecurityMemos']//p[1]"));
        });
    }

    [Test]
    public void CheckIdentificationMethodsAndNoMobileInputOnSmartId() {
        TestName = "CheckIdentificationMethodsAndNoMobileInputOnSmartId";

        ExceptionWrapper(() =>
        {
            SavitarnaPage savitarnaPage = new SavitarnaPage();
            savitarnaPage.GoToSavitarna(driver, fluentWait);
            int identificationMethodCount = returnNumOfElementsExistsByXpath("//div[@class='confirmationMethodButton' or @class='confirmationMethodButton active']");
        
            Assert.AreEqual(identificationMethodCount, 3);
        
            ClickElementByXpath("//div[@class='confirmationMethodButton' and @data-cy='SMARTID']");
            int mobileCount = returnNumOfElementsExistsByXpath("//div[@class='phoneInput phoneInputphone']");
            Assert.AreEqual(mobileCount, 0);
        });
    }



}
