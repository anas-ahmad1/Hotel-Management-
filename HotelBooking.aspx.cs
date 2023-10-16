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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Book hotel
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (blacklisted() == false)
            {
                if (checkHotelExists())
                {
                    if (checkRoomExists())
                    {
                        if (checkRoomAvailable())
                        {
                            BookRoom();
                        }
                        else
                        {
                            Response.Write("<script>alert('Room not available');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('There is no Room with this ID');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('There is no Hotel with this ID');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Can't Book..You are Blacklisted');</script>");
            }
        }

        //Check if hotel exists
        bool checkHotelExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Hotels where HotelId='" + TextBox1.Text.Trim() + "';", con);
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

        //Check if room exists
        bool checkRoomExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Rooms where RoomId='" + TextBox2.Text.Trim() + "';", con);
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

        //Check if room is available
        bool checkRoomAvailable()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Rooms where RoomId='" + TextBox2.Text.Trim() + "' AND RoomStatus='Available'", con);
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

        //Check if user is blacklisted or not
        bool blacklisted()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Users where UserId='" + Session["Id"]+ "'", con);
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
                if (Convert.ToString(Session["Warnings"]) == "3")
                {
                    Response.Write("<script>alert('BLACKLISTED');</script>");
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('NOT BLACKLISTED');</script>");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void BookRoom()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                Random rnd=new Random();
                int num=rnd.Next(1000);
                SqlCommand cmd = new SqlCommand("INSERT INTO Booking(BookingId,UserId,HotelId,RoomId,BookingDate) values(@BookingId,@UserId,@HotelId,@RoomId,@BookingDate)", con);

                cmd.Parameters.AddWithValue("@BookingId",num);
                cmd.Parameters.AddWithValue("@UserId", Session["Id"]);
                cmd.Parameters.AddWithValue("@HotelId", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@RoomId", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@BookingDate", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("Update Rooms Set RoomStatus='Unavailable' WHERE RoomId='" + TextBox2.Text.Trim() + "'", con);
                cmd2.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Booking Successful.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}