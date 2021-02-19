using System;
 
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.Events;

namespace AllAdSpy
{
    public partial class Form1 : Form
    {
        public IWebDriver driver = new ChromeDriver();
        IJavaScriptExecutor js; 

        public Form1()
        {
            InitializeComponent();
        }



 
       
        private void Form1_Load(object sender, EventArgs e)
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
            timer1.Start();
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



        public object LoadCookies( )
        {

            JsonSerializer serializer = new JsonSerializer();
            JObject o1 = JObject.Parse(File.ReadAllText(@"cookies.json"));

           // Cookie deserializedProduct = JsonConvert.DeserializeObject<Cookie>(o1.ToString());
            return true;
          
        }
       
        private void button1_Click(object sender, EventArgs e)
        {


            ReadOnlyCollection<Cookie> _cookies = driver.Manage().Cookies.AllCookies;
            SaveCookies(_cookies);



            EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);


        }

        private void button2_Click(object sender, EventArgs e)
        {

            //is_sponsored.
            ////*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]//div/span/p   //Get AD Title

            foreach (IWebElement element in driver.FindElements(By.XPath(@"//*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]")))
            {

                MessageBox.Show("");
            }


        //   

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            this.label2.Text = driver.FindElements(By.XPath(@"//*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]")).Count.ToString();
        }
    }
}
