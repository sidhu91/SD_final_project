using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class mysubsc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        string tiput = "";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        int pid = Convert.ToInt32(Session["id"]) ;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * from reqsubscrip join reqlist where reqsubscrip.providerid = " + pid;
        int i = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            
            ListItem lst = new ListItem("Service Name : " + " " + reader["reqname"].ToString() + "Service Desc: " + reader["servicedesc"].ToString() + "Submitted BY: " + reader["clientid"].ToString());
            ListBox1.Items.Insert(i, lst);
            i++;
            Console.Read();
        }
        connection.Close();
       
    }
}