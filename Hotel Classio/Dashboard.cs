using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel_Classio
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            login l1 = new login();
            this.Hide();
            l1.Show();
        }

        private void btn_addroom_Click(object sender, EventArgs e)
        {
            Add_Room a1 = new Add_Room();
            this.Hide();
            a1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_cus a1 = new Add_cus();
            this.Hide();
            a1.Show();
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            checkout c1 = new checkout();
            this.Hide();
            c1.Show();

        }

        

       
    }
}
