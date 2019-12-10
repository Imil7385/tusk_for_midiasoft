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
        public buy_moto()
        {
            InitializeComponent();
            OleDbConnection conn1;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text = "SELECT moto_list.moto_mark, moto_list.moto_model, moto_storage.moto_count FROM moto_list INNER JOIN moto_storage ON moto_list.moto_id = moto_storage.moto_id;";
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

            string[] country= new[] {"Япония","Китай","Италия","США","Германия"};
            for (int i=0; i < country.Length; i++)
            {
                comboBox1.Items.Add(country[i].ToString());
            }
            
            
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //textBox1.Text = dataGrid1.SelectedItem.ToString();
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView row = (DataRowView)dataGrid1.SelectedItems[0];
            textBox1.Text = row[1].ToString();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] moto_mark = new[] {"---"};
            if (comboBox1.SelectedValue.ToString() == "Япония")
            {
                moto_mark = new[] {"Yamaha","Honda","Suzuki"};
            }
            if (comboBox1.SelectedValue.ToString() == "Китай")
            {
                moto_mark = new[] { "Lifan", "Motoland", "IRBIS" };
            }
            if (comboBox1.SelectedValue.ToString() == "Италия")
            {
                moto_mark = new[] { "Ducati", "Aprilia" };
            }
            if (comboBox1.SelectedValue.ToString() == "США")
            {
                moto_mark = new[] { "Harley-Davidson" };
            }
            if (comboBox1.SelectedValue.ToString() == "Германия")
            {
                moto_mark = new[] { "BMW" };
            }

            comboBox2.Items.Clear();

            for (int i=0; i< moto_mark.Length; i++)
            {
                comboBox2.Items.Add(moto_mark[i].ToString());
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new new_moto();
            taskWindow.Show();
            this.Hide();
        }
    }
}
