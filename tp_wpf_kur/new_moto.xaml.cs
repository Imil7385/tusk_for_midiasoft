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
    /// Interaction logic for new_moto.xaml
    /// </summary>
    public partial class new_moto : Window
    {
        int id_parsing;
        public new_moto(int id)
        {
            id_parsing = id;
            InitializeComponent();
            query_comboBox("SELECT moto_list.moto_country FROM moto_list GROUP BY moto_list.moto_country;", "comboBox1");
            query_comboBox("SELECT moto_list.moto_type FROM moto_list GROUP BY moto_list.moto_type;", "comboBox3");
            query_comboBox("SELECT moto_list.moto_engen FROM moto_list GROUP BY moto_list.moto_engen;", "comboBox4");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            query_comboBox("SELECT moto_list.moto_mark, moto_list.moto_country FROM moto_list WHERE(((moto_list.moto_country)Like '" + comboBox1.SelectedValue.ToString() + "')) GROUP BY moto_list.moto_country, moto_list.moto_mark;", "comboBox2");
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            query_comboBox("SELECT moto_list.moto_model, moto_list.moto_mark FROM moto_list GROUP BY moto_list.moto_mark, moto_list.moto_model HAVING(((moto_list.moto_mark)Like '" + comboBox2.SelectedValue.ToString() + "'));", "comboBox6");
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            int last_moto_id;
            OleDbConnection conn0;
            string connectionString0 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand0 = new OleDbCommand();
            OleDbDataAdapter DataAdapter0 = new OleDbDataAdapter();
            DataTable DT0 = new DataTable();
            DataSet DS0 = new DataSet();
            string text0 = "SELECT moto_list.moto_id FROM moto_list;";
            conn0 = new OleDbConnection(connectionString0);
            MyCommand0.Connection = conn0;
            MyCommand0.CommandText = text0;
            DataAdapter0.SelectCommand = MyCommand0;
            conn0.Open();
            DataAdapter0.TableMappings.Add("TABLE", "Users");
            DataAdapter0.Fill(DS0);
            DT0 = DS0.Tables[0];
            last_moto_id = DT0.Rows.Count + 1;
            MessageBox.Show(last_moto_id.ToString());
            //-------------------------------------------------------------------------------------------
            query_add_in_DB("INSERT INTO moto_list ( moto_mark, moto_model, moto_country, moto_input, moto_type, moto_engen, moto_engen_volume, moto_price, moto_weight, moto_horsePower, moto_speed ) VALUES ('" + comboBox2.Text + "','" + comboBox6.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')");

            //--------------------------------------------------------------------------------------------
            query_add_in_DB("INSERT INTO moto_storage ( moto_id, moto_count) VALUES ('" + last_moto_id.ToString() + "','0')");
            
            MessageBox.Show("Ввод выполнен.");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new buy_moto(id_parsing);
            taskWindow.Show();
            this.Hide();
        }

        #region Функции
        public void query_comboBox(string query, string comboBox)
        { //Вывод данных из бд.
            var control_comboBox = (ComboBox)this.FindName(comboBox);
            
            OleDbConnection conn;
            OleDbCommand MyCommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            conn = new OleDbConnection(connectionString);
            MyCommand.Connection = conn;
            MyCommand.CommandText = query;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            control_comboBox.Items.Clear();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                control_comboBox.Items.Add(DT.Rows[i][0].ToString());
            }
            conn.Close();
        }

        public void query_add_in_DB(string query)
        {
            OleDbConnection conn;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            conn = new OleDbConnection(connectionString);
            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
<<<<<<< HEAD
        #endregion
=======

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            OleDbConnection conn1;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text = "SELECT moto_list.moto_country, moto_list.moto_mark FROM moto_list WHERE(((moto_list.moto_country)Like '" + comboBox1.SelectedValue.ToString() + "')); ";
            conn1 = new OleDbConnection(connectionString);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = text;
            DataAdapter1.SelectCommand = MyCommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("TABLE", "Users");
            DataAdapter1.Fill(DS1);
            DT1 = DS1.Tables[0];
            comboBox2.Items.Clear();
            for (int i = 0; i < DT1.Rows.Count; i++)
            {
                comboBox2.Items.Add(DT1.Rows[i][1].ToString());
            }
            conn1.Close();
        }
>>>>>>> 0b1b76558e201433470489429e6674dbead53c84
    }
}
