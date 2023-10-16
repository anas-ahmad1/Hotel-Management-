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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Update user profile
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                if (checkpassword()==true)
                {
                    updateUserDetails();
                }
                else 
                {
                    Response.Write("<script>alert('Entered password does not match with your old password');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Member does not exist');</script>");
            }
        }

        //Check if member exists
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Users where UserId='" + TextBox8.Text.Trim() + "';", con);
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

        //Update user details
        void updateUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update Users set Name=@Name,Phone=@Phone,DOB=@DOB,Email=@Email,State_=@State_,City=@City,Password_=@NewPassword_ WHERE UserId='" + TextBox8.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State_", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@City", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Password_", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@NewPassword_", TextBox10.Text.Trim());
                int result=cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Profile Updated!');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('User ID does not Exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Check old password
        bool checkpassword()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Users where UserId='" + TextBox8.Text.Trim() + "' AND Password_='" + TextBox9.Text.Trim() + "'", con);
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

        //User cancel booking
        protected void Button2_Click(object sender, EventArgs e)
        {
                if (checkBookingExists())
                {
                    if (correctId())
                    {
                        checkwarning();
                        updateWarnings();
                        checkRoomId();
                        changeRoomStatus();
                        cancelBooking();
                        addCancelled();
                    }
                    else
                    {
                        Response.Write("<script>alert('This booking id is not yours');</script>");
                    }
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
                SqlCommand cmd = new SqlCommand("SELECT * from Booking where BookingId='" + TextBox5.Text.Trim() + "';", con);
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

                SqlCommand cmd = new SqlCommand("Delete from Booking WHERE BookingId='" + TextBox5.Text.Trim() + "'", con);
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

        //Add cancelled bookings in table
        void addCancelled()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO cancelledBookings(BookingId,UserId) values(@BookingId,@UserId)", con);

                cmd.Parameters.AddWithValue("@BookingId", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", Session["Id"]);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Cancellation Done!');</script>");
                GridView1.DataBind();

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

            SqlCommand cmd = new SqlCommand("select * from Booking where BookingId='" + TextBox5.Text.Trim() + "'", con);
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

            SqlCommand cmd = new SqlCommand("UPDATE Rooms set RoomStatus='Available' WHERE RoomId='"+ Session["RoomId"] +"'", con);
            cmd.ExecuteNonQuery();
        }

        void checkwarning()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from Users where UserId='" + Session["Id"] + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["Warnings"] = dr.GetValue(8).ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }
        void updateWarnings()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int warn=0;
            if (Convert.ToString(Session["Warnings"]) == "0")
                warn = 1;
            else if (Convert.ToString(Session["Warnings"]) == "1")
                warn = 2;
            else if (Convert.ToString(Session["Warnings"]) == "2")
                warn = 3;
            else if (Convert.ToString(Session["Warnings"]) == "3")
                warn = 4;

            Response.Write("<script>alert'" + Session["Warnings"] + "';</script>");
            SqlCommand cmd = new SqlCommand("UPDATE Users set Warnings='"+ warn+"' WHERE UserId='" + Session["Id"] + "'", con);
            cmd.ExecuteNonQuery();
        }

        bool correctId()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Booking where BookingId='" + TextBox5.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["ThisBook"] = dr.GetValue(1).ToString();
                }
            }
            if (Session["ThisBook"] == Session["Id"])
                return true;
            else
                return false;
        }
    }
}