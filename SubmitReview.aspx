<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubmitReview.aspx.cs" Inherits="HotelManagement.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                           <h4>Submit Review</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/feedback.png" />
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
                        <label>Hotel Id</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                      <div class="col-md-4">
                        <label>Rating</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="1-5" Value="select" />
                              <asp:ListItem Text="1" Value="1" />
                              <asp:ListItem Text="2" Value="2" />
                              <asp:ListItem Text="3" Value="3" />
                              <asp:ListItem Text="4" Value="4" />
                              <asp:ListItem Text="5" Value="5" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                  <div class="col-md-10">
                        <label>Feedback</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Details"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                               <center>  <div class="col-8">
                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-dark" runat="server" Text="Submit" OnClick="Button1_Click" /></center>
                </div>
            </div>
               </div>
         </div>
    </div>
</div>
</asp:Content>
