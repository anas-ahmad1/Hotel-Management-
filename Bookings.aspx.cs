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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Cancel booking button for admin
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookingExists())
            {
                checkRoomId();
                changeRoomStatus();
                cancelBooking();
            }
            else
            {
                Response.Write("<script>alert('Booking ID does not Exist');</script>");
            }
        }

        //check if booking id exists
        bool checkBookingExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Booking where BookingId='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        //Delete Booking using Booking Id
        public void cancelBooking()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Delete from Booking WHERE BookingId='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Response.Write("<script>alert('Booking Cancelled');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Booking ID does not Exist');</script>");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void checkRoomId()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from Booking where BookingId='" + TextBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["RoomId"] = dr.GetValue(3).ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }

        void changeRoomStatus()
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE Rooms set RoomStatus='Available' WHERE RoomId='" + Session["RoomId"] + "'", con);
            cmd.ExecuteNonQuery();
        }
    }
}