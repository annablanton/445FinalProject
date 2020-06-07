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
    public partial class AddCheckoutCard : System.Web.UI.Page
    {
        Dictionary<string, TextBox> fieldDict;
        protected void Page_Load(object sender, EventArgs e)
        {
            fieldDict = new Dictionary<string, TextBox>();
            fieldDict.Add("@memberid", TextBox1);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string q1 = ("delete from CheckoutCard WHERE MemberId = @memberid");
                SqlCommand del = new SqlCommand(q1, conn);
                string query = ("insert into CheckoutCard VALUES(@memberid)");
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlCommand upd = new SqlCommand("UPDATE Member SET CardPrintDate = @date WHERE MemberId = @memberid", conn);
                upd.Parameters.AddWithValue("@date", DateTime.Today.ToString("s"));
                foreach (KeyValuePair<string, TextBox> elem in fieldDict)
                {
                    cmd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                    del.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                    upd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);

                }
                del.ExecuteNonQuery();
                upd.ExecuteNonQuery();
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

        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT *, CONCAT(MemberFirstName, MemberLastName) AS MemberName FROM CheckoutCard JOIN Member ON CheckoutCard.MemberId = Member.MemberId", c);
            DataTable tbl1 = new DataTable();
            data.Fill(tbl1);
            CardTable.DataSource = tbl1;
            CardTable.DataBind();
            DataTable tbl2 = new DataTable();
            data = new SqlDataAdapter("SELECT * FROM Member", c);
            data.Fill(tbl2);
            MemberTable.DataSource = tbl2;
            MemberTable.DataBind();
        }

        protected void MemberTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}