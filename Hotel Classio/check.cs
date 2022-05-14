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
    public partial class check : Form
    {
        public check()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            try
            {

                progressBar1.Visible = true;
                timer1.Enabled = true;
                lbl_check.Visible = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                progressBar1.Value += 20;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    lbl_check.Visible = false;
                    timer1.Enabled = false;
                    MessageBox.Show("The Room is Available");
                    progressBar1.Visible = false;
                    btn_check.Enabled = false;
                    Dashboard d1 = new Dashboard();
                    this.Hide();
                    d1.Show();


                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
    }
}
