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
using Word = Microsoft.Office.Interop.Word;


namespace tp_wpf_kur
{
    /// <summary>
    /// Interaction logic for sale_moto_not_upgrade.xaml
    /// </summary>
    public partial class sale_moto_not_upgrade : Window
    {
        int id;
        string tmoto_id;
        public sale_moto_not_upgrade(int id_parsing, string moto_id)
        {
            tmoto_id = moto_id;
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
            textBox1.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][1].ToString();
            textBox2.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][2].ToString();
            textBox3.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][3].ToString();
            textBox4.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][4].ToString();
            textBox5.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][5].ToString();
            textBox6.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][6].ToString();
            textBox7.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][7].ToString();
            textBox8.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][8].ToString();
            textBox9.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][9].ToString();
            textBox10.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][10].ToString();
            textBox11.Text = DT1.Rows[Convert.ToInt32(moto_id)-1][11].ToString();
            conn1.Close();
        }
//Фамилия, Имя, Отчество, Серия и номер паспорта, дата рождения, номер телефона 
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new sale_moto(id);
            taskWindow.Show();
            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            query_add_in_DB("INSERT INTO clients ( client_lastName, client_name, client_middleName, client_pasportData, client_birstDay, client_phoneNumber) VALUES ('" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "')");
            int last_client_id;
            OleDbConnection conn0;
            string connectionString0 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand0 = new OleDbCommand();
            OleDbDataAdapter DataAdapter0 = new OleDbDataAdapter();
            DataTable DT0 = new DataTable();
            DataSet DS0 = new DataSet();
            string text0 = "SELECT clients.client_id FROM clients;";
            conn0 = new OleDbConnection(connectionString0);
            MyCommand0.Connection = conn0;
            MyCommand0.CommandText = text0;
            DataAdapter0.SelectCommand = MyCommand0;
            conn0.Open();
            DataAdapter0.TableMappings.Add("TABLE", "Users");
            DataAdapter0.Fill(DS0);
            DT0 = DS0.Tables[0];
            last_client_id = DT0.Rows.Count + 1;
            conn0.Close();

            query_add_in_DB("INSERT INTO sale_history (sale_userId, sale_clientId, sale_motoId, kit_id, sale_motoPrice) VALUES ('" + id.ToString() + "','" + last_client_id + "','" + tmoto_id + "','---','" + textBox12.Text + "');");

            OleDbConnection conn;
            string connectionString = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand = new OleDbCommand();
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            DataTable DT = new DataTable();
            DataSet DS = new DataSet();
            string text = "SELECT sale_history.sale_id FROM sale_history;";
            conn = new OleDbConnection(connectionString);
            MyCommand.Connection = conn;
            MyCommand.CommandText = text;
            DataAdapter.SelectCommand = MyCommand;
            conn.Open();
            DataAdapter.TableMappings.Add("TABLE", "Users");
            DataAdapter.Fill(DS);
            DT = DS.Tables[0];
            int qwe = DT.Rows.Count+1;
            conn.Close();

            string userName, userLastName;

            OleDbConnection conn1;
            string connectionString1 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand1 = new OleDbCommand();
            OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter();
            DataTable DT1 = new DataTable();
            DataSet DS1 = new DataSet();
            string text1 = "SELECT Users.User_id, Users.Name, Users.Last_name FROM Users WHERE(((Users.User_id)Like '"+ id +"'));";
            conn1 = new OleDbConnection(connectionString1);
            MyCommand1.Connection = conn1;
            MyCommand1.CommandText = text1;
            DataAdapter1.SelectCommand = MyCommand1;
            conn1.Open();
            DataAdapter1.TableMappings.Add("TABLE", "Users");
            DataAdapter1.Fill(DS1);
            DT1 = DS1.Tables[0];
            userName = DT1.Rows[0][1].ToString();
            userLastName = DT1.Rows[0][2].ToString();
            conn1.Close();

            Word.Document doc = null;

                // Создаём объект приложения
                Word.Application app = new Word.Application();
                // Путь до шаблона документа
                string source = AppDomain.CurrentDomain.BaseDirectory +  "Chek(bay_not_updgrade).docx";
                // Открываем
                doc = app.Documents.Add(source);
                doc.Activate();

                // Добавляем информацию
                // wBookmarks содержит все закладки
                Word.Bookmarks wBookmarks = doc.Bookmarks;
                Word.Range wRange;
                int i = 0;
                string[] data = new string[] {qwe.ToString(),textBox13.Text,textBox14.Text,textBox15.Text, textBox16.Text, textBox2.Text,textBox3.Text,userName,userLastName,textBox12.Text};
                foreach (Word.Bookmark mark in wBookmarks)
                {

                    wRange = mark.Range;
                    wRange.Text = data[i];
                    i++;
                }

                // Закрываем документ
                doc.Close();
                doc = null;

            OleDbConnection conn3;
            string connectionString3 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            OleDbCommand MyCommand3 = new OleDbCommand();
            OleDbDataAdapter DataAdapter3 = new OleDbDataAdapter();
            DataTable DT3 = new DataTable();
            DataSet DS3 = new DataSet();
            string text3 = "SELECT moto_storage.moto_id, moto_storage.moto_count FROM moto_storage WHERE(((moto_storage.moto_id)Like '"+ tmoto_id +"'));";
            conn3 = new OleDbConnection(connectionString3);
            MyCommand3.Connection = conn3;
            MyCommand3.CommandText = text3;
            DataAdapter3.SelectCommand = MyCommand3;
            conn3.Open();
            DataAdapter3.TableMappings.Add("TABLE", "Users");
            DataAdapter3.Fill(DS3);
            DT3 = DS3.Tables[0];
            int moto_count_in_DB = Convert.ToInt32(DT3.Rows[0][1]) - 1;
            conn3.Close();

            OleDbConnection conn2;
            string connectionString2 = @"Provider = Microsoft.JET.OLEDB.4.0; Data Source = |DataDirectory|\\MotoDB.mdb";
            string query = "UPDATE moto_storage SET moto_storage.moto_count = '" + moto_count_in_DB + "' WHERE(((moto_storage.moto_id)Like '" + tmoto_id + "'));";
            conn2 = new OleDbConnection(connectionString2);
            conn2.Open();
            OleDbCommand command2 = new OleDbCommand(query, conn2);
            command2.ExecuteNonQuery();
            conn2.Close();
        }
        #region local methods
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
