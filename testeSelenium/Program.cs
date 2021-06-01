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
            IWebDriver webDriver = new ChromeDriver("/Users/kainos/Projects/testeSelenium/testeSelenium");
            string path = Directory.GetCurrentDirectory();
            try
            {
                webDriver.Navigate().GoToUrl("https://makeitcloud.com.br/sgi/Gestor.aspx");

                IWebElement captcha = webDriver.FindElement(By.Id("ctl00_ImageCaptcha"));
                string src = captcha.GetAttribute("src");

                Task.Delay(TimeSpan.FromSeconds(4)).Wait();

                

                Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
                Bitmap imageArray = (Bitmap)Image.FromStream(new MemoryStream(screenshot.AsByteArray));//.SaveAsFile(@"/Users/kainos/Desktop/screen.png", ScreenshotImageFormat.Png);
                Bitmap img = imageArray.Clone(new Rectangle(captcha.Location, captcha.Size), imageArray.PixelFormat);

                img.Save(path + @"/screen.png", System.Drawing.Imaging.ImageFormat.Png);

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                webDriver.Close();
            }


            Console.ReadKey();
        }

    }
}
