using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;

namespace tp_wpf_kur
{
    /// <summary>
    /// Interaction logic for autor.xaml
    /// </summary>
    public partial class autor : Window
    {
        public int id_parsing;
        OleDbConnection conn;
        string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
        OleDbCommand MyCommand = new OleDbCommand();
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        public autor()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            string text = "SELECT Users.Login, Users.Password, Users.User_id FROM Users";
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                comboBox1.Items.Add(DT.Rows[i][0].ToString());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bool connect_key = false;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (comboBox1.Text == DT.Rows[i][0].ToString() && textBox1.Text == DT.Rows[i][1].ToString())
                {
                    id_parsing = Convert.ToInt32(DT.Rows[i][2]);
                    connect_key = true;
                    break;
                }
                else
                {
                    connect_key = false;
                }
            }
            if (connect_key == true)
            {

                Window taskWindow = new Window1(id_parsing);
                taskWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
