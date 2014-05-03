using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class View_Service_Client : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";

        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from services where status=\'A\'";
        ListItem lst2 = new ListItem("");
        ListBox1.Items.Insert(0, lst2);
        int j = 1;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem(reader2["serviceName"].ToString() + " # " + reader2["serviceid"].ToString());
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
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
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
        cmd2.CommandText = "SELECT servicewsdl from services where serviceid=" + want;

        int j = 1;
        ListItem lst2 = new ListItem(" ");
        ListBox2.Items.Insert(0, lst2);
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem(reader2["servicewsdl"].ToString());
            ListBox2.Items.Insert(j, lst);

            Console.Read();
        }
        reader2.Close();
        connection.Close();
    }
}