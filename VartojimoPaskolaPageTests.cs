namespace auto_test_baigiamasis;

public class VartojimoPaskolosPageTests : BrowserController
{
    public void CheckCreditsElement (string creditButtonXpath, string headerName)
    {
        ClickElementByXpath(creditButtonXpath);
        CheckElementExistsByXpath($"//h1[text()='{headerName}']");
    }

    [Test]
    public void CheckCreditCalculatingCorrect ()
    {
        TestName = "CheckCreditCalculatingCorrect";

        ExceptionWrapper(() =>
        {

            VartojimoPaskolaPage vpp = new VartojimoPaskolaPage();
            vpp.GoToVartojimoPaskola(driver, fluentWait);
        
            EnterTextByXpath("//input[@id='Paskolos suma']", "15000");
            EnterTextByXpath("//input[@id='Laikotarpis']", "24");
            Assert.AreEqual("709 €", getTextByXpath("//div[@class='amount']"));
        });
    }   

    [Test]
    public void CheckFrequentlyAskedQuestionsOpen ()
    {
        TestName = "CheckFrequentlyAskedQuestionsOpen";

        ExceptionWrapper(() =>
        {
            VartojimoPaskolaPage vpp = new VartojimoPaskolaPage();
            vpp.GoToVartojimoPaskola(driver, fluentWait);

            int numOfOpenElements =  returnNumOfElementsExistsByXpath("//div[@class='questionWrap questionOpen']");
            Assert.AreEqual( 0, numOfOpenElements);

            ClickElementByXpath("//div[@class='question' and text()='Kaip sudaryti sutartį?']");
            CheckElementExistsByXpath("//div[@class='questionWrap questionOpen']");
        });
    }

    [Test]
    public void CheckCreditElementsHeadersAreCorrect()
    {
        TestName = "CheckCreditElementsHeadersAreCorrect";

        ExceptionWrapper(() =>
        {
            VartojimoPaskolaPage vpp = new VartojimoPaskolaPage();
            vpp.GoToVartojimoPaskola(driver, fluentWait);

            CheckCreditsElement("//div[div[@class='text' and text()='Paskola automobiliui' ]]", "Paskola automobiliui");
            CheckCreditsElement("//div[div[@class='text' and text()='Paskola būsto remontui' ]]", "Paskola būsto remontui");
            CheckCreditsElement("//div[div[@class='text' and text()='Refinansavimas' ]]", "Refinansavimas");
        });
    }

}
