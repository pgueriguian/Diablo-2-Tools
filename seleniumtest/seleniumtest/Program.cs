using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

IWebDriver driver = new ChromeDriver();
foreach (var item in driver.WindowHandles)
{
    Console.WriteLine(  item.ToString());
}
