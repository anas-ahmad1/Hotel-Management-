using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button
                    LinkButton8.Visible = true; // homepage link button
                    LinkButton6.Visible = true; // admin login link button

                    LinkButton4.Visible = false; // Hotel booking link button
                    LinkButton10.Visible = false; // Contact button
                    LinkButton5.Visible = false; // complaints button
                    LinkButton3.Visible = false; // logout link button
                    LinkButton11.Visible = false; // management hotel link button
                    LinkButton12.Visible = false; // user profile link button
                    LinkButton4.Visible = false; // Hotel booking link button
                    LinkButton7.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = true; // sign up link button
                    LinkButton8.Visible = true; // homepage link button
                    LinkButton6.Visible = true; // admin login link button
                    LinkButton10.Visible = true; // Contact button

                    LinkButton5.Visible = false; // complaints button
                    LinkButton3.Visible = true; // logout link button
                    LinkButton11.Visible = false; // manage hotel link button
                    LinkButton12.Visible = true; // user profile link button
                    LinkButton4.Visible = true; // Hotel booking link button
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["Id"].ToString();

                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button
                    LinkButton8.Visible = true; // homepage link button
                    LinkButton6.Visible = false; // admin login link button

                    LinkButton10.Visible = false; // Contact button
                    LinkButton5.Visible = true; // complaints button
                    LinkButton3.Visible = true; // logout link button
                    LinkButton11.Visible = true; // manage hotel link button
                    LinkButton12.Visible = false; // user profile link button
                    LinkButton4.Visible = false; // Hotel booking link button
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello Admin";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageHotel.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelBooking.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignup.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Complaints.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }


        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Id"] = "";
            Session["Name"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button
            LinkButton8.Visible = true; // homepage link button
            LinkButton6.Visible = true; // admin login link button

            LinkButton3.Visible = false; // logout link button
            LinkButton11.Visible = false; // management hotel link button
            LinkButton12.Visible = false; // user profile link button
            LinkButton4.Visible = false; // Hotel booking link button
            Response.Redirect("Homepage.aspx");
        }
    }
}