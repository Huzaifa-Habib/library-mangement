<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignUp.aspx.cs" Inherits="Library_management_system.userSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100" src="images/generaluser.png"/>
                            <h3>User Registration</h3>
                        </center>
                     </div>
                  </div>
    
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Sindh" Value="Sindh" />
                              <asp:ListItem Text="Balochistan" Value="Balochistan" />
                              <asp:ListItem Text="Islamabad" Value="Islamabad" />

                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                    <div class="row" style ="margin-top:10px">
                         <div class="col-md-6">
                            <label>User ID</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                            </div>
                         </div>
                         <div class="col-md-6">
                            <label>Password</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                         </div>
                     </div>
                    <div class="form-group text-center" style ="margin-top:15px">
                        <asp:Button class="btn btn-success w-50" ID="Button1" runat="server" Text="Sign Up" Style="margin-bottom: 20px" OnClick="Button1_Click" />               
                    </div>
                  
               </div>
                   

            </div>
         
         </div>
      </div>
   </div>

</asp:Content>
