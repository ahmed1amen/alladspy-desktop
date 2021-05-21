using AllAdSpy.Classes;
using AllAdSpy.Models;
using Microsoft.EntityFrameworkCore;
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
        void LoadAccountToGridView()
        {
            var db = new ALLADSpyContext();
            List<Account> accounts = db.Accounts.ToList();

            dataGridView1.DataSource = accounts;

            dataGridView1.Columns["ID"].ReadOnly = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadAccountToGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReadOnlyCollection<Cookie> _cookies = driver.Manage().Cookies.AllCookies;
            //SaveCookies(_cookies);
            //EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);

        }

        private void button2_Click(object sender, EventArgs e)
        {
 
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            using (var db = new ALLADSpyContext())
            {
                var result = db.Accounts.SingleOrDefault(b => b.ID == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (result != null)
                {

                    result.Email= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    result.Password= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    result.UserName= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    result.Proxy = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    try
                    {
                        db.SaveChanges();
                        LoadAccountToGridView();
                    }
                    catch(DbUpdateException ex)
                    {
                        MessageBox.Show("Make Sure There's no Duplicated Username Or Email !","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadAccountToGridView();
                    }
    
                }

            }

        }
    }
}
