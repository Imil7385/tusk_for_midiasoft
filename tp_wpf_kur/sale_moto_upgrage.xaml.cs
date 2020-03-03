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
    /// Interaction logic for sale_moto_upgrage.xaml
    /// </summary>
    public partial class sale_moto_upgrage : Window
    {
        int id;
        public sale_moto_upgrage(int id_parsing, string moto_id)
        {
            id = id_parsing;
            InitializeComponent();
            OleDbConnection conn1;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text = "SELECT moto_list.moto_id, moto_list.moto_country, moto_list.moto_mark, moto_list.moto_model, moto_list.moto_type, moto_list.moto_engen, moto_list.moto_engen_volume, moto_list.moto_weight, moto_list.moto_horsePower, moto_list.moto_speed, moto_list.moto_input, moto_list.moto_price FROM moto_list;";
            conn1 = new OleDbConnection(connectionString);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = text;
            DataAdapter1.SelectCommand = MyCommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("TABLE", "Users");
            DataAdapter1.Fill(DS1);
            DT1 = DS1.Tables[0];
            textBox1.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][1].ToString();
            textBox2.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][2].ToString();
            textBox3.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][3].ToString();
            textBox4.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][4].ToString();
            textBox5.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][5].ToString();
            textBox6.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][6].ToString();
            textBox7.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][7].ToString();
            textBox8.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][8].ToString();
            textBox9.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][9].ToString();
            textBox10.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][10].ToString();
            textBox11.Text = DT1.Rows[Convert.ToInt32(moto_id) - 1][11].ToString();
            conn1.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new sale_moto(id);
            taskWindow.Show();
            this.Hide();
        }
    }
}
