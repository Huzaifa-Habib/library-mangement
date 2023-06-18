<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookIssue.aspx.cs" Inherits="Library_management_system.bookIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
      <script type="text/javascript">
          $(document).ready(function () {


              $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

          });
      </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="row">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Issuing</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100" src="images/books.png" />
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
                        <label>Member ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                               <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Member Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Start Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>End Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-6">
                         <asp:Button ID="Button2" class="btn w-100 btn-primary" runat="server" Text="Issue" Style="margin-top: 12px" OnClick="Button2_Click" />
                     </div>
                     <div class="col-6">
                         <asp:Button ID="Button4" class="btn w-100 btn-success" runat="server" Text="Return" Style="margin-top: 12px"  OnClick="Button4_Click"/>
                     </div>
                  </div>
               </div>
            </div>
        
            <br>
         </div>
        <div class="container">
            <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                 <h4>Issued Book List</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id"></asp:BoundField>
                                    <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name"></asp:BoundField>
                                    <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id"></asp:BoundField>
                                    <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name"></asp:BoundField>
                                    <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date"></asp:BoundField>
                                    <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        </div>
         
    </div>
 </div>

</asp:Content>
