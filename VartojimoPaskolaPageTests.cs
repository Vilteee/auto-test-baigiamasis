namespace auto_test_baigiamasis;

public class FjordBankMainPageTests : BrowserController
{

    [Test]
    public void CheckPaskolaSkaiciuojaNormaliai ()
    {
        VartojimoPaskolaPage vpp = new VartojimoPaskolaPage();
        vpp.GoToVartojimoPaskola(driver, fluentWait);

        EnterTextByXpath("paskolos-suma-x-path", "paskolos-suma");
        EnterTextByXpath("paskolos-laikotarpis-x-path", "laikotartpis");
        Assert.AreEqual("suma kazkokia", getTextByXpath("Preliminari-mėnesio-įmoka-x-path"));

    }

    [Test]
    public void CheckAtidaroFrequentlyAskedQuestionsapacioj()
    {
        VartojimoPaskolaPage vpp = new VartojimoPaskolaPage();
        vpp.GoToVartojimoPaskola(driver, fluentWait);
        ClickElementByXpath("//div[@class='question' and text()='Kaip sudaryti sutartį?']");
        CheckElementExistsByXpath("//div[@class='questionWrap questionOpen']");
    }


}
