using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.Odbc;

namespace Ergasia_Ekpaideftiko_Logimiko
{
    /// <summary>
    /// Interaction logic for Tests.xaml
    /// </summary>
    public partial class Tests : Window
    {
        public ObservableCollection<Field> Fields { get; set; }
        String Enothta;
        public Tests(String Enothta)
        {
            this.InitializeComponent();
            this.Enothta = Enothta;
            // Insert code required on object creation below this point.
            Fields = new ObservableCollection<Field>();
            String str = "Dsn=database;uid=root;pwd=paok4890";
            try
            {
                using (OdbcConnection connection = new OdbcConnection(str))
                {
                    connection.Open();
                    using (OdbcCommand cmd = new OdbcCommand("SELECT distinct `test_name` FROM test Where `TheoryReference` like '" + Enothta + "' ;", connection))
                    {
                        using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                        {
                            while (dr.Read())
                            {
                                Fields.Add(new Field() { Title = dr["test_name"].ToString() });
                                // errorMessage.Foreground = new SolidColorBrush(Colors.Blue);
                                //errorMessage.Text = "Επιτυχής σύνδεση";
                                //var newWindow = new Window1(dr["username"].ToString());
                                // newWindow.Show();
                                // this.Close();
                            }
                        }
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //  errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                // errorMessage.Text = ex.ToString();
                Console.Write(ex.ToString());
            }

            FieldsBox.ItemsSource = Fields;
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            String name = (sender as Hyperlink).CommandParameter.ToString();
            Examination newwin = new Examination(name);
            newwin.Show();
            Close();
        }
        public class Field
        {
            public string Title { get; set; }
        }
    }
}
