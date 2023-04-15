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
            Thread.Sleep(500);
            var section = driver.FindElement(By.XPath("/html/body/main/div[1]/section[1]/main/div[1]/ul/li[2]"));
            section.Click();
            Thread.Sleep(500);
            var years = driver.FindElements(By.XPath("/html/body/main/div[1]/section[1]/main/div[2]/ul/li"));

            for (int i = 1; i <= years.Count; i++)
            {
                if (i == 1 * 5)
                {
                    var Next = driver.FindElement(By.XPath("/html/body/main/div[1]/section[1]/main/div[2]/i[2]"));
                    Next.Click();
                }
                Thread.Sleep(500);
                var year = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[2]/ul/li[{i}]"));
                year.Click();

                for (int j = 1; j <= 12; i++)
                {
                    var month = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[3]/ul/li[{j}]"));
                    month.Click();
                    var speechNumber = driver.FindElements(By.XPath($"/html/body/main/div[1]/section[2]/main/ul"));
                    for (int k = 1; k <= speechNumber.Count; i++)
                    {
                        var speech = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[2]/main/ul[{k}]/li/div[2]/h6/a[2]"));
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

                        var arg = Environment.GetCommandLineArgs();
                        String root = Path.GetDirectoryName(arg[0]);

                        File.WriteAllText($@"{root}{fileName}.txt", heading + body);
                        //File.WriteAllText($@"{root}\اطلاعات خبر ها\{id}.txt", Information);


                        driver.Navigate().Back();
                        var reSection = driver.FindElement(By.XPath("/html/body/main/div[1]/section[1]/main/div[1]/ul/li[2]"));
                        reSection.Click();
                        var reSection_2 = driver.FindElement(By.XPath($"/html/body/main/div[1]/section[1]/main/div[2]/ul/li[{i}]"));
                        reSection_2.Click();

                    }
                }
            }





        }
    }

}
