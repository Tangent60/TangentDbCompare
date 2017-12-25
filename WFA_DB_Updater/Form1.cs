using System;
using System.Collections;
using System.Windows.Forms;
using DatabaseCompare.Domain;

namespace WFA_DB_Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseSQL obj1 = new DatabaseSQL();
            //obj1.IP = @"236LTLWIN8\SQLEXPRESS";
            obj1.IP = @"236LTDWIN10\SQLEXPRESS";
            obj1.UserId = "sa";
            obj1.Password = "Tangent@123";
            obj1.Name = "CorePartner";

            string conn = GetConnString(obj1);

            //SqlConnection sqlConnection1 = new SqlConnection(conn);
            //SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            //cmd.CommandText = "SELECT * FROM tbl_application";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = sqlConnection1;

            //sqlConnection1.Open();

            //reader = cmd.ExecuteReader();
            //// Data is accessible through the DataReader object here.
            ////reader[0]

            //sqlConnection1.Close();

            Database db1 = new Database(conn);

            DatabaseSQL obj2 = new DatabaseSQL();
            //obj1.IP = @"236LTLWIN8\SQLEXPRESS";
            obj2.IP = @"236LTDWIN10\SQLEXPRESS";
            obj2.UserId = "sa";
            obj2.Password = "Tangent@123";
            obj2.Name = "CorePartnerTemp";

            string conn2 = GetConnString(obj2);

            db1.LoadObjects();

            Database db2 = new Database(conn2);

            db2.LoadObjects();

            ArrayList differences = db1.CompareTo(db2);
            ListViewItem li = new ListViewItem();

            foreach (DBDifference d in differences)
            {

                //li.Items.Add(new ListViewItem(new string[] { d.Type, d.Name, d.Status }));
            }
        }

        private static string GetConnString(DatabaseSQL obj1)
        {
            return "server=" + obj1.IP + ";database=" + obj1.Name + ";uid=" + obj1.UserId + ";pwd=" + obj1.Password;
        }
    }
}
