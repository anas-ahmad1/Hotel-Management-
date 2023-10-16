<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="HotelManagement.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <img src="imgs/bg1.png"  width="1345" height="500" class="image-fluid" />    
    </div>

    <div>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Hotel Booking</h2>
                  <p><b>3 Simple Steps-</b></p>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                   <img width="150px" src="imgs/SearchHotel.png" />
                  <h4>Search Hotels</h4>
                  <p class="text-justify">You can look for hotels all over the country. Then you can even check rooms according to their prices.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                   <img width="150px" src="imgs/ChooseDate.png" />             
                  <h4>Choose Date</h4>
                  <p class="text-justify">All you have to do is to choose the date for the booking after making sure that the room is available</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                   <img width="150px" src="imgs/bookOnline.png" />   
                  <h4>Book Online</h4>
                  <p class="text-justify">And there you are. With just one click you will be able to book a room in any hotel anywhere in the country</p>
               </center>
            </div>
         </div>
      </div>
   </div>
   <div>
   </div>


</asp:Content>
