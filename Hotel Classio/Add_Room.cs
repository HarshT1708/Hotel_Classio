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
    public partial class Add_Room : Form
    {
        public Add_Room()
        {
            InitializeComponent();
        }
        helper h1 = new helper();

        private void Add_Room_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from room_data";
                h1.open_connection_room();
                DataTable dt = new DataTable();
                dt = h1.view_data(query);
                dataGridView1.DataSource = dt;
                h1.close_connection_room();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);

            }
        }

        
        public void clear()
        {
            txt_price.Clear();
            txt_room_no.Clear();
            cbo_bed.SelectedIndex = -1;
            cbo_room_type.SelectedIndex = -1;
            txt_id.Clear();
        }
        public void load_data()
        {
            try
            {
                string query = "select * from room_data";
                h1.open_connection_room();
                dataGridView1.DataSource = h1.view_data(query);
                h1.close_connection_room();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_room_no.Text != "" && txt_price.Text != "" && cbo_room_type.Text != "" && cbo_bed.Text != "")
            {

                try
                {
                    h1.open_connection_room();

                    string str = "insert into room_data (Room_No,Room_Type,Bed,Price) values (' " + txt_room_no.Text + "','" + cbo_room_type.Text + "','" + cbo_bed.Text + "'," + txt_price.Text + ")";
                    h1.insert_data(str);
                    h1.close_connection_room();
                    MessageBox.Show("Room Added", "Notification", MessageBoxButtons.OK);
                    load_data();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("All Fields are Mandatory", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clear();
            }
        
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_room_no.Text != "" && txt_price.Text != "" && cbo_room_type.Text != "" && cbo_bed.Text != "" && txt_id.Text != "")
            {
                try
                {
                    h1.open_connection_room();
                    h1.update_data(Convert.ToInt32(txt_room_no.Text), cbo_room_type.Text, cbo_bed.Text, Convert.ToInt32(txt_price.Text), Convert.ToInt32(txt_id.Text));
                    h1.close_connection_room();
                    clear();
                    load_data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            else
            {
                MessageBox.Show("Please Select The Field To Update");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;

                txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txt_room_no.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                cbo_room_type.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                cbo_bed.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txt_price.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
