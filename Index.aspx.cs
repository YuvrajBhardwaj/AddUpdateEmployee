using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AddUpdateEmployee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void insertbtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Insert.aspx");
            SqlConnection con = new SqlConnection(cs);

            string folderPath = Server.MapPath("ProfilePic/");

            string filename = Path.GetFileName(FileUpload1.FileName);
            string extension = Path.GetExtension(filename);
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            int size = postedFile.ContentLength;

            if (FileUpload1.HasFile == true || GetImage.ImageUrl != null)
            {
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg" || GetImage.ImageUrl != null)
                {
                    if (size < 10000000 || GetImage.ImageUrl != null) 
                    {
                        string query2 = "select * from Employee_Master where id = @id";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.Parameters.AddWithValue("@id", idtxt.Text);
                        con.Open();
                        SqlDataReader dr = cmd2.ExecuteReader();
                        if (dr.HasRows == true)
                        {
                            Response.Write("<script>alert('ID Already Inserted!')</script>");
                            con.Close();
                        }
                        else
                        {

                            con.Close();
                            string path2 = string.Empty;
                            if (GetImage.ImageUrl == null || GetImage.ImageUrl == "")
                            {
                                FileUpload1.SaveAs(folderPath + filename);
                                path2 = "ProfilePic/" + filename;
                            }
                            else
                            {
                                path2 = GetImage.ImageUrl.ToString(); 
                            }
                            
                            
                            string query = "insert into Employee_Master values(@id,@firstname, @lastname, @age, @mobileno, @profilepic)";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", idtxt.Text);
                            cmd.Parameters.AddWithValue("@firstname", firstnametxt.Text);
                            cmd.Parameters.AddWithValue("@lastname", lastnametxt.Text);
                            cmd.Parameters.AddWithValue("@age", agetxt.Text);
                            cmd.Parameters.AddWithValue("@mobileno", mobilenotxt.Text);
                            cmd.Parameters.AddWithValue("@profilepic", path2);

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                //Response.Write("<script>alert('Inserted Successfully')</script>");
                                Status.Text = "Inserted Successfully";
                                Label1.Visible = false;
                                ResetControls();
                                BindGridView();
                            }
                            else
                            {
                                //Response.Write("<script>alert('Insert Failed!!! ')</script>");
                                Status.Text = "Insert Failed!!!";
                            }
                            con.Close();
                        }

                    }
                    else
                    {
                        Label1.Text = "File Size should be less than 10 MB";
                        Label1.Visible = true;
                    }
                }
                else
                {
                    Label1.Text = "Please Upload Profile Picture in a valid format.";
                    Label1.Visible = true;
                }
            }
            else
            {
                Label1.Text = "Please Upload Profile Picture";
                Label1.Visible = true;
                ValidationSummary1.Visible = true;
                RequiredFieldValidator1.Visible = true;
                RequiredFieldValidator2.Visible = true;
                RequiredFieldValidator3.Visible = true;
                RequiredFieldValidator4.Visible = true;
                RequiredFieldValidator5.Visible = true;

            }
        }

        void ResetControls()
        {
            idtxt.Text = firstnametxt.Text = lastnametxt.Text = agetxt.Text = mobilenotxt.Text = "";
            Label1.Visible = false;
            GetImage.Visible = false;
            GridView1.SelectedIndex = -1;


        }
        protected void updatebtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Update.aspx");
            SqlConnection con = new SqlConnection(cs);

            string folderPath = Server.MapPath("ProfilePic/");

            string filename = Path.GetFileName(FileUpload1.FileName);
            string extension = Path.GetExtension(filename);
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            int size = postedFile.ContentLength;

            string UpdatePath = "ProfilePic/";
            if (FileUpload1.HasFile == true)
            {
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    if (size < 10000000)
                    {
                        UpdatePath = UpdatePath + filename;
                        FileUpload1.SaveAs(Server.MapPath(UpdatePath));

                        string query = "update Employee_Master set firstname= @firstname, lastname= @lastname, age=@age, mobileno= @mobileno, profilepic=@profilepic where id=@id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", idtxt.Text);
                        cmd.Parameters.AddWithValue("@firstname", firstnametxt.Text);
                        cmd.Parameters.AddWithValue("@lastname", lastnametxt.Text);
                        cmd.Parameters.AddWithValue("@age", agetxt.Text);
                        cmd.Parameters.AddWithValue("@mobileno", mobilenotxt.Text);
                        cmd.Parameters.AddWithValue("@profilepic", UpdatePath);


                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            //Response.Write("<script>alert('Updated Successfully')</script>");
                            Status.Text = "Updated Successfully";
                            Label1.Visible = false;
                            ResetControls();
                            BindGridView();
                        }
                        else
                        {
                            //Response.Write("<script>alert('Update Failed!!! ')</script>");
                            Status.Text = "Update Failed!!!";
                        }

                        con.Close();


                    }
                    else
                    {
                        Label1.Text = "File Size should be less than 10 MB";
                        Label1.Visible = true;
                    }
                }
                else
                {
                    Label1.Text = "Please Upload Profile Picture in a valid format.";
                    Label1.Visible = true;
                }
            }
            else
            {
                UpdatePath = GetImage.ImageUrl.ToString();
                string query = "update Employee_Master set firstname= @firstname, lastname= @lastname, age=@age, mobileno= @mobileno, profilepic=@profilepic where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idtxt.Text);
                cmd.Parameters.AddWithValue("@firstname", firstnametxt.Text);
                cmd.Parameters.AddWithValue("@lastname", lastnametxt.Text);
                cmd.Parameters.AddWithValue("@age", agetxt.Text);
                cmd.Parameters.AddWithValue("@mobileno", mobilenotxt.Text);
                cmd.Parameters.AddWithValue("@profilepic", UpdatePath);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //Response.Write("<script>alert('Updated Successfully')</script>");
                    Status.Text = "Updated Successfully";
                    Label1.Visible = false;
                    ResetControls();
                    BindGridView();
                }
                else
                {
                    //Response.Write("<script>alert('Update Failed!!! ')</script>");
                    Status.Text = "Update Failed!!!";
                }

                con.Close();
            }

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee_Master";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            GridView1.DataSource = data;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            Label lblId = (Label)row.FindControl("labelID");
            Label lblFirstname = (Label)row.FindControl("labelFirstname");
            Label lblLastname = (Label)row.FindControl("labelLastname");
            Label lblAge = (Label)row.FindControl("labelAge");
            Label lblMobile = (Label)row.FindControl("labelMobile");
            Image img = (Image)row.FindControl("Image1");

            idtxt.Text = lblId.Text;
            firstnametxt.Text = lblFirstname.Text;
            lastnametxt.Text = lblLastname.Text;
            agetxt.Text = lblAge.Text;
            mobilenotxt.Text = lblMobile.Text;
            GetImage.ImageUrl = img.ImageUrl;
            GetImage.Visible = true;
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "delete from Employee_Master where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", idtxt.Text);



            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                //Response.Write("<script>alert('Deleted Successfully')</script>");
                Status.Text = "Deleted Successfully";
                Label1.Visible = false;
                GetImage.Visible = false;
                ResetControls();
                BindGridView();

                string DeletePath = Server.MapPath(GetImage.ImageUrl.ToString());
                if (File.Exists(DeletePath) == true)
                {
                    File.Delete(DeletePath);
                }
            }
            else
            {
                //Response.Write("<script>alert('Delete Failed!!! ')</script>");
                Status.Text = "Delete Failed!!!";
            }
            con.Close();
        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }
    }
}