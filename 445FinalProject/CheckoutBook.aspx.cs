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
    public partial class CheckoutBook : System.Web.UI.Page
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
            fieldDict.Add("@memberid", TextBox2);

            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
            FillTable(conn);
            conn.Close();
        }

        /**
         * Method which is used when button is clicked; creates and executes necessary queries
         * then updates the tables on the webpage. In this case, two queries are needed:
         * one to get available book copies to check out, and one to create a new BookCheckout
         * row with the given book copy and member ID.
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(CONNECTION_STRING);
                conn.Open();
                string query = "insert into BookCheckout VALUES(@bookid, @copynumber, @memberid, @checkoutdate, @duedate, 0)";
                SqlCommand cmd = new SqlCommand(query, conn);
                string q;
                if (TextBox3.Text == "")
                {
                    q = "SELECT CopyNumber FROM BookCopy WHERE BookId = @bookid AND NOT EXISTS (SELECT BookId, CopyNumber " +
                "FROM BookCheckout WHERE BookCopy.BookId = BookCheckout.BookId " +
                "AND BookCopy.CopyNumber = BookCheckout.CopyNumber " +
                "AND IsReturned = 0)";
                }
                else
                {
                    q = "SELECT CopyNumber FROM BookCopy WHERE BookId = @bookid AND NOT EXISTS (SELECT BookId, CopyNumber " +
                    "FROM BookCheckout WHERE BookCopy.BookId = BookCheckout.BookId " +
                    "AND BookCopy.CopyNumber = BookCheckout.CopyNumber " +
                    "AND IsReturned = 0 " +
                    ") AND BranchId = " + TextBox3.Text;
                }
                SqlCommand copy = new SqlCommand(q, conn);
                copy.Parameters.AddWithValue("@bookid", fieldDict["@bookid"].Text);
                int copyNum = (int) copy.ExecuteScalar();
                cmd.Parameters.AddWithValue("@checkoutdate", DateTime.Today.ToString("s"));
                cmd.Parameters.AddWithValue("@copynumber", copyNum);
                cmd.Parameters.AddWithValue("@duedate", DateTime.Today.AddDays(7).ToString("s"));
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
                //Literal1.Text = "Exception occurred while entering data; make sure all fields are entered correctly";
                Literal1.Text = exc.ToString();
            }
            catch (System.NullReferenceException exc)
            {
                Literal1.Text = "No copy of book available at specified branch";
            }

        }

        /**
         * Private method to update tables on webpage. Queries a table created
         * via theta joins between Member, BookCheckout, and Book, as well as
         * a table which lists all books available at each branch.
         */
        private void FillTable(SqlConnection c)
        {
            SqlDataAdapter data = new SqlDataAdapter("SELECT *, CONCAT(MemberFirstName, MemberLastName) AS MemberName FROM BookCheckout JOIN Member ON BookCheckout.MemberId = Member.MemberId JOIN Book ON Book.BookId = BookCheckout.BookId", c);
            DataTable tbl1 = new DataTable();
            DataTable tbl2 = new DataTable();
            DataTable tbl3 = new DataTable();
            data.Fill(tbl1);
            CheckoutTable.DataSource = tbl1;
            CheckoutTable.DataBind();

           data = new SqlDataAdapter("SELECT DISTINCT Book.BookId, BookTitle, Branch.BranchId, BranchName FROM BookCopy JOIN Book ON " +
               "BookCopy.BookId = Book.BookId JOIN Branch ON BookCopy.BranchId = Branch.BranchId WHERE NOT EXISTS (SELECT BookId, CopyNumber " +
                    "FROM BookCheckout WHERE BookCopy.BookId = BookCheckout.BookId " +
                    "AND BookCopy.CopyNumber = BookCheckout.CopyNumber " +
                    "AND IsReturned = 0)", c);
            data.Fill(tbl2);
            StockTable.DataSource = tbl2;
            StockTable.DataBind();
            
            data = new SqlDataAdapter("SELECT *, CONCAT(MemberFirstName, MemberLastName) AS MemberName FROM Member", c);
            data.Fill(tbl3);
            MemberTable.DataSource = tbl3;
            MemberTable.DataBind();


        }

        protected void StockTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}