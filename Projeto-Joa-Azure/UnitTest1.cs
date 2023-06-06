using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V111.Network;

namespace Projeto_Joa_Azure
{
    public class Tests
    {
        private string loginMessage;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginSucesso()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hom.eadtech.net/App/Student/User/Account/Login");
            driver.FindElement(By.Id("infoLogin")).SendKeys("Joao.filho@eadtech.com.br");
            driver.FindElement(By.Id("passWord")).SendKeys("123");
            driver.FindElement(By.Id("frmLoginSubmit")).Click();
            Assert.AreEqual("Login - EADTECHH", driver.Title);
            Thread.Sleep(5000);
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void LoginSemSenha()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hom.eadtech.net/App/Student/User/Account/Login");
            driver.FindElement(By.Id("infoLogin")).SendKeys("Joao.filho@eadtech.com.br");
            driver.FindElement(By.Id("frmLoginSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("loginMessage")).Text, Is.EqualTo("Por favor, informe sua senha"));
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void LoginSemEmail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hom.eadtech.net/App/Student/User/Account/Login");
            driver.FindElement(By.Id("passWord")).SendKeys("123");
            driver.FindElement(By.Id("frmLoginSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("loginMessage")).Text, Is.EqualTo("Preencha o campo e-mail"));
            driver.Close();
            driver.Quit();
        }

    }
}