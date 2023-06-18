<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="unauthorized.aspx.cs" Inherits="Library_management_system.unauthorized" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3 mt-5">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Unauthorized Access</h3>
                        <p class="card-text">You do not have permission to access this page.</p>
                        <a href="home.aspx" class="btn btn-primary">Go to Home Page</a>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
