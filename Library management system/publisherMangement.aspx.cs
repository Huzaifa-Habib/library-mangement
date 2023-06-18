using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Library_management_system
{
    public partial class publisherMangement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //add btn
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Oops',
                        icon: 'error',
                        text: 'Author ID Is already in use.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OopsNotification", script);

            }
            else
            {
                addNewPublisher();

            }

        }

        // Update btn event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisherName();


            }
            else
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Invalid ID',
                        icon: 'error',
                        text: 'Please check the ID you entered.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);


            }

        }


        // Delete btn Event

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisher();


            }
            else
            {
                string script = @"<script>
                    Swal.fire({
                        title: 'Invalid ID',
                        icon: 'error',
                        text: 'Please check the ID you entered.',
                        confirmButtonText: 'OK'
                    });
                </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "InvalidCredentialsNotification", script);


            }

        }


        // Go btn Event
        protected void Button1_Click(object sender, EventArgs e)

        {
            getPublisherById();
        }


        bool checkPublisherExists()
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

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id = '" + TextBox1.Text.Trim() + "';", con);
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

        void addNewPublisher()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                    string script = @"<script>
                        Swal.fire({
                            title: 'Successful',
                            icon: 'success',
                            text: 'Publisher added successfully.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);
                GridView1.DataBind();



            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>"); }
        }

        void updatePublisherName()
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
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @publisher_name WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                string script = @"<script>
                        Swal.fire({
                            title: 'Successful',
                            icon: 'success',
                            text: 'Publisher Name Updated Successfully.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);

                GridView1.DataBind();


            }
            catch (Exception ex)
            { Response.Write("<script> alert('" + ex.Message + "');</script>"); }
        }

        void deletePublisher()
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
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                string script = @"<script>
                        Swal.fire({
                            title: 'Successful',
                            icon: 'success',
                            text: 'Publisher Deleted Successfully.',
                            confirmButtonText: 'OK'
                        });
                    </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessNotification", script);
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    string script = @"<script>
                        Swal.fire({
                            title: 'Invalid ID',
                            icon: 'error',
                            text: 'Please check ID you entered.',
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


    }
}