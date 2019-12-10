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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public int id;
        public Window1(int id_parsing)
        {
            OleDbConnection conn;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();

            id = id_parsing - 1;
            conn = new OleDbConnection(connectionString);
            string text = "SELECT Users.User_id, Users.Worker_position, Users.name, Users.Last_name FROM Users";
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            InitializeComponent();
            textBox1.Text = DT.Rows[id][1].ToString();
            textBox2.Text = DT.Rows[id][2].ToString();
            textBox3.Text = DT.Rows[id][3].ToString();
            //Вывод в datagrid
            conn.Close();
            //SELECT moto_list.moto_mark, moto_list.moto_model, moto_storage.moto_count FROM moto_list INNER JOIN moto_storage ON moto_list.moto_id = moto_storage.moto_id;

            OleDbConnection conn1;
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            text = "SELECT moto_list.moto_id, moto_list.moto_mark, moto_list.moto_model, moto_list.moto_country, moto_list.moto_input, moto_list.moto_type, moto_list.moto_engen, moto_list.moto_engen_volume, moto_list.moto_price FROM moto_list ORDER BY moto_list.moto_id;";
            conn1 = new OleDbConnection(connectionString);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = text;
            DataAdapter1.SelectCommand = MyCommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("TABLE", "Users");
            DataAdapter1.Fill(DS1);
            DT1 = DS1.Tables[0];
            dataGrid1.ItemsSource = DT1.DefaultView;
            conn1.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new moto_storage();
            taskWindow.Show();
            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new buy_moto();
            taskWindow.Show();
            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new sale_moto();
            taskWindow.Show();
            this.Hide();
        }
    }
}
