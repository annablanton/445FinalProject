using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static _445FinalProject.ConnectionStringClass;

namespace _445FinalProject
{
    public partial class AddEvent : System.Web.UI.Page
    {
        Dictionary<string, TextBox> fieldDict;

        /**
         * Load page; add all relevant text boxes to fieldDict to be looped through
         * to add parameters to a SqlCommand
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            fieldDict = new Dictionary<string, TextBox>();
            fieldDict.Add("@eventdate", TextBox1);
            fieldDict.Add("@starttime", TextBox2);
            fieldDict.Add("@endtime", TextBox3);
            fieldDict.Add("@eventname", TextBox4);
            fieldDict.Add("@description", TextBox5);
            fieldDict.Add("@staffneeded", TextBox6);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }

        /**
         * Method which is used when button is clicked; creates and executes necessary queries
         * then updates the tables on the webpage. In this case, only an insert statement to enter
         * event data into the Event table is needed.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string query = ("insert into Event VALUES(@eventdate, @starttime, @endtime, @eventname, @description, @staffneeded)");
                SqlCommand cmd = new SqlCommand(query, conn);
                foreach (KeyValuePair<string, TextBox> elem in fieldDict)
                {
                    cmd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                }
                cmd.ExecuteNonQuery();
                Literal1.Text = "Successful insert";
                foreach (TextBox t in fieldDict.Values)
                {
                    t.Text = "";
                }
                FillTable(conn);
                conn.Close();
            }

            catch (SqlException exc)
            {
                Literal1.Text = "Exception occurred while entering data; make sure all fields are entered correctly";
                Literal1.Text = exc.ToString();
            }

        }

        /**
         * Private method to update tables on webpage. Queries the Event
         * table.
         */
        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM Event", c);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            EventTable.DataSource = tbl;
            EventTable.DataBind();
        }
    }
}