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
    public partial class WebForm2 : System.Web.UI.Page
    {
        Dictionary<string, TextBox> fieldDict;
        /**
         * Load page; add all relevant text boxes to fieldDict to be looped through
         * to add parameters to a SqlCommand
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            fieldDict = new Dictionary<string, TextBox>();
            fieldDict.Add("@firstname", TextBox1);
            fieldDict.Add("@lastname", TextBox2);
            fieldDict.Add("@birthdate", TextBox3);
            fieldDict.Add("@membershipdate", TextBox4);
            fieldDict.Add("@phonenum", TextBox5);
            fieldDict.Add("@email", TextBox6);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }
        /**
         * Method which is used when button is clicked; creates and executes necessary queries
         * then updates the tables on the webpage. In this case, an insert statement enters
         * data into the Member table, and if the Card printed text box is checked, an insert
         * statement for the printed card is created in CheckoutCard.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string query = ("insert into Member VALUES(@firstname, @lastname, @birthdate, @membershipdate, @phonenum, @email, @printdate)");
                SqlCommand cmd = new SqlCommand(query, conn);
                foreach (KeyValuePair<string, TextBox> elem in fieldDict)
                {
                    cmd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                }
                if (CheckBox1.Checked)
                {
                    SqlCommand card = new SqlCommand("INSERT INTO CheckoutCard VALUES(@memberid)", conn);
                    SqlCommand lastId = new SqlCommand("SELECT IDENT_CURRENT('Member')", conn);
                    decimal id = (decimal)lastId.ExecuteScalar();
                    card.Parameters.AddWithValue("@memberid", id);
                    card.ExecuteNonQuery();
                    cmd.Parameters.AddWithValue("@printdate", fieldDict["@membershipdate"].Text);
                } else
                {
                    cmd.Parameters.AddWithValue("@printdate", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
                Literal1.Text = "Successful insert";
                foreach (TextBox t in fieldDict.Values)
                {
                    t.Text = "";
                }
                CheckBox1.Checked = false;
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
         * Private method to update tables on webpage. Queries the Member
         * table.
         */
        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM Member", c);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            MemberTable.DataSource = tbl;
            MemberTable.DataBind();
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}