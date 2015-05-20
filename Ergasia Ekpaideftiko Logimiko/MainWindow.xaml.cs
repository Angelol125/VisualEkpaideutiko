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
using System.Data.Odbc;

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}
		private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Register registration = new Register();
            registration.Show();
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String str = "Dsn=database;uid=root;pwd=paok4890";
            try
            {
                using (OdbcConnection connection = new OdbcConnection(str))
                {
                    connection.Open();
                    using (OdbcCommand cmd = new OdbcCommand("SELECT Username,Type FROM users WHERE Username = '" + textBox1.Text.Trim() + "' AND Password = '" + passwordBox1.Password.Trim() + "'", connection))
                    {
                        using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                        {
                            if (dr.HasRows)
                            {
                                errorMessage.Foreground = new SolidColorBrush(Colors.Blue);
                                errorMessage.Text = "Επιτυχής σύνδεση";
                                if (dr["Type"].ToString() == "Μαθητής")
                                {
                                    var newWindow = new StudentMain(dr["username"].ToString());
                                    newWindow.Show();
                                }
                                else if (dr["Type"].ToString() == "Καθηγητής")
                                {
                                    var newWindow = new TeacherMain();
                                    newWindow.Show();
                                }
                                this.Close();
                            }
                            else
                            {
                                errorMessage.FontWeight = FontWeights.Bold;
                                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                                errorMessage.Text = "Ανεπιτυχής Σύνδεση";
                            }
                        }
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = ex.ToString();
                Console.Write(ex.ToString());
            }
        
        }
	}
}