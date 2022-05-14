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
    public partial class preload : Form
    {
        public preload()
        {
            InitializeComponent();
        }
        
        private void preload_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(lbl_per.Text);
            no += 5;
            lbl_per.Text = no.ToString();
            progressBar1.Value += 5;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                login l1 = new login();
                this.Hide();
                l1.Show();
            }
        }

        
    }
}
