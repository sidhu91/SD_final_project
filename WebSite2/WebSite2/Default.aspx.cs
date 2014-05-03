using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ServiceReference1;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;
public partial class _Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

        TextBox1.Text = Session["username"].ToString().Trim();

    }    
           
    protected void Button3_Click(object sender, EventArgs e)
    {      
        

        Int32 index = Convert.ToInt32(DropDownList1.SelectedValue);        

        for (int i = 0; i <= index*2; i++)
        {
            TextBox tb = new TextBox();
            Label l = new Label();
            int y = i + 8;
            l.ID = "Label" + i.ToString() + i.ToString();
            if (y % 2 == 0)
                l.Text = "Input Parameter";
            else
                l.Text = "Input Datatype";
            tb.ID = "textbox" + i.ToString() + i.ToString();            
            l.Attributes.Add("runat", "Server");
            tb.Attributes.Add("runat", "Server");
            Panel1.Controls.Add(l);           
            Panel1.Controls.Add(tb);
            Panel1.Controls.Add(new LiteralControl("<br />")); ;
            
        }


            string tvalue = string.Empty;
            string controlid= string.Empty;
            for (int i = 0; i <= Panel1.Controls.Count; i++)
            {
                int y = i + 10;
                controlid = "textbox" + y.ToString();
                TextBox tb = Panel1.FindControl(controlid) as TextBox;
                if (tb != null)
                {

                    Response.Write(tb.Text.ToString());
                }
            }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        
            XmlDocument doc = new XmlDocument();

            doc.Load(@"C:\Users\Swethaa\Documents\Visual Studio 2010\WebSites\SD\XMLFile.xml");
            Response.Write("Hello");

            XmlNode Tenant = doc.CreateElement("Tenant");
            XmlNode Tenantname = doc.CreateElement("Tenantname");
            Tenantname.InnerText = TextBox1.Text;
            XmlNode servicename = doc.CreateElement("Servicename");
            servicename.InnerText = TextBox2.Text;
            XmlNode servicedesc = doc.CreateElement("ServiceDescription");
            servicedesc.InnerText = TextBox3.Text;
            XmlNode Input = doc.CreateElement("Input");
            XmlNode inpparam = doc.CreateElement("inpparam");
            inpparam.InnerText = TextBox8.Text;
            XmlNode inptype = doc.CreateElement("inptype");
            inptype.InnerText = TextBox10.Text;
            XmlNode outparam = doc.CreateElement("outparam");
            outparam.InnerText = TextBox4.Text;
            XmlNode outtype = doc.CreateElement("outtype");
            outtype.InnerText = TextBox5.Text;
            XmlNode sampleinp = doc.CreateElement("sampleinp");
            sampleinp.InnerText = TextBox6.Text;
            XmlNode sampleout = doc.CreateElement("sampleout");
            sampleout.InnerText = TextBox7.Text;
            Tenant.AppendChild(Tenantname);
            Tenant.AppendChild(servicename);
            Tenant.AppendChild(servicedesc);
            Tenant.AppendChild(Input);
            Input.AppendChild(inpparam);
            Input.AppendChild(inptype);
            Tenant.AppendChild(outparam);
            Tenant.AppendChild(outtype);

            Tenant.AppendChild(sampleinp);
            Tenant.AppendChild(sampleout);
            doc.DocumentElement.AppendChild(Tenant);
            doc.Save(@"C:\Users\Swethaa\Documents\Visual Studio 2010\WebSites\SD\XMLFile.xml"); //Writing user booking history to XMLFile2.xml
            

            string MyConString = "SERVER=localhost;" + "DATABASE=sdproj;" + "UID=root;" + "PASSWORD=patronum;";
            MySqlConnection connection = new MySqlConnection(MyConString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from tenants where uname =\'" +TextBox1.Text + "\'";
            int i = 0, d = 0;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine("City name is: " + reader["name"].ToString() + " " + reader["population"].ToString())
                 d = Convert.ToInt32(reader["tenantid"]);
                Console.Read();
            }
            

            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "INSERT INTO reqlist(reqname,servicedesc,clientid) VALUES(@first, @second, @third)";
            cmd2.Parameters.AddWithValue("@first", TextBox2.Text);
            cmd2.Parameters.AddWithValue("@second", TextBox3.Text);

            
            cmd2.Parameters.AddWithValue("@third", d);


            //cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
            //cmd.CommandType = CommandType.Text;
            cmd2.Connection = connection;
            reader.Close();

            //connection.Open();
            //int rowsAffected;

            cmd2.ExecuteNonQuery();
            
            connection.Close();

        

       
    }
}
