<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="Library_management_system.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
          $(document).ready(function () {


             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

         });
     </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
      <div class="row" style ="margin-top:10px">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100" src="images/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                        <center >
                           <h4>Your Profile</h4>
                           <span >Account Status - </span>
                           <asp:Label style="background:dodgerblue"  class="badge badge-pill badge-warning" ID="Label1" runat="server" ></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Date" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ReadOnly="true" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                             <asp:TextBox CssClass="form-control" ReadOnly="true" ID="TextBox11" runat="server" placeholder="State" ></asp:TextBox>

                           
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                            <asp:TextBox class="form-control" ReadOnly="true" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ReadOnly="true" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ReadOnly="true" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 
                
               </div>
            </div>
         </div>
         <div class="col-12" style="margin-top:12px">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100" src="images/books1.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                        <center>
                           <h4>Your Issued Books</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your books info"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row" style ="margin-top:10px">
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                                <asp:BoundField DataField="member_name" HeaderText="Full Name" SortExpression="Full Name" />
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="Book ID" />
                                <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="Book Name" />
                                <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="Issue Date" />
                                <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="Due Date" />
                            </Columns>
                        </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
