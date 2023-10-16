using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                     con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from Users where UserId='" + TextBox1.Text.Trim() + "' AND Password_='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) 
                {
                     while (dr.Read()) 
                     {
                         Response.Write("<script>alert('Successful login');</script>");
                         Session["Id"] = dr.GetValue(0).ToString();
                         Session["role"] = "user";
                         Session["Name"] = dr.GetValue(1).ToString();
                     }
                     Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex) 
            {
            }
        }
    }
}