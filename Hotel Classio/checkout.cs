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
    public partial class checkout : Form
    {
        public string bname;
        public double bid;
        public  string bgender;
        public string badd;
             public string bdob;
                  public  string bcheckin;
                       public   int broomno;
                           public  string broomtype;
                               public  string bbed; 
                                   public  int bprice;

        helper h1 = new helper();
        string query;
        int id;
        public checkout()
        {
            InitializeComponent();
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            query = "select customerrr.ID,customerrr.cus_name,customerrr.mob_no,customerrr.gender,customerrr.address,customerrr.dob,customerrr.checkin,room_data.Room_No,room_data.Room_Type,room_data.Bed,room_data.Price from customerrr inner join room_data on customerrr.roomid=room_data.ID where checkoutt='No'";
            DataTable ds = h1.getdata(query);
            dataGridView1.DataSource = ds;
        }

        private void txt_search_name_TextChanged(object sender, EventArgs e)
        {
            query = "select customerrr.ID,customerrr.cus_name,customerrr.mob_no,customerrr.gender,customerrr.address,customerrr.dob,customerrr.checkin,room_data.Room_No,room_data.Room_Type,room_data.Bed,room_data.Price from customerrr inner join room_data on customerrr.roomid=room_data.ID where cus_name like '"+txt_search_name.Text+"%' and checkoutt='No'";
            DataTable ds = h1.getdata(query);
            dataGridView1.DataSource = ds;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.CurrentRow.Selected = true;
            id =Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
            txt_namee.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txt_roomno.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            bname = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            bid=Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
           bgender = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
             badd = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
         bdob = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
           bcheckin = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
         broomno = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
          broomtype = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
           bbed = dataGridView1.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
          bprice = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());

        }
        public string get_add()
        {
            return badd;
        }
        public void c()
        {
            txt_search_name.Clear();
            txt_roomno.Clear();
            txt_namee.Clear();
            dateTimePicker2_checkout.ResetText();
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            if (txt_namee.Text != "" && txt_roomno.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    string cdate = dateTimePicker2_checkout.Text;
                    h1.open_connection_room();

                    query = "update customerrr set checkoutt='Yes',checkout='"+cdate+"' where ID="+id+" ";
                    h1.setdata(query);
                    query = "update room_data set Booked='No' where Room_No=" + txt_roomno.Text + "";
                    h1.setdata(query);
                    h1.close_connection_room();
                    MessageBox.Show("Checkout Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    checkout_Load(this, null);
                    c();
                    Bill b1 = new Bill();
                    this.Hide();
                    b1.Set(bname, bid, bgender, badd, bdob, bcheckin, broomno, broomtype, bbed, bprice);
                    b1.Show();

                    
                }
            }
            else
            {
                MessageBox.Show("please Select Any customer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
