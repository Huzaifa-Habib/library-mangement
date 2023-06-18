<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBook.aspx.cs" Inherits="Library_management_system.viewBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
              $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

            });

        
        </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
          <div class="row justify-content-center">
              <div class="col-md-10">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row" >
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                             <Columns>
                                 <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id"></asp:BoundField>
                         
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                         <div class="container-fluid">
                                             <div class="row">
                                                 <div class="col-lg-9">
                                                     <div class="row">
                                                         <div class="col-12">
                                                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-Size="larger" > </asp:Label>
                                                         </div>
                                                     </div>
                                                      <div class="row">
                                                         <div class="col-12">
                                                             <span style="font-size:12px">
                                                                Author - <asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                             <span  style="font-size:12px">
                                                                Genre - <asp:Label ID="Label3" runat="server" Text='<%# Eval("genre") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                            <span  style="font-size:12px">
                                                                Language - <asp:Label ID="Label4" runat="server" Text='<%# Eval("language") %>' Font-Bold="true"  > </asp:Label> 
                                                            </span>


                                                         </div>

                                                     </div> 

                                                     <div class="row">
                                                         <div class="col-12">
                                                              <span style="font-size:12px">
                                                                Publisher - <asp:Label ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                             <span  style="font-size:12px">
                                                                Publish Date - <asp:Label ID="Label6" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                            <span  style="font-size:12px">
                                                                Pages - <asp:Label ID="Label7" runat="server" Text='<%# Eval("no_of_pages") %>' Font-Bold="true"  > </asp:Label>  |
                                                            </span>

                                                            <span  style="font-size:12px">
                                                                Edition - <asp:Label ID="Label8" runat="server" Text='<%# Eval("edition") %>' Font-Bold="true"  > </asp:Label> 
                                                            </span>

                                                         </div>
                                                     </div

                                                     <div class="row">
                                                         <div class="col-12">
                                                             <span style="font-size:12px">
                                                               Cost - <asp:Label ID="Label9" runat="server" Text='<%# Eval("book_cost") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                             <span  style="font-size:12px">
                                                                Actual Stock - <asp:Label ID="Label10" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="true"  > </asp:Label> |
                                                             </span>

                                                            <span  style="font-size:12px">
                                                                Availbale - <asp:Label ID="Label11" runat="server" Text='<%# Eval("current_stock") %>' Font-Bold="true"  > </asp:Label> 
                                                            </span>

                                                         </div>
                                                     </div>
                                                      <div class="row">
                                                         <div class="col-12">
                                                             <span style="font-size:12px">
                                                               Description - <asp:Label ID="Label12" runat="server" Text='<%# Eval("book_description") %>' Font-Bold="true"  > </asp:Label> 
                                                             </span>
       
                                                         </div>
                                                     </div>

                                                 </div>

                                                    <div class="col-lg-3 d-flex align-items-center justify-content-center">
                                                         <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>'/> 
                                                    </div>

                                             </div>
                                         </div>
                                     </ItemTemplate>

                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                         <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                     </div>
                  </div>
               </div>
            </div>
         </div>


          </div>
        

    </div>


</asp:Content>
