<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageHotel.aspx.cs" Inherits="HotelManagement.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Add New Hotel</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="70px" src="imgs/addHotel.png" />
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
                        <label>Hotel ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Hotel Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Hotel Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <%--Hotel City and Rating--%>
                  <div class="row">
                    <div class="col-md-4">
                        <label>Rating</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="1" Value="1" />
                              <asp:ListItem Text="2" Value="2" />
                              <asp:ListItem Text="3" Value="3" />
                              <asp:ListItem Text="4" Value="4" />
                              <asp:ListItem Text="5" Value="5" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>City</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="City"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>

                  <%--Hotel Address--%>
                  <div class= "row">
                    <div class="col-md-12">
                        <label>Address</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Addresss"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class= "row">
                    <div class="col-md-12">
                        <label>Description</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="MultiLine" Rows="4" placeholder="Description"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" 
                             Text="Add" onclick="Button2_Click" />
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" 
                             Text="Update" onclick="Button3_Click" />
                     </div>
                  </div>
               </div>
            </div>

            <%--delete hotel--%>
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Delete Hotel</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="70px" src="imgs/remove.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-8 mx-auto">
                        <label>Hotel ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" 
                             Text="Delete" onclick="Button4_Click" />
                     </div>
                  </div>
               </div>
            </div>

            <%--Add new Room--%>
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Add New Room</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="70px" src="imgs/addRoom.png" />
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
                        <label>Room ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Hotel ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Room Price</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Price"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Number of Beds</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="1-4"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  </div>

                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" 
                             Text="Add" onclick="Button1_Click" />
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button5" class="btn btn-lg btn-block btn-warning" runat="server" 
                             Text="Update" onclick="Button5_Click" />
                     </div>
                  </div>
               </div>
            </div>

            <%--delete room--%>
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Delete Room</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="70px" src="imgs/delRoom.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12 mx-auto">
                        <label>Room ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <asp:Button ID="Button6" class="btn btn-lg btn-block btn-danger" runat="server" 
                             Text="Delete" onclick="Button6_Click" />
                     </div>
                  </div>
               </div>
            </div>

             <%--Change room Status--%>
             <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Change Room Status</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="70px" src="imgs/status.png"  />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6 mx-auto">
                        <label>Room ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Status</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Available" Value="Available" />
                              <asp:ListItem Text="Unavailable" Value="Unavailable" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <asp:Button ID="Button7" class="btn btn-lg btn-block btn-primary" runat="server" 
                             Text="Apply" onclick="Button7_Click" />
                     </div>
                  </div>
               </div>
            </div>

            <br>
            <div class="form-group">
                <a href="Bookings.aspx"><input class="btn btn-dark btn-block btn-lg" id="Button8" type="button" value="Check Bookings" /></a>
             </div>
             <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Hotel List</h4>
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
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
