using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;


namespace AppiumCalculatorTestsDesktop
{
    public class CalculatorTests

    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\krist\Downloads\04.Appium-Desktop-Testing-Resources\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;

        [SetUp]
        public void Setup_Open_Application()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
        }

        [TearDown]
        public void CloseApplication()
        {
            driver.Quit(); 
        }

        [Test]
        public void Test_Sum_Two_PosotiveNums()
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys("5");
            secondField.SendKeys("15");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("20"));

        }

        [Test]
        public void Test_Sum_Two_NegatoveNums()
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys("-5");
            secondField.SendKeys("-15");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("-20"));

        }

        [Test]
        public void Test_Sum_Two_InvalidInputs()
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys("a");
            secondField.SendKeys("b");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("error"));

        }

        [TestCase("2", "2", "4")]
        [TestCase("-2", "-2", "-4")]
        [TestCase("a", "b", "error")]
        
        public void Test_Sum_DDT(string firstValue, string secondValue, string resultValue)
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.SendKeys("a");
            secondField.SendKeys("b");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("error"));

        }
    }
}