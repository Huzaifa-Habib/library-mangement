using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_management_system
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton3.Visible = true; //User Login
                    LinkButton5.Visible = true; //Admin login
                    LinkButton2.Visible = true; //Signup
                    LinkButton4.Visible = false; //View books
                    LinkButton1.Visible = false; //LogOut
                    LinkButton6.Visible = false; //authorManage
                    LinkButton7.Visible = false; //publishManage
                    LinkButton8.Visible = false; //Inventory
                    LinkButton9.Visible = false; //bookIssue
                    LinkButton10.Visible = false; //Greet
                    LinkButton11.Visible = true; //about
                    LinkButton12.Visible = false; //user manage



                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton3.Visible = false; //User Login
                    LinkButton5.Visible = false; //Admin login
                    LinkButton2.Visible = false; //Signup
                    LinkButton4.Visible = true; //View books
                    LinkButton1.Visible = true; //LogOut
                    LinkButton6.Visible = false; //authorManage
                    LinkButton7.Visible = false; //publishManage
                    LinkButton8.Visible = false; //Inventory
                    LinkButton9.Visible = false; //bookIssue
                    LinkButton11.Visible = true; //about
                    LinkButton12.Visible = false; //user manage

                    LinkButton10.Text = "Welcome " + Session["memberID"].ToString(); //Greet User




                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton3.Visible = false; //User Login
                    LinkButton5.Visible = false; //Admin login
                    LinkButton2.Visible = false; //Signup
                    LinkButton4.Visible = true; //View books
                    LinkButton1.Visible = true; //LogOut
                    LinkButton6.Visible = true; //authorManage
                    LinkButton7.Visible = true; //publishManage
                    LinkButton8.Visible = true; //Inventory
                    LinkButton9.Visible = true; //bookIssue
                    LinkButton10.Visible = false; //Greet User
                    LinkButton11.Visible = false; //about
                    LinkButton12.Visible = true; //user manage




                }


            }
            catch (Exception)
            {
                //{ Response.Write("<script> alert('" + ex.Message + "');</script>"); }

            }


        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBook.aspx");

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignUp.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("authorManagement.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("publisherMangement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookIssue.aspx");
        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        //Logout Event
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Session["role"] != null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }

            Response.Redirect("home.aspx");


        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("userManagement.aspx");
        }

      
    }
}