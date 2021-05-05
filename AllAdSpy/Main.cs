using System;

using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using AllAdSpy.Classes;

namespace AllAdSpy
{
    public partial class Main : Form
    {


        public Main()
        {
            InitializeComponent();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            var x = SqliteDataAccess.LoadAccounts();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            //ReadOnlyCollection<Cookie> _cookies = driver.Manage().Cookies.AllCookies;
            //SaveCookies(_cookies);
            //EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Marks");
            DataRow _ravi = dt.NewRow();
            _ravi["Name"] = "ravi";
            _ravi["Marks"] = "500";
            dt.Rows.Add(_ravi);

            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.AutoSizeRowsMode =
                 DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //is_sponsored.
            ////*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]//div/span/p   //Get AD Title

            //foreach (IWebElement element in driver.FindElements(By.XPath(@"//*[@id='MNewsFeed']/section/article[contains(node(),'Sponsored')]")))
            //{

            //    MessageBox.Show("");
            //}


            //   

        }


    }
}
