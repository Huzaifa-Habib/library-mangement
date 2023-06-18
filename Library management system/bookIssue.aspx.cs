using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Library_management_system
{
    public partial class bookIssue : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // Go btn event
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();

        }



        // Issue btn Event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkBookExists() && checkMemberExists())
            {
                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book');</script>");
                }
                else
                {
                    issueBook();
                }
              

            }

            else
            {
                Response.Write("<script>alert('Invalid Credentials');</script>");

            }

        }



        // return btn Event
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkBookExists() && checkMemberExists())
            {
                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    string script = @"<script>
                        Swal.fire({
                            title: 'Invalid ID',
                            icon: 'error',
                            text: 'Please Enter Correct ID.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);


                }


            }

            else
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Invalid Credentials',
                        icon: 'error',
                        text: 'Please Enter Correct ID.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);

            }

        }


        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter (cmd);
                DataTable dt = new DataTable(); 
                da.Fill (dt);   
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                        string script = @"<script>
                        Swal.fire({
                            title: 'Invalid Credentials',
                            icon: 'error',
                            text: 'Please Enter Correct ID.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);
                }


                cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    string script = @"<script>
                    Swal.fire({
                        title: 'Invalid Credentials',
                        icon: 'error',
                        text: 'Please Enter Correct ID.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);
                }

            }
            catch
            {

            }
        }

        bool checkBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' AND current_stock >0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch {
                return false;
            }
        }

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch {
                return false;
            }
        }

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (member_id, member_name, book_id, book_name, issue_date, due_date) values(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update  book_master_tbl set current_stock = current_stock-1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                string script = @"<script>
                    Swal.fire({
                        title: 'Successful',
                        icon: 'success',
                        text: 'Book issued successfully.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);

                GridView1.DataBind();

            }
            catch
            {

            }
        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception )
            {
                return false;
            }

        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string script = @"<script>
                            Swal.fire({
                                title: 'Successful',
                                icon: 'success',
                                text: 'Book Returned successfully.',
                                confirmButtonText: 'OK'
                            });
                        </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);
                    GridView1.DataBind();
                    con.Close();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";


                }
                else
                {
                    string script = @"<script>
                        Swal.fire({
                            title: 'Invalid Details',
                            icon: 'error',
                            text: 'Please check the details you entered.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}