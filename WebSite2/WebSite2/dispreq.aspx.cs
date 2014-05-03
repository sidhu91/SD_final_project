using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


public partial class dispreq : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        string un = Session["username"].ToString();
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open(); 
        string selectval = DropDownList1.SelectedItem.Value;
        string[] trying = selectval.Split('#');
        string check = trying[1];
       // Response.Write(check);
        Console.WriteLine(check);
        int rid = Convert.ToInt32(check);
        //string insquery = "INSERT INTO subscriptions(providerid,reqid) VALUES('blah','"provid "')";
           /*MySqlcommand insertq = New MySqlCommand(sql, dbconn)
            dbread = dbcomm.ExecuteReader()
            dbread.Close() */
        MySqlCommand cmd = connection.CreateCommand();
        cmd.Connection = connection;
            cmd.CommandText = "SELECT * from tenants where uname =\'" +un + "\'";
            int i = 0, d = 0;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
                 d = Convert.ToInt32(reader["tenantid"]);
                Console.Read();
            }
        reader.Close();
        Session["id"] = d;
            
        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "INSERT INTO reqsubscrip(providerid, reqid) VALUES(@prov, @reqid)";
        cmd2.Parameters.AddWithValue("@prov",d);
        cmd2.Parameters.AddWithValue("@reqid", rid);
       
        
        //cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
        //cmd.CommandType = CommandType.Text;
        cmd2.Connection = connection;

  
        //int rowsAffected;

        cmd2.ExecuteNonQuery();

        connection.Close();
        Label2.Text = "Your subscription has been submitted!";

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        connection.Open();
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT reqid from reqlist";
        int i = 0;
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem("Requirement" + " " + "#" + reader["reqid"].ToString());
            DropDownList1.Items.Insert(i, lst);
            i++;
            Console.Read();
        }
        reader.Close();

        MySqlCommand cmd2 = connection.CreateCommand();
        cmd2.CommandText = "SELECT * from reqlist";
        //int i = 0;
        int j = 0;
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        while (reader2.Read())
        {
            //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
            ListItem lst = new ListItem("Req Name:" + " " + " " + reader2["reqname"].ToString() + "Req Description:" + " " + reader2["servicedesc"].ToString());
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
}