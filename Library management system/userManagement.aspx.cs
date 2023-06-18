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
    public partial class userManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }


        // Go btn
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();

        }


        // active btn
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");

        }


        //pending btn
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");

        }


        //disable btn
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }

        // Delete member
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMember();

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

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '" + TextBox1.Text.Trim() + "';", con);
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

        void getMemberByID()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(0).ToString();
                            TextBox7.Text = dr.GetValue(10).ToString();
                            TextBox8.Text = dr.GetValue(1).ToString();
                            TextBox3.Text = dr.GetValue(2).ToString();
                            TextBox4.Text = dr.GetValue(3).ToString();
                            TextBox9.Text = dr.GetValue(4).ToString();
                            TextBox10.Text = dr.GetValue(5).ToString();
                            TextBox11.Text = dr.GetValue(6).ToString();
                            TextBox6.Text = dr.GetValue(7).ToString();
                            

                        }

                    }
                    else
                    {
                        string script = @"<script>
                            Swal.fire({
                                title: 'Invalid Credentials',
                                icon: 'error',
                                text: 'Invalid Credentials.',
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
            else
            {
                string script = @"<script>
                            Swal.fire({
                                title: 'Invalid ID',
                                icon: 'error',
                                text: 'Invalid ID.',
                                confirmButtonText: 'OK'
                            });
                        </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);


            }

            
        }

        void updateMemberStatusByID(string status)

        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl set account_status='" + status + "' where member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    string script = @"<script>
                        Swal.fire({
                            title: 'Successful',
                            icon: 'success',
                            text: 'Member status updated.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Invalid Credentials',
                        icon: 'error',
                        text: 'Invalid ID.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);



            }



        }

       

        void deleteMember()
        {
            if (checkMemberExists()) {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //PlaceHolders "@" to insert values of each fields
                    //Trim function to ignore white spaces
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    string script = @"<script>
                        Swal.fire({
                            title: 'Successful',
                            icon: 'success',
                            text: 'Member deleted successfully.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);
                    Response.Redirect(Request.Url.AbsoluteUri);



                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "');</script>");
                }
               
            }
            else
            {
                Response.Write("<script> alert('Id should not be Empty')</script>");


            }
            
        }
    }
}