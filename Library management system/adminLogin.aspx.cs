using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Library_management_system
{
    public partial class adminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //admin login button event
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Now we are reading the data of a particular table in sql database and check if 
                // there is a user with same id and pass if we find that so while connection is
                //on our datareader continuesly reading the of that particular row which consist
                // of same id and pass.

                SqlCommand cmd = new SqlCommand("SELECT * from admin_login_tbl where admin_id = '" + TextBox1.Text.Trim() + "' AND password ='" + TextBox2.Text.Trim() + "' ;", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                  
                    while (dr.Read())
                    {
                        Response.Write("<script> alert('Successful')</script>");
                        Session["adminID"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";


                    }
                    Response.Redirect("home.aspx");
                }

                else
                {
                    // Display an error notification using SweetAlert
                      string script = @"<script>
                        Swal.fire({
                            title: 'Invalid Credentials',
                            icon: 'error',
                            text: 'Please check your user ID and password.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);
                }




            }
            catch (Exception ex)
            {
                { Response.Write("<script> alert('" + ex.Message + "');</script>"); }

            }


        }
    }
}