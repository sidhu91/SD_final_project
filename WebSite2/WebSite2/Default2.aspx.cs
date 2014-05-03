using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from reqlist";
        //int i = 0;
        int j = 0;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem("Req Name:" + " " + " " + reader2["reqname"].ToString() + "Req Description:" + " " + reader2["servicedesc"].ToString() + " " + "#" + reader2["reqid"].ToString());
            ListBox1.Items.Insert(j, lst);
            //ListItem lst = new ListItem("Requirement" + " " + "#" + reader["reqid"].ToString());
            //DropDownList1.Items.Insert(i, lst);
            //i++; j++;
            //ListBox1.Items.Add((
            Console.Read();
        }
        reader2.Close();
        connection.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ListBox2.Items.Clear();
        String d = ListBox1.SelectedValue.ToString();
        
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";

        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from services where reqid=" + want;

        int j = 0;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem("Ser Name:" + " " + " " + reader2["serviceName"].ToString() + "#" + reader2["serviceid"].ToString());
            ListBox2.Items.Insert(j, lst);
            //ListItem lst = new ListItem("Requirement" + " " + "#" + reader["reqid"].ToString());
            //DropDownList1.Items.Insert(i, lst);
            //i++; j++;
            //ListBox1.Items.Add((
            Console.Read();
        }
        reader2.Close();
        connection.Close();

    }


    protected void dtestScript_Click(object sender, EventArgs e)
    {
        String filePath = "~\\Files\\";
        String d = ListBox2.SelectedValue.ToString();

        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);


        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from testFiles where sid=" + want + " AND status = \'P\'";

        int j = 0;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            Session["dllFile"] = reader2.GetString(1);
            Session["configFile"] = reader2.GetString(2);
            
        }
        reader2.Close();
        connection.Close();

        string fileName = Session["dllFile"].ToString();
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
        Response.TransmitFile(Server.MapPath(filePath+fileName));
        Response.End();


    }
    protected void dConfig_Click(object sender, EventArgs e)
    {
        String filePath = "~\\Files\\";
        string fileName = Session["configFile"].ToString();
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
        Response.TransmitFile(Server.MapPath(filePath + fileName));
        Response.End();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        ListBox3.Items.Clear();
        String d = ListBox2.SelectedValue.ToString();
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);


        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from testcases where serid=" + want;

        int j = 0;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem("test Case Name:" + " " + " " + reader2["testcasename"].ToString() + "#" + reader2["testcaseid"].ToString());
            ListBox3.Items.Insert(j, lst);
            
            Console.Read();
        }
        reader2.Close();
        connection.Close();


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        String d = ListBox3.SelectedValue.ToString();
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);


        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "UPDATE testcases SET status = \'"+ DropDownList1.SelectedValue +"\' where testcaseid=" + want ;
        cmd2.Connection = connection;
        cmd2.ExecuteNonQuery();
        connection.Close();

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String d = ListBox2.SelectedValue.ToString();
        string[] checking = d.Split('#');
        int want = Convert.ToInt32(checking[1]);


        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "UPDATE services SET status = \'" + DropDownList2.SelectedValue + "\' where serviceid=" + want;
        cmd2.Connection = connection;
        cmd2.ExecuteNonQuery();
        connection.Close();

    }
}