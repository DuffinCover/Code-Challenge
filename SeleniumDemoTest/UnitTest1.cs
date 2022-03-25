using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using InvoiceCloudTest;


namespace SeleniumDemoTest
{
    [TestClass]
    public class UnitTest1
    {

        
        [TestMethod]
        public void AddOneThing()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            SeleniumDemo.ButtonClicker(driver, 1);                
            int count = SeleniumDemo.CountElements(driver);
            Assert.AreEqual(1, count);

            driver.Quit();                 


        }
        [TestMethod]
        public void AddNothing(){
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            int count = SeleniumDemo.CountElements(driver);

            Assert.AreEqual(0, count);

            driver.Quit();
        }
        [TestMethod]
        public void DeleteWhenNothingToDelete(){
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

            SeleniumDemo.DeleteRemove(driver, 7);

            int count = SeleniumDemo.CountElements(driver);

            Assert.AreEqual(0, count);
            driver.Quit();
        }

        [TestMethod]
        public void AddThenTake(){
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            SeleniumDemo.ButtonClicker(driver, 10);

            int count = SeleniumDemo.CountElements(driver);

            Assert.AreEqual(10, count);

            SeleniumDemo.DeleteRemove(driver, 4);

            count = SeleniumDemo.CountElements(driver);

            Assert.AreEqual(6, count);
            driver.Quit();

        }

        [TestMethod]
        public void TakeThenAdd(){
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");

            SeleniumDemo.DeleteRemove(driver, 2);
            int count = SeleniumDemo.CountElements(driver);
            Assert.AreEqual(0, count);

            SeleniumDemo.ButtonClicker(driver, 3);
            count = SeleniumDemo.CountElements(driver);
            Assert.AreEqual(3, count);

            driver.Quit();
        }
    }
}
