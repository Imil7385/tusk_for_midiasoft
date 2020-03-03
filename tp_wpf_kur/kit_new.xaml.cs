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
    /// Логика взаимодействия для kit_new.xaml
    /// </summary>
    public partial class kit_new : Window
    {
        int id;
        string moto_list_id;
        public kit_new(int id_parsing)
        {
            id = id_parsing;
            InitializeComponent();
            query_comboBox("SELECT moto_list.moto_country FROM moto_list GROUP BY moto_list.moto_country;", "comboBox1");
            query_comboBox("SELECT kit_list.kit_name FROM kit_list GROUP BY kit_list.kit_name;", "comboBox5");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new kit_bay(id);
            taskWindow.Show();
            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            OleDbConnection conn;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            conn = new OleDbConnection(connectionString);
            string text = "SELECT moto_list.moto_id, moto_list.moto_country, moto_list.moto_mark, moto_list.moto_model, moto_list.moto_input FROM moto_list WHERE(((moto_list.moto_country)Like '" + comboBox1.SelectedValue.ToString() + "') AND((moto_list.moto_mark)Like '" + comboBox2.SelectedValue.ToString() + "') AND((moto_list.moto_model)Like '" + comboBox3.SelectedValue.ToString() + "') AND((moto_list.moto_input)Like '" + comboBox4.SelectedValue.ToString() + "'));";
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (comboBox1.Text == DT.Rows[i][1].ToString() && comboBox2.Text == DT.Rows[i][2].ToString() && comboBox3.Text == DT.Rows[i][3].ToString() && comboBox4.Text == DT.Rows[i][4].ToString())
                {
                    moto_list_id = DT.Rows[i][0].ToString();
                    break;
                }
                
            }
            query_add_in_DB("INSERT INTO kit_list ( moto_id, kit_name, kit_weight, kit_horsePower, kit_speed, kit_installTime, kit_price ) VALUES ('" + moto_list_id.ToString() + "','" + comboBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");

            int last_kit_id;
            OleDbConnection conn0;
            string connectionString0 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand0 = new OleDbCommand();
            OleDbDataAdapter DataAdapter0 = new OleDbDataAdapter();
            DataTable DT0 = new DataTable();
            DataSet DS0 = new DataSet();
            string text0 = "SELECT kit_list.moto_id FROM kit_list;";
            conn0 = new OleDbConnection(connectionString0);
            MyCommand0.Connection = conn0;
            MyCommand0.CommandText = text0;
            DataAdapter0.SelectCommand = MyCommand0;
            conn0.Open();
            DataAdapter0.TableMappings.Add("TABLE", "Users");
            DataAdapter0.Fill(DS0);
            DT0 = DS0.Tables[0];
            last_kit_id = DT0.Rows.Count;

            query_add_in_DB("INSERT INTO kit_storage ( kit_id, kit_count) VALUES ('" + last_kit_id.ToString() + "','0')");
            MessageBox.Show("Добавлено");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            query_comboBox("SELECT moto_list.moto_mark, moto_list.moto_country FROM moto_list WHERE(((moto_list.moto_country)Like '" + comboBox1.SelectedValue.ToString() + "')) GROUP BY moto_list.moto_country, moto_list.moto_mark;", "comboBox2");
        }

        

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            query_comboBox("SELECT moto_list.moto_model, moto_list.moto_mark FROM moto_list GROUP BY moto_list.moto_mark, moto_list.moto_model HAVING(((moto_list.moto_mark)Like '" + comboBox2.SelectedValue.ToString() + "'));", "comboBox3");
        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            query_comboBox("SELECT moto_list.moto_input, moto_list.moto_model FROM moto_list WHERE(((moto_list.moto_model)Like '" + comboBox3.SelectedValue.ToString() + "')); ", "comboBox4");
        }

        #region local methods
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
        #endregion
    }
}
