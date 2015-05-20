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
	/// Interaction logic for PreCreation.xaml
	/// </summary>
	public partial class PreCreation : Window
	{
        String typeofexercise;
		public PreCreation(String typeofexercise)
		{
			this.InitializeComponent();
            this.typeofexercise = typeofexercise;
			// Insert code required on object creation below this point.
		}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (typeofexercise == "Test")
            {
                Title.Text = "Δημιουργία Τέστ";
                TestWindow.Visibility = Visibility.Visible;
            }
            else if (typeofexercise == "Askhsh")
            {
                Title.Text = "Δημιουργία Άσκησης";
                askhshWindow.Visibility = Visibility.Visible;
                Difficulty.Visibility = Visibility.Visible;
                DifficultyBlock.Visibility = Visibility.Visible;
                comboType.Visibility = Visibility.Visible;
                blockType.Visibility = Visibility.Visible;
            }
            else if (typeofexercise == "Exam")
            {
                Title.Text = "Δημιουργία Διαγωνίσματος";
                ExamTime.Visibility = Visibility.Visible;
                examcombo.Visibility = Visibility.Visible;
                ExamWindow.Visibility = Visibility.Visible;
            }
        }
        private void TestWindow_Click(object sender, RoutedEventArgs e)
        {
            if (Theory.SelectedIndex != 0 && TitleName.Text.Trim()!="")
            {
                String str = "Dsn=database;uid=root;pwd=paok4890";
                try
                {
                    using (OdbcConnection connection = new OdbcConnection(str))
                    {
                        connection.Open();
                        using (OdbcCommand cmd = new OdbcCommand("SELECT count(`test_name`) as 'number' FROM test where `test_name` like '" + TitleName.Text.Trim() + "'", connection))
                        {
                            using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                            {
                                while (dr.Read())
                                {
                                    if (Convert.ToInt32(dr["number"].ToString()) == 0)
                                    {
                                        ListBoxItem typeItem = (ListBoxItem)Theory.SelectedItem;
                                        string theoria = typeItem.Content.ToString();
                                        var newWindow = new TestExamCreation(TitleName.Text, theoria);
                                        newWindow.Show();
                                    }
                                    else
                                    {
                                        errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                                        errorMessage.Text = "Ο τίτλος υπάρχει ήδη";
                                    }

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
            else
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = "Πρέπει να επιλέξετε Ενότητα από τη Θεωρία";
            }
        }

        private void askhshWindow_Click(object sender, RoutedEventArgs e)
        {
            if (Theory.SelectedIndex != 0 && TitleName.Text.Trim() != "" && Difficulty.SelectedIndex !=0 && comboType.SelectedIndex != 0)
            {
                String str = "Dsn=database;uid=root;pwd=paok4890";
                try
                {
                    using (OdbcConnection connection = new OdbcConnection(str))
                    {
                        connection.Open();
                        using (OdbcCommand cmd = new OdbcCommand("SELECT count(`askhsh_name`) as 'number' FROM askhseis where `askhsh_name` like '" + TitleName.Text.Trim() + "'", connection))
                        {
                            using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                            {
                                while (dr.Read())
                                {
                                    if (Convert.ToInt32(dr["number"].ToString()) == 0)
                                    {
                                        ListBoxItem typeItem = (ListBoxItem)Theory.SelectedItem;
                                        string theoria = typeItem.Content.ToString();
                                        ListBoxItem typeItem2 = (ListBoxItem)Difficulty.SelectedItem;
                                        string diff = typeItem2.Content.ToString();
                                        ListBoxItem typeItem3 = (ListBoxItem)comboType.SelectedItem;
                                        string type = typeItem3.Content.ToString();

                                        if (type == "Πολλαπλής Επιλογής")
                                        {
                                            var newWindow = new AskhshCreationMul(TitleName.Text, theoria, diff);
                                            newWindow.Show();
                                        }
                                        else if (type == "Σωστό Λάθος")
                                        {
                                            var newWindow = new AskhshCreationRW(TitleName.Text, theoria, diff);
                                            newWindow.Show();
                                        }
                                        else if (type == "Συμπλήρωση Κενού")
                                        {
                                            var newWindow = new AskhshCreationGAP(TitleName.Text, theoria, diff);
                                            newWindow.Show();
                                        }
                                        
                                    }
                                    else
                                    {
                                        errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                                        errorMessage.Text = "Ο τίτλος υπάρχει ήδη";
                                    }

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
            else
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = "Πρέπει να επιλέξετε Ενότητα από τη Θεωρία";
            }
        }

        private void ExamWindow_Click(object sender, RoutedEventArgs e)
        {
            if (Theory.SelectedIndex != 0 && TitleName.Text.Trim() != "" && examcombo.SelectedIndex!=0)
            {
                String str = "Dsn=database;uid=root;pwd=paok4890";
                try
                {
                    using (OdbcConnection connection = new OdbcConnection(str))
                    {
                        connection.Open();
                        using (OdbcCommand cmd = new OdbcCommand("SELECT count(`exam_name`) as 'number' FROM exams where `exam_name` like '" + TitleName.Text.Trim() + "'", connection))
                        {
                            using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                            {
                                while (dr.Read())
                                {
                                    if (Convert.ToInt32(dr["number"].ToString()) == 0)
                                    {
                                        ListBoxItem typeItem = (ListBoxItem)Theory.SelectedItem;
                                        string theoria = typeItem.Content.ToString();
                                        int xronos = examcombo.SelectedIndex * 5;
                                        var newWindow = new ExamCreation(TitleName.Text, theoria,xronos);
                                        newWindow.Show();
                                    }
                                    else
                                    {
                                        errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                                        errorMessage.Text = "Ο τίτλος υπάρχει ήδη";
                                    }

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
            else
            {
                errorMessage.Foreground = new SolidColorBrush(Colors.Red);
                errorMessage.Text = "Πρέπει να επιλέξετε Ενότητα από τη Θεωρία";
            }
        }
	}
}