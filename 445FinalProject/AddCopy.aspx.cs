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
    public partial class WebForm3 : System.Web.UI.Page
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
            fieldDict.Add("@branchid", TextBox2);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }

        /**
         * Method which is used when button is clicked; creates and executes necessary queries
         * then updates the tables on the webpage. In this case, a query to get the maximum
         * CopyNumber value for a book being entered is used, then an insert statement adds
         * a new copy of the book to BookCopy.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string q1 = ("SELECT MAX(CopyNumber) FROM BookCopy WHERE BookId = @bookId");
                SqlCommand cnt = new SqlCommand(q1, conn);
                cnt.Parameters.AddWithValue("@bookid", TextBox1.Text);
                Object temp = cnt.ExecuteScalar();
                int count = 0;
                if (temp != DBNull.Value)
                {
                    count = (int)temp;
                }
                string query = ("insert into BookCopy VALUES(@bookid, @copynumber, @branchid, 0)");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@copynumber", count + 1);
                foreach (KeyValuePair<string, TextBox> elem in fieldDict)
                {
                    cmd.Parameters.AddWithValue(elem.Key, elem.Value.Text == "" ? (Object)DBNull.Value : elem.Value.Text);
                }
                cmd.ExecuteNonQuery();
                Literal1.Text = "Successful insert";
                FillTable(conn);
                conn.Close();
                foreach (TextBox t in fieldDict.Values)
                {
                    t.Text = "";
                }
            }

            catch (SqlException exc)
            {
                //Literal1.Text = "Exception occurred while entering data; make sure all fields are entered correctly";
                Literal1.Text = exc.ToString();
            }

        }

        /**
         * Private method to update tables on webpage. Queries the BookCopy table joined with
         * Book and Branch to display information about the BookCopy, as well as data about
         * all books for entering copies of books which do not yet have any copies, and
         * queries the Branch table.
         */
        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM BookCopy JOIN Book ON Book.BookId = BookCopy.BookId LEFT OUTER JOIN Branch ON Branch.BranchId = BookCopy.BranchId", c);
            DataTable tbl1 = new DataTable();
            DataTable tbl2 = new DataTable();
            DataTable tbl3 = new DataTable();
            data.Fill(tbl1);
            MemberTable.DataSource = tbl1;
            MemberTable.DataBind();

            data = new SqlDataAdapter("SELECT BookId, BookTitle, CONCAT(AuthorFirstName, AuthorLastName) AS AuthorName FROM Book LEFT OUTER JOIN Author ON Book.AuthorId = Author.AuthorId", c);
            data.Fill(tbl2);
            BookTable.DataSource = tbl2;
            BookTable.DataBind();

            data = new SqlDataAdapter("SELECT * FROM Branch", c);
            data.Fill(tbl3);
            BranchTable.DataSource = tbl3;
            BranchTable.DataBind();


        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}