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
    public partial class PayLateFees : System.Web.UI.Page
    {
        Dictionary<string, TextBox> fieldDict;
        /**
         * Load page; add all relevant text boxes to fieldDict to be looped through
         * to add parameters to a SqlCommand
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            fieldDict = new Dictionary<string, TextBox>();
            fieldDict.Add("@bookid", TextBox1);
            fieldDict.Add("@copynumber", TextBox2);
            fieldDict.Add("@memberid", TextBox3);
            fieldDict.Add("@checkoutdate", TextBox4);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }

        /**
         * Method which is used when button is clicked; creates and executes necessary queries
         * then updates the tables on the webpage. In this case, a delete statement is used
         * to remove an entry for an overdue book.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string query = ("delete from OverdueBookCopy WHERE Bookid = @bookid AND MemberId = @memberid AND CopyNumber = @copynumber AND CheckoutDate = @checkoutdate");
                SqlCommand cmd = new SqlCommand(query, conn);
                foreach (KeyValuePair<string, TextBox> elem in fieldDict)
                {
                    cmd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                }
                cmd.ExecuteNonQuery();
                Literal1.Text = "Successful deletion";
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
         * Private method to update tables on webpage. Queries the OverdueBookCopy table
         * joined with the Book table to get the book's title.
         */
        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT *, CONCAT(MemberFirstName, MemberLastName) AS MemberName, (DaysOverdue * 2.5) AS Fee " +
                "FROM OverdueBookCopy JOIN Book ON OverdueBookCopy.BookId = Book.BookId JOIN Member ON OverdueBookCopy.MemberId = Member.MemberId", c);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            OverdueTable.DataSource = tbl;
            OverdueTable.DataBind();
        }
    }
}