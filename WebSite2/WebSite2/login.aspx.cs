using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * from tenants where uname = \'" + TextBox1.Text + "\' and password= \'" + TextBox2.Text + "\'";
        
        int i = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        Session["username"] = TextBox1.Text;
  
        
        while (reader.Read())
        {
            
            Session["auth"] = reader["auth"];
            Session["id"] = reader["tenantid"].ToString().Trim();
            //Response.Write(Session["id"].ToString());
            if (reader["auth"].ToString() == "t") {

                //Response.Redirect("Default.aspx");
                Server.Transfer("tenanthome.aspx");
            }
            if (reader["auth"].ToString() == "p")
            {

                Response.Redirect("provhome.aspx");

            }
            if (reader["auth"].ToString() == "b")
            {

                Response.Redirect("Default2.aspx", false);

            }
        }
        connection.Close();
    }
}