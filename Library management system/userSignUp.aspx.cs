using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system
{
    public partial class userSignUp : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //SignUp btn Event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Oops',
                        icon: 'error',
                        text: 'ID is already in use try another one.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OopsNotification", script);

            }
            else
            {
                signUpNewMember();
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
                //if we find any id with select query we store it in datatable and then check if there
                //are any row we find in datatable and execute further from the result we got.
                
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '"+TextBox8.Text.Trim()+"';", con);
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
            { Response.Write("<script> alert('" + ex.Message + "');</script>");
            return false;

            }


        }

        void signUpNewMember()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                string script = @"<script>
                    Swal.fire({
                        title: 'Successful',
                        icon: 'success',
                        text: 'Your are successfully register.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);

                Response.Redirect("userLogin.aspx");

            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>"); }
        }
    }
}