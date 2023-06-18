using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system
{
    public partial class authorManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }


        // Add btn event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                Response.Write("<script> alert('Author is alredy in the list.')</script>");

            }
            else
            {
                addNewAuthor();

            }

        }


        // Update btn event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                updateAuthorName();
             

            }
            else
            {
                Response.Write("<script> alert('Author is not in the list.')</script>");


            }

        }


        // Delete btn Event

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExists())
            {
                deleteAuthor();


            }
            else
            {
                Response.Write("<script> alert('Author is not in the list.')</script>");


            }

        }


        // Go btn Event
        protected void Button1_Click(object sender, EventArgs e)

        {
            getAuthorById();
        }

        bool checkAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //if we find any id with select query we store it in datatable and then check if there
                //are any row we find in datatable and execute further from the result we got.

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id = '" + TextBox1.Text.Trim() + "';", con);
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
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
                return false;

            }


        }


        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //PlaceHolders "@" to insert values of each fields
                //Trim function to ignore white spaces
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
               
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Successful')</script>");
                GridView1.DataBind();
                Response.Redirect(Request.Url.AbsoluteUri);


            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>"); }
        }

        void updateAuthorName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //PlaceHolders "@" to insert values of each fields
                //Trim function to ignore white spaces
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id = '"+TextBox1.Text.Trim()+"'", con);
                
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Author Name Updated Successfully')</script>");

                Response.Redirect(Request.Url.AbsoluteUri);


            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>"); }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //PlaceHolders "@" to insert values of each fields
                //Trim function to ignore white spaces
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Author Deleted Successfully')</script>");
                Response.Redirect(Request.Url.AbsoluteUri);



            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        void getAuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    

    }



}