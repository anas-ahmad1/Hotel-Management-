using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Add hotel
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkHotelExists())
            {
                Response.Write("<script>alert('Hotel Already Exist with this ID.');</script>");
            }
            else
            {
                addNewHotel();
            }
        }

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

        void addNewHotel()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Hotels(HotelId,HotelName,HotelRating,City,HotelAddress,Description_) values(@HotelId,@HotelName,@HotelRating,@City,@HotelAddress,@Description_)", con);

                cmd.Parameters.AddWithValue("@HotelId", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelName", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelRating", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@City", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelAddress", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Description_", TextBox9.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Hotel added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Update Hotel
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkHotelExists())
            {
                updateHotelByID();
            }
            else
            {
                Response.Write("<script>alert('Hotel with this ID does not exist');</script>");
            }
        }

        public void updateHotelByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update Hotels set HotelName=@HotelName,HotelRating=@HotelRating,City=@City,HotelAddress=@HotelAddress,Description_=@Description_ WHERE HotelId='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@HotelName", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelRating", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@City", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelAddress", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Description_", TextBox9.Text.Trim());
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Hotel Updated Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Hotel ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Delete hotel
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkHotelExists()) 
            {
                deleteHotelByID();
            } 
            else 
            {
                Response.Write("<script>alert('Hotel with this ID does not exist');</script>");
            }
        }

        public void deleteHotelByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from Hotels WHERE HotelId='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Hotel Deleted Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Hotel ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Add room
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkRoomExists())
            {
                Response.Write("<script>alert('Room Already Exist with this ID.');</script>");
            }
            else
            {
                if (checkHotelExists2() == false)
                {
                    Response.Write("<script>alert('There is no Hotel with this ID');</script>");
                }
                else
                {
                    addNewRoom();
                }
            }
        }

        bool checkRoomExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Rooms where RoomId='" + TextBox6.Text.Trim() + "';", con);
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

        bool checkHotelExists2()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Hotels where HotelId='" + TextBox10.Text.Trim() + "';", con);
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

        void addNewRoom()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Rooms(RoomId,HotelId,NoOfBeds,RoomPrice) values(@RoomId,@HotelId,@NoOfBeds,@RoomPrice)", con);

                cmd.Parameters.AddWithValue("@RoomId", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@HotelId", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@NoOfBeds", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@RoomPrice", TextBox8.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Room added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Update room
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkRoomExists())
            {
                updateRoomById();
            }
            else
            {
                Response.Write("<script>alert('Room with this ID does not exist');</script>");
            }
        }

        public void updateRoomById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update Rooms set NoOfBeds=@NoOfBeds,RoomPrice=@RoomPrice WHERE RoomId='" + TextBox6.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@NoOfBeds", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@RoomPrice", TextBox8.Text.Trim());
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Room Updated Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Room ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if(checkRoomExists2())
            {
                deleteRoomById();
            }
            else
            {
                Response.Write("<script>alert('Room with this ID does not exist');</script>");
            }
        }

        public void deleteRoomById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from Rooms WHERE RoomId='" + TextBox12.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Room Deleted Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Room ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkRoomExists2()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Rooms where RoomId='" + TextBox12.Text.Trim() + "';", con);
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


        //Change room status
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (checkRoomExists3())
            {
                changeStatus();
            }
            else
            {
                Response.Write("<script>alert('Room with this ID does not exist');</script>");
            }
        }

        bool checkRoomExists3()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Rooms where RoomId='" + TextBox11.Text.Trim() + "';", con);
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

        public void changeStatus()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update Rooms set RoomStatus=@RoomStatus WHERE RoomId='" + TextBox11.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@RoomStatus", DropDownList2.SelectedItem.Value);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Room Status changed Successfully');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Room ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}