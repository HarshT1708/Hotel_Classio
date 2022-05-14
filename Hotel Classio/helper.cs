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
   
    class helper
    {
        OleDbConnection con1 = new OleDbConnection();
        OleDbCommand com1 = new OleDbCommand();
        OleDbDataReader reader;
        public void open_connection_room()
        {
            con1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\database\Rooms.mdb";
            con1.Open();

        }
        protected OleDbConnection getconnection()
        {
            OleDbConnection o1 = new OleDbConnection();
            o1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\database\Rooms.mdb";
            return o1;
        }
        public void close_connection_room()
        {
            con1.Close();
        }
        public DataTable view_data(string query)
        {
            DataTable data_table = new DataTable();
            com1.Connection = con1;
            com1.CommandText = query; 
            com1.ExecuteNonQuery();
            OleDbDataAdapter data_adpt = new OleDbDataAdapter(com1);
            data_adpt.Fill(data_table);
            return data_table;
        }
        public void insert_data(string qry)
        {
            com1.Connection = con1;
            com1.CommandText = qry;
            com1.ExecuteNonQuery();
        }
        public void update_data(int rno,string rtype,string bed,int price,int ID)
        {
            com1.Connection = con1;
            com1.CommandText = "update room_data set Room_No=" + rno + ", Room_Type='" + rtype + "', Bed = '" + bed + "',Price="+price+" where ID = " + ID + "   ";
            com1.ExecuteNonQuery();
        }
        public void setdata(string query)
        {
            com1.Connection = con1;
            com1.CommandText = query;
            com1.ExecuteNonQuery();
        }
        public OleDbDataReader getforcombo(string query)
        {
            OleDbConnection o1 = getconnection();
            com1.Connection = o1;
            o1.Open();
            com1 = new OleDbCommand(query, o1);
            reader = com1.ExecuteReader();
            return reader;

        }
        public DataTable getdata(string query)
        {
            OleDbConnection o1 = getconnection();
            com1.Connection = o1;
            o1.Open();
            com1.CommandText = query;
            OleDbDataAdapter data_adpt = new OleDbDataAdapter(com1);
            DataTable ds = new DataTable();
            data_adpt.Fill(ds);
            return ds;



        }


        
        
        
    }
}
