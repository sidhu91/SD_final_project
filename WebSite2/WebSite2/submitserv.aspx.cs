using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;

public partial class submitserv : System.Web.UI.Page
{
    string filename = string.Empty;
    string filename2 = string.Empty;
    int pid = 0;
    string[] services;
    protected void Page_Load(object sender, EventArgs e)
    {
        pid = Convert.ToInt32(Session["id"]);
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        string tiput = "";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
         pid = Convert.ToInt32(Session["id"]);
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * from reqsubscrip join reqlist where reqsubscrip.providerid = " + pid + " AND reqsubscrip.reqid = reqlist.reqid";
        int i = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            ListItem lst = new ListItem("Service Name : " + " " + reader["reqname"].ToString()  + "Req ID : # " + reader["reqid"].ToString());
            ListBox1.Items.Insert(i, lst);
            i++;
            Console.Read();
        }
        connection.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       String d = ListBox1.SelectedValue.ToString();
       String sname = TextBox2.Text;
       string[] checking = d.Split('#');
       int want = Convert.ToInt32(checking[1]);
       string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
       
       MySqlConnection connection = new MySqlConnection(MyConString);
       connection.Open();
       MySqlCommand cmd2 = connection.CreateCommand();
       cmd2.CommandText = "INSERT INTO services(reqid,servicewsdl,serviceName,providerid, status) VALUES(@reqid, @servicewsdl, @servicename, @pid, @status)";
       cmd2.Parameters.AddWithValue("@pid", pid);
       cmd2.Parameters.AddWithValue("@status", "P");
       cmd2.Parameters.AddWithValue("@servicename", sname);
       cmd2.Parameters.AddWithValue("@servicewsdl", TextBox1.Text);
       cmd2.Parameters.AddWithValue("@reqid", want);


       //cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
       //cmd.CommandType = CommandType.Text;
       cmd2.Connection = connection;


       //int rowsAffected;

       cmd2.ExecuteNonQuery();

       connection.Close();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("TestCase.aspx");
    }
}