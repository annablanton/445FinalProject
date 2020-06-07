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
    public partial class HireStaff : System.Web.UI.Page
    {
        Dictionary<string, TextBox> fieldDict;
        protected void Page_Load(object sender, EventArgs e)
        {
            fieldDict = new Dictionary<string, TextBox>();
            fieldDict.Add("@firstname", TextBox1);
            fieldDict.Add("@lastname", TextBox2);
            fieldDict.Add("@hiredate", TextBox3);
            fieldDict.Add("@position", TextBox4);
            fieldDict.Add("@branchid", TextBox5);

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
                string query = ("insert into Staff VALUES(@staffid, @branchid, @hiredate, @firstname, @lastname, @position)");
                string q1 = "SELECT MAX(StaffId) FROM Staff WHERE BranchId = @branchid";
                SqlCommand cnt = new SqlCommand(q1, conn);
                cnt.Parameters.AddWithValue("@branchid", fieldDict["@branchid"].Text);
                Object temp = cnt.ExecuteScalar();
                int count = 0;
                if (temp != DBNull.Value)
                {
                    count = (int)temp;
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@staffid", count + 1);
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

        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT *, CONCAT(StaffFirstName, StaffLastName) AS StaffName FROM Staff", c);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            StaffTable.DataSource = tbl;
            StaffTable.DataBind();

            data = new SqlDataAdapter("SELECT * FROM Branch", c);
            DataTable tbl2 = new DataTable();
            data.Fill(tbl2);
            BranchTable.DataSource = tbl2;
            BranchTable.DataBind();
        }
    }
}