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
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memberID"] != null && Session["memberID"].ToString() != "")
             {
                try
                {
                    if (!IsPostBack)
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '" + Session["memberID"].ToString() + "';", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                TextBox1.Text = dr.GetValue(0).ToString();
                                TextBox2.Text = dr.GetValue(1).ToString();
                                TextBox3.Text = dr.GetValue(2).ToString();
                                TextBox4.Text = dr.GetValue(3).ToString();
                                TextBox7.Text = dr.GetValue(6).ToString();
                                TextBox11.Text = dr.GetValue(4).ToString();
                                TextBox6.Text = dr.GetValue(5).ToString();
                                TextBox5.Text = dr.GetValue(7).ToString();
                                Label1.Text = dr.GetValue(10).ToString();



                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('Something Went Wrong Refesh the Page');</script>");
                        }

                        dr.Close();


                        cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id = '" + Session["memberID"].ToString() + "';", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);

                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                        con.Close();



                    }
                }
                catch (Exception ex)

                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");


                }

            }
           
        

            
           
                
            

        }

       
    }
}