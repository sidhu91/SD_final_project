using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;

public partial class TestCase : System.Web.UI.Page
{
    int pid = 0;
    string filename1 = string.Empty, filename2 = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        pid = Convert.ToInt32(Session["id"]);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        string tiput = "";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        pid = Convert.ToInt32(Session["id"]);
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * from services where providerid = " + pid;
        int i = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            ListItem lst = new ListItem("Service Name : " + " " + reader["serviceName"].ToString() + "Ser ID : # " + reader["serviceid"].ToString());
            DropDownList2.Items.Insert(i, lst);
            i++;
            Console.Read();
        }
        connection.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String d = DropDownList2.SelectedValue.ToString();
        String tname = TextBox1.Text;
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";

        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "INSERT INTO testcases(testcasename,description, status, serid) VALUES( @testcasename, @description, @status, @serid)";
        
        cmd2.Parameters.AddWithValue("@status", "P");
        cmd2.Parameters.AddWithValue("@testcasename", tname);
        cmd2.Parameters.AddWithValue("@description", TextBox2.Text);
        cmd2.Parameters.AddWithValue("@serid", want);


        //cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
        //cmd.CommandType = CommandType.Text;
        cmd2.Connection = connection;


        //int rowsAffected;

        cmd2.ExecuteNonQuery();

        connection.Close();
    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        filename1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
        Session["filename1"] = filename1.ToString();
        FileUpload1.SaveAs(Server.MapPath("Files/" + filename1));
        filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
        Session["filename2"] = filename2.ToString();
        FileUpload2.SaveAs(Server.MapPath("Files/" + filename2));
        String d = DropDownList2.SelectedValue.ToString();
      //  String dllname = filename1;
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";

        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "INSERT INTO testFiles(sid,testScript,testConfig) VALUES(  @serid,@testscript,@testConfig)";

        
        cmd2.Parameters.AddWithValue("@testscript", Session["filename1"]);
        cmd2.Parameters.AddWithValue("@testConfig", Session["filename2"]);
        cmd2.Parameters.AddWithValue("@serid", want);


        //cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
        //cmd.CommandType = CommandType.Text;
        cmd2.Connection = connection;


        //int rowsAffected;

        cmd2.ExecuteNonQuery();

        connection.Close();
    }
}