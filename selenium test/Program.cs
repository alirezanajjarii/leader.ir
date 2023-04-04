using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_test
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.leader.ir/fa");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var archive = driver.FindElement(By.XPath("/html/body/footer/nav[3]/ul/li[5]/h6/a"));
            archive.Click();
            var section = driver.FindElement(By.XPath("/html/body/main/div[1]/section[1]/main/div[1]/ul/li[2]"));
            section.Click();
           
            var speech = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[2]/main/ul[2]/li/div[2]/h6/a[2]"));
            speech.Click();
            var title = driver.FindElement(By.ClassName("btitr"));
            var articleBody = driver.FindElement(By.Id("details"));
            var date = driver.FindElement(By.XPath("/html/body/main/div[1]/section/main/article[1]/div[1]/time/h6"));

            var heading = title.Text;
            var body = articleBody.Text;
            var name = date.Text;
            name = new string(name.Where(c => !char.IsPunctuation(c)).ToArray());

            string filePath = @"C:\Users\MEMO\Desktop\test";
            string fileName = $"{name}.txt";
            string fullPath = Path.Combine(filePath, fileName);
            File.WriteAllText(fullPath, heading + body);


            driver.Navigate().Back();
            


        }
    }

}
