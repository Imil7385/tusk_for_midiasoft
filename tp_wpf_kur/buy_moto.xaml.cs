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
    /// Interaction logic for buy_moto.xaml
    /// </summary>
    public partial class buy_moto : Window
    {
        int id_parsing;
        string moto_id;
        int moto_count_in_DB;
        public buy_moto(int id)
        {
            id_parsing = id;
            InitializeComponent();
            OleDbConnection conn1;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text = "SELECT moto_list.moto_id, moto_list.moto_country, moto_list.moto_mark, moto_list.moto_model, moto_list.moto_type, moto_list.moto_engen, moto_list.moto_engen_volume, moto_list.moto_weight, moto_list.moto_horsePower, moto_list.moto_speed, moto_list.moto_input, moto_list.moto_price, moto_storage.moto_count FROM moto_list INNER JOIN moto_storage ON moto_list.moto_id = moto_storage.moto_id;";
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

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView row = (DataRowView)dataGrid1.SelectedItems[0];
            textBox1.Text = row[1].ToString();
            textBox2.Text = row[2].ToString();
            textBox3.Text = row[3].ToString();
            textBox4.Text = row[4].ToString();
            textBox5.Text = row[5].ToString();
            textBox6.Text = row[6].ToString();
            textBox7.Text = row[7].ToString();
            textBox8.Text = row[8].ToString();
            textBox9.Text = row[9].ToString();
            textBox10.Text = row[10].ToString();
            textBox11.Text = row[11].ToString();
            moto_id = row[0].ToString();
            moto_count_in_DB = Convert.ToInt32(row[12]);
            //MessageBox.Show(moto_id);
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new new_moto(id_parsing);
            taskWindow.Show();
            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //UPDATE moto_storage1 SET moto_storage1.moto_count = Количество WHERE(((moto_storage1.moto_id)Like "Id Мото"));
            OleDbConnection conn;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            string query = "UPDATE moto_storage SET moto_storage.moto_count = '" + (Convert.ToInt32(textBox12.Text) + moto_count_in_DB) + "' WHERE(((moto_storage.moto_id)Like '"+ moto_id +"'));";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            Window tw = new buy_moto(id_parsing);
            tw.Show();
            this.Close();
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new Window1(id_parsing);
            taskWindow.Show();
            this.Hide();
        }
    }
}
