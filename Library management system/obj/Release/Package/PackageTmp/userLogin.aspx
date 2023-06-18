<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="Library_management_system.userLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card" style ="margin-top:20px">
                    <center><img src="images/generaluser.png" width ="150" style ="margin-top:10px" /></center>
                
                        <div class="card-body">
                            <center><h3 class="card-title">Member Login</h3></center>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Enter Member Id">

                                        </asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Enter Password" TextMode="Password" style ="margin-top:10px">

                                        </asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-primary w-100  " Style="margin-top: 20px" OnClick="Button1_Click" />
                                    </div>

                                     <div class="form-group">
                                         <a href="userSignUp.aspx">
                                             <input type="button" id="Button2" class="btn btn-info  w-100" value="Sign Up" style ="margin-top:10px; color:aliceblue"  />
                                         </a>
                                        
                                    </div>
                                    
                                </div>
                             </div>

                        </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>

