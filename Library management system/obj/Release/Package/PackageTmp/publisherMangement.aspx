<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="publisherMangement.aspx.cs" Inherits="Library_management_system.publisherMangement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
          $(document).ready(function () {

             //$(document).ready(function () { 
             //$('.table').DataTable();
             // });

             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
             //$('.table1').DataTable();
         });
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="margin-top:20px">
            <div class="col-md-5">

                <div class="card" >
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="images/publisher.png" />
                                       
                                 </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Author Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-top:20px">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-success w-100" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-warning w-100" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-danger w-100" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Publisher List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="publisher_id">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id"></asp:BoundField>
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            </div>
                        </div>


                    </div>
                </div>


            </div>

        </div>
    </div>

</asp:Content>
