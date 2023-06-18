<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="Library_management_system.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card" style ="margin-top:20px">
                    <center><img src="images/adminuser.png" width ="150" style ="margin-top:10px" /></center>
                
                        <div class="card-body">
                            <center><h3 class="card-title">Admin Login</h3></center>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Enter Admin Id">

                                        </asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Admin Password" TextMode="Password" style ="margin-top:10px">

                                        </asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-primary w-100  " Style="margin-top: 20px; margin-bottom: 30px;" OnClick="Button1_Click" />
                                    </div>

                     
                                    
                                </div>
                             </div>

                        </div>
                </div>

            </div>

        </div>

    </div>


</asp:Content>
