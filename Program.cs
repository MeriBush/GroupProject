using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestScripts
{
    [TestFixture]
    public class Edit
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        static void Main(string[] args)
        {

        }
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        [TestCase("Bob Kelly", "55000", "Programmer", "IT", "09-05-2001")]
        [TestCase("Bob Kelly", "55000", "", "", "09-05-2001")]
        [TestCase("Bob Kelly", "", "", "", "09-05-2001")]
        public void CreateNewEmployeeTest1(string name, string salary, string position, string department, string DOJ)
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("EmpName")).Clear();
            driver.FindElement(By.Id("EmpName")).SendKeys(name);
            driver.FindElement(By.Id("EmpName")).Click();
            driver.FindElement(By.Id("EmpSalary")).Click();
            driver.FindElement(By.Id("EmpSalary")).Clear();
            driver.FindElement(By.Id("EmpSalary")).SendKeys(salary);
            driver.FindElement(By.Id("EmpPosition")).Click();
            driver.FindElement(By.Id("EmpPosition")).Clear();
            driver.FindElement(By.Id("EmpPosition")).SendKeys(position);
            driver.FindElement(By.Id("EmpDepartment")).Click();
            driver.FindElement(By.Id("EmpDepartment")).Clear();
            driver.FindElement(By.Id("EmpDepartment")).SendKeys(department);
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys(DOJ);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();


            Assert.AreEqual("Create", driver.FindElement(By.XPath("/html/body/div[2]/h2")).Text);
        }

        [TestCase("", "The Name field is required.", "", "", "", "", "", "The Date Of Joining field is required.", "")]
        [TestCase("John Smith", "", "Eighty thousand", "The field Salary($) must be a number.", "", "", "02-09-2011", "", "")]
        [TestCase("Tom Wayne", "", "", "", "", "", "fourth of july two thousand five", "The field Date Of Joining must be a date.", "")]
        [TestCase("Tom Wayne", "", "", "", "", "", "2000", "", "The value '2000' is not valid for Date Of Joining.")]

        public void CreateNewEmployee2(string name, string nameErr, string salary, string salErr,
            string position, string department, string DOJ, string DojErrMissing, string DojInvalid)
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees")).Click();
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("EmpName")).Clear();
            driver.FindElement(By.Id("EmpName")).SendKeys(name);
            driver.FindElement(By.Id("EmpName")).Click();
            driver.FindElement(By.Id("EmpSalary")).Click();
            driver.FindElement(By.Id("EmpSalary")).Clear();
            driver.FindElement(By.Id("EmpSalary")).SendKeys(salary);
            driver.FindElement(By.Id("EmpPosition")).Click();
            driver.FindElement(By.Id("EmpPosition")).Clear();
            driver.FindElement(By.Id("EmpPosition")).SendKeys(position);
            driver.FindElement(By.Id("EmpDepartment")).Click();
            driver.FindElement(By.Id("EmpDepartment")).Clear();
            driver.FindElement(By.Id("EmpDepartment")).SendKeys(department);
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys(DOJ);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();

            if (!nameErr.Equals(""))
            {
                Assert.AreEqual(nameErr, driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[1]/div/span/span")).Text);
            }
            if (!salErr.Equals(""))
            {
                Assert.AreEqual(salErr, driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[2]/div/span/span")).Text);
            }
            if (!DojErrMissing.Equals(""))
            {
                Assert.AreEqual(DojErrMissing, driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[5]/div/span/span")).Text);
            }
            if (!DojInvalid.Equals(""))
            {
                Assert.AreEqual(DojInvalid, driver.FindElement(By.XPath("/html/body/div[2]/form/div/div[6]/div/span")).Text);
            }
        }

        [Test]
        public void TheEditTest()
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees »")).Click();
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("EmpName")).Click();
            driver.FindElement(By.Id("EmpName")).Click();
            driver.FindElement(By.Id("EmpName")).Clear();
            driver.FindElement(By.Id("EmpName")).SendKeys("edit1");
            driver.FindElement(By.Id("EmpSalary")).Click();
            driver.FindElement(By.Id("EmpSalary")).Clear();
            driver.FindElement(By.Id("EmpSalary")).SendKeys("150000");
            driver.FindElement(By.Id("EmpPosition")).Click();
            driver.FindElement(By.Id("EmpPosition")).Clear();
            driver.FindElement(By.Id("EmpPosition")).SendKeys("dev");
            driver.FindElement(By.Id("EmpDepartment")).Click();
            driver.FindElement(By.Id("EmpDepartment")).Clear();
            driver.FindElement(By.Id("EmpDepartment")).SendKeys("IT");
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("10/15/1999");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("edit1", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::td[2]")).Text);
            Assert.AreEqual("150000", driver.FindElement(By.XPath("(.//td[contains(text(),'150000')])")).Text);
        }
        [Test]
        public void TheEditAlternativeTest()
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees »")).Click();
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("EmpSalary")).Click();
            driver.FindElement(By.Id("EmpSalary")).Clear();
            driver.FindElement(By.Id("EmpSalary")).SendKeys("asd");
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("asd");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("The field Salary($) must be a number.", driver.FindElement(By.XPath("(.//span[@for='EmpSalary'])")).Text);
            Assert.AreEqual("The field Date Of Joining must be a date.", driver.FindElement(By.XPath("(.//span[@for='EmpJoinDate'])")).Text);

        }
        [Test]
        public void TheEditAlternativeTestDateChecker()
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees »")).Click();
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("asd"); //test for characters
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("The field Date Of Joining must be a date.", driver.FindElement(By.XPath("(.//span[@for='EmpJoinDate'])")).Text);

            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("!@#$"); //test for special characters
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("The field Date Of Joining must be a date.", driver.FindElement(By.XPath("(.//span[@for='EmpJoinDate'])")).Text);

            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("1111"); //test for invalid date object
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("The value '1111' is not valid for Date Of Joining.", driver.FindElement(By.XPath("(.//span[@class='field-validation-error text-danger'])")).Text);

            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("11/11/111111"); //test for invalid date object
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("(.//span[@class='field-validation-error text-danger'])")));
            Assert.AreEqual("The value '11/11/111111' is not valid for Date Of Joining.", driver.FindElement(By.XPath("(.//span[@class='field-validation-error text-danger'])")).Text);
        }
        [Test]
        public void TheFailingEditTestCase()
        {
            driver.Navigate().GoToUrl("http://localhost:50688/");
            driver.FindElement(By.LinkText("View Employees »")).Click();
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Click();
            driver.FindElement(By.Id("EmpJoinDate")).Clear();
            driver.FindElement(By.Id("EmpJoinDate")).SendKeys("11/11/1111"); //test for characters
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).Click();
            Assert.AreEqual("The field Date Of Joining must be a date.", driver.FindElement(By.XPath("(.//span[@for='EmpJoinDate'])")).Text);
        }


    }
}
