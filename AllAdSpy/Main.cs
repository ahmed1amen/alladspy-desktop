using AllAdSpy.Classes;
using AllAdSpy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllAdSpy
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }


        private void Main_Load(object sender, EventArgs e)
        {
            var db = new ALLADSpyContext();
            List<Account> accounts = db.Accounts.ToList();
 
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

        private void button3_Click(object sender, EventArgs e)
        {


        }
    }
}
