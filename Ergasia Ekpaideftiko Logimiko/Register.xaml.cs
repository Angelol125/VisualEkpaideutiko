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
using System.Text.RegularExpressions;

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for Register.xaml
	/// </summary>
	public partial class Register : Window
	{
		public Register()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            Close();
        }

        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxUsername.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = "Εισάγετε email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = "Εισάγετε έκγυρο email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {

                if (passwordBox1.Password.Length == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Εισάγετε password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Εισάγετε Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Το Confirm password πρέπει να είναι το ίδιο με το password.";
                    passwordBoxConfirm.Focus();
                }
                else if (textBoxUsername.Text.Length == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Εισάγετε Username";
                    textBoxUsername.Focus();
                }
                else if (textBoxFirstName.Text.Length == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Εισάγετε Όνομα";
                    textBoxFirstName.Focus();
                }
                else if (textBoxLastName.Text.Length == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Εισάγετε Επώνυμο";
                    textBoxLastName.Focus();
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                    errorMessage.Text = "Επιλέξτε Κατηγορία Χρήστη";
                    comboBox1.Focus();
                }
                else
                {
                    String str = "Dsn=database;uid=root;pwd=paok4890";
                    try
                    {
                        using (OdbcConnection connection = new OdbcConnection(str))
                        {
                            connection.Open();
                            using (OdbcCommand cmd = new OdbcCommand("INSERT INTO users" + "(Username,First_name,Last_name,Password,Email,Type) VALUES (?,?,?,?,?,?)", connection))
                            {

                                cmd.Parameters.Add("@Username", OdbcType.VarChar,
                                    255).Value = textBoxUsername.Text;
                                cmd.Parameters.Add("@First_name", OdbcType.VarChar,
                                    255).Value = textBoxFirstName.Text;
                                cmd.Parameters.Add("@Last_name", OdbcType.VarChar,
                                    255).Value = textBoxLastName.Text;
                                cmd.Parameters.Add("@Password", OdbcType.VarChar,
                                    255).Value = passwordBox1.Password;
                                cmd.Parameters.Add("@Email", OdbcType.VarChar,
                                    255).Value = textBoxEmail.Text;
                                cmd.Parameters.Add("@Type", OdbcType.VarChar,
                                   255).Value = comboBox1.Text;
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                errorMessage.Foreground = new SolidColorBrush(Colors.Green);
                                errorMessage.Text = "Επιτυχής δημιουργία Χρήστη";
                                Reset();
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.Write("An error occured: " + ex.Message.ToString());
                    }
                }
            }
        }
	}
}