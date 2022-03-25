using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace InvoiceCloudTest
{
    public class SeleniumDemo
    {
        /*Specific to Chrome only, simplistic method to locate and click the first button
        it finds a given number of times. 
        */
        public static void ButtonClicker(ChromeDriver driver, int clicks)
        {
            //Locate the "Add Element button"
            var addButton = driver.FindElement(By.TagName("button"));
            for (int i = 0; i < clicks; i++)
            {
                addButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            }

        }
        /*We may want to remove some number of those buttons and re-check to ensure our count is correct. 
        */
        public static void DeleteRemove(ChromeDriver driver, int remove)
        {
            //remove the desired number of elements. 
            try
            {
                for (int i = 0; i < remove; i++)
                {
                    var deleteButton = driver.FindElement(By.CssSelector("#elements .added-manually"));
                    deleteButton.Click();
                }
            }
            catch (NoSuchElementException e)
            {
                return;
            }
        }

        public static int CountElements(ChromeDriver driver)
        {
            //Try to count if the element is there. 
            try{
            IList<IWebElement> deletes = driver.FindElements(By.CssSelector("#elements .added-manually"));
            return deletes.Count;
            }
            catch(NoSuchElementException e){
                return 0;
            }
            
        }
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            //Start ChromeDriver
            var driver = new ChromeDriver();
            string url = "http://the-internet.herokuapp.com/add_remove_elements/";

            //Go to where we want to go. 
            driver.Navigate().GoToUrl(url);


            ButtonClicker(driver, 7);

            System.Console.WriteLine("There are " + CountElements(driver) + " delete buttons on the page.");

            DeleteRemove(driver, 4);

            System.Console.WriteLine("There are " + CountElements(driver) + " delete buttons on the page.");

            driver.Quit();

        }
    }
}
