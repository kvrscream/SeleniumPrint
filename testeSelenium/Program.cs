using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testeSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vamos copiar um captcha?!");
            ChromeOptions options = new ChromeOptions();
            IWebDriver webDriver = new ChromeDriver("c:/Users/Felipe/Documents/dotnet/SeleniumPrint/testeSelenium");//new ChromeDriver("/Users/kainos/Projects/testeSelenium/testeSelenium");
            string path = Directory.GetCurrentDirectory();
            try
            {
                webDriver.Navigate().GoToUrl("https://makeitcloud.com.br/sgi");//("https://www.plus2net.com/php_tutorial/captcha-demo1.php");

                IWebElement captcha = webDriver.FindElement(By.Id("ctl00_ImageCaptcha"));
                string src = captcha.GetAttribute("src");

                Task.Delay(TimeSpan.FromSeconds(4)).Wait();

                Screenshot screenshot = ((ITakesScreenshot)captcha).GetScreenshot();

                screenshot.SaveAsFile(path + @"/" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm- ss") + ".png", ScreenshotImageFormat.Png);
                /*
                Bitmap imageArray = (Bitmap)Image.FromStream(new MemoryStream(screenshot.AsByteArray));//.SaveAsFile(@"/Users/kainos/Desktop/screen.png", ScreenshotImageFormat.Png);
                Bitmap img = imageArray.Clone(new Rectangle(captcha.Location, captcha.Size), imageArray.PixelFormat); ;
                
                img.Save(path + @"/" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png);
               */
            } catch(Exception ex)
            {
                Console.WriteLine("Tem erros:" + ex.Message);
            }
            finally
            {
                //webDriver.Close();
            }


            Console.ReadKey();
        }

    }
}
