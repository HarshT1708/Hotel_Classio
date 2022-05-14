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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            
        }
        public void Set(string name, double mobo, string gen, string add, string dob,string chekin, int romno, string roomtype, string bed, int price)
        {
            lbl_name.Text = name.ToString();
            lbl_mono.Text = mobo.ToString();
            lbl_gender.Text = gen;
            lbl_dob.Text = dob;
            
            lbl_checkin.Text = chekin;
            lbl_roomno.Text = romno.ToString();
            lbl_roomtype.Text = roomtype;
            lbl_bed.Text = bed;
            
            lbl_price.Text = price.ToString(); ;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            this.Hide();
            ds.Show();
        }
    }
}
