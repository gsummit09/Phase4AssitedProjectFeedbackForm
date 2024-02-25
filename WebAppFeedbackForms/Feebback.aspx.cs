using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAppFeedbackForms
{
    public partial class Feebback : System.Web.UI.Page
    {
        static SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false; 
        }

        protected void Btn1_Click(object sender, EventArgs e)
        {
            Label1.Visible=true;
            try
            {
                con = new SqlConnection("Server=tcp:feedbackfrom998.database.windows.net,1433;Initial Catalog=FeedbackFrom;Persist Security Info=False;User ID=sumuadmin;Password=Sumu@998;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand("insert into feedbackform(Fname,Lname,Age,Designation,Feed) values(@fn,@ln,@age,@des,@feed)", con);
                cmd.Parameters.AddWithValue("@fn", TextBox1.Text);
                cmd.Parameters.AddWithValue("@ln", TextBox2.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(TextBox3.Text));
                cmd.Parameters.AddWithValue("@des", TextBox4.Text);
                cmd.Parameters.AddWithValue("@feed", TextBox5.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Feedback submitted successfully ";
            }
            catch (Exception ex)
            {
                Label1.Text="error "+ex.Message;
            }
        }
    }
}