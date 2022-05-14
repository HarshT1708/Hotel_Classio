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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text == "harsh" && txt_pass.Text == "harsh")
                {
                    lbl_pass.Visible = false;
                    // MessageBox.Show("Login Successful");
                    txt_username.Clear();
                    txt_pass.Clear();
                    check c1 = new check();
                    this.Hide();
                    c1.Show();
                }
                else
                {
                    lbl_pass.Visible = true;
                    txt_username.Clear();
                    txt_pass.Clear();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_pass_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        
    }
}
