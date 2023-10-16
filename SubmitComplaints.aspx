<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubmitComplaints.aspx.cs" Inherits="HotelManagement.WebForm12" %>
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
                           <h4>Sumbit Complaint</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/complain.png" />
                        </center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <div class="col-md-12">
                        <label>Details</label>
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
