using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Hotel_Classio
{
   
   
    public partial class Add_cus : Form
    {
        helper h1 = new helper();
        string query;
        public Add_cus()
        {
            InitializeComponent();
        }

        public void setcombo(string query, ComboBox combo)
        {
            OleDbDataReader reader = h1.getforcombo(query);
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    combo.Items.Add(reader["Room_No"].ToString());
                }

            }
            reader.Close();

        }

        private void cboc_roomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboc_roomno.Items.Clear();
            txtc_price.Clear();
            query = "select Room_No from room_data where Bed='" + cboc_bed.Text + "' and Room_Type='" + cboc_roomtype.Text + "' and Booked='No'";
            setcombo(query, cboc_roomno);
        }

        private void cboc_bed_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboc_roomtype.SelectedIndex = -1;
            cboc_roomno.Items.Clear();
            txtc_price.Clear();

        }
        int rid;
        private void cboc_roomno_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select Price,ID from room_data where Room_No=" + cboc_roomno.Text + " ";
            DataTable ds = h1.getdata(query);
            txtc_price.Text = ds.Rows[0][0].ToString();
            rid =Convert.ToInt32( ds.Rows[0][1].ToString());
        }
        public void clear()
        {
            txt_address.Clear();
            txt_mono.Clear();
            txt_name.Clear();
            cbo_gender.SelectedIndex = -1;
            cboc_bed.SelectedIndex = -1;
            cboc_roomno.SelectedIndex = -1;
            cboc_roomtype.SelectedIndex = -1;
            txtc_price.Clear();
            
        }

        private void btn_allote_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "" && txt_mono.Text != "" && txt_address.Text != "" && dateTimePicker1_dob.Text != "" && dateTimePicker2_checkin.Text != "" && cbo_gender.Text != "") 
            {
                string name = txt_name.Text;
                double  mono = Convert.ToDouble(txt_mono.Text);
                string gender = cbo_gender.Text;
                string address = txt_address.Text;
                string dob = dateTimePicker1_dob.Text;
                string checkin = dateTimePicker2_checkin.Text;
                h1.open_connection_room();

                query = "insert into customerrr(cus_name,mob_no,gender,address,dob,checkin,roomid) values ('"+name+"',"+mono+",'"+gender+"','"+address+"','"+dob+"','"+checkin+"',"+rid+")  ";
                h1.insert_data(query);
                query = "update room_data set Booked='Yes' where Room_No=" + cboc_roomno.Text + "";
                h1.insert_data(query);
                h1.close_connection_room();
                MessageBox.Show("Room Allocation Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clear();
            }
            else
            {
                MessageBox.Show("All Fields are Mandatory", "Information",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clear();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Dashboard d1 = new Dashboard();
            this.Hide();
            d1.Show();
        }
    }
}
