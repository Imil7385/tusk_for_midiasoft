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
        public new_moto()
        {
            InitializeComponent();
            //SELECT moto_list.moto_country FROM moto_list GROUP BY moto_list.moto_country;
            OleDbConnection conn1;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text = "SELECT moto_list.moto_country FROM moto_list GROUP BY moto_list.moto_country;";
            conn1 = new OleDbConnection(connectionString);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = text;
            DataAdapter1.SelectCommand = MyCommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("TABLE", "Users");
            DataAdapter1.Fill(DS1);
            DT1 = DS1.Tables[0];
            for (int i = 0; i < DT1.Rows.Count; i++)
            {
                comboBox1.Items.Add(DT1.Rows[i][0].ToString());
            }
            conn1.Close();
        }

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
    }
}
