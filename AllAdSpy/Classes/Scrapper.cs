using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace AllAdSpy.Classes
{
    class Scrapper
    {
        static Main MainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();
        public IWebDriver driver = new ChromeDriver();
        IJavaScriptExecutor js;


        public Scrapper()
        {



            js = driver as IJavaScriptExecutor;

            EventFiringWebDriver firingDriver = new EventFiringWebDriver(driver);
            firingDriver.Navigated += FiringDriver_Navigated;
            firingDriver.ScriptExecuted += FiringDriver_ScriptExecuted;

            driver = firingDriver;

            string json = File.ReadAllText(@"cookies.json");


            var loaded = JsonConvert.DeserializeObject<List<JObject>>(json);



            driver.Navigate().GoToUrl(@"https://m.facebook.com");



            foreach (JObject cookie in loaded)
            {


                string Name = cookie.GetValue("Name").ToString();
                string Value = cookie.GetValue("Value").ToString();
                string Domain = cookie.GetValue("Domain").ToString();
                string Path = cookie.GetValue("Path").ToString();
                string Expiry = cookie.GetValue("Expiry").ToString();

                driver.Manage().Cookies.AddCookie(new Cookie(Name, Value));

                //      driver.Manage().Cookies.AddCookie(new Cookie(Name, Value, Domain, Path, DateTime.Parse(Expiry)));

            }


            driver.Navigate().GoToUrl(@"https://m.facebook.com");

            /*
                        driver.FindElement(By.Name("email")).SendKeys("ahmed1amen");
                        driver.FindElement(By.Name("pass")).SendKeys("ahmed@Amen123444");

                        driver.FindElement(By.Name("login")).Click(); */






        }


        private void FiringDriver_ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {

        }

        private void FiringDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            //   MessageBox.Show(@"Clicked!!");
        }

        public void SaveCookies(object _object)
        {


            string json = JsonConvert.SerializeObject(_object);
            File.WriteAllText(@"cookies.json", json);


        }



        public object LoadCookies()
        {

            JsonSerializer serializer = new JsonSerializer();
            JObject o1 = JObject.Parse(File.ReadAllText(@"cookies.json"));

            // Cookie deserializedProduct = JsonConvert.DeserializeObject<Cookie>(o1.ToString());
            return true;

        }



     public   void DoScrapping()
        {

            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            MainForm.Invoke(new Action(() => { MainForm.label2.Text = driver.FindElements(By.XPath(@"//*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]")).Count.ToString(); }));

        }

    }
}
