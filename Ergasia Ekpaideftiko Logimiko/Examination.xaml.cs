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
using System.Collections;
using System.Data.Odbc;

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for Examination.xaml
	/// </summary>
	public partial class Examination : Window
    {
        int question = 0;
        ArrayList right = new ArrayList();
        ArrayList a = new ArrayList();
        ArrayList b = new ArrayList();
        ArrayList c = new ArrayList();
        ArrayList ekfonish = new ArrayList();
        ArrayList type = new ArrayList();
        ArrayList choices = new ArrayList();
        ArrayList answers = new ArrayList();
        Label[] labels = new Label[4];
        Label[] labels2 = new Label[4];
        Path[] Checks = new Path[4];
        String TestName;
		public Examination(String Testname)
        {
            this.TestName = Testname;
			this.InitializeComponent();
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels2[0] = label5;
            labels2[1] = label6;
            labels2[2] = label7;
            labels2[3] = label8;
            Checks[0] = check1;
            Checks[1] = check2;
            Checks[2] = check3;
            Checks[3] = check4;
           
		}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label10.Content = TestName;
            String str = "Dsn=database;uid=root;pwd=paok4890";
            try
            {
                using (OdbcConnection connection = new OdbcConnection(str))
                {
                    connection.Open();
                    using (OdbcCommand cmd = new OdbcCommand("SELECT test_type,test_question,test_answer,test_choice1,test_choice2,test_choice3 FROM test where test_name like '"+ TestName+ "' ;", connection))
                    {
                        using (OdbcDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                        {
                            while (dr.Read())
                            {
                                ekfonish.Add(dr["test_question"].ToString());
                                type.Add(dr["test_type"].ToString());
                                right.Add(dr["test_answer"].ToString());
                                a.Add(dr["test_choice1"].ToString());
                                b.Add(dr["test_choice2"].ToString());
                                c.Add(dr["test_choice3"].ToString());
                            }
                        }
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                label3.Content = ex.ToString();
                Console.Write(ex.ToString());
            }
            NextQuestion(question);
        }

        private void labels_MouseDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < Checks.Length; i++)
            {
                Checks[i].Visibility = Visibility.Hidden;
            }
            String name = (sender as Label).Name;
            name = name.Substring(5);
            int index = Convert.ToInt32(name) - 1;
            label9.Content = labels[index].Content;
            Checks[index].Visibility = Visibility.Visible;
            Confirmation.Visibility = Visibility.Visible;
        }

        public void NextQuestion(int num)
        {
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            label8.Visibility = Visibility.Hidden;
            choices.Clear();
            numofQ.Content = " Ερώτηση " + (num + 1);
            Question.Content = ekfonish[num];
            if (type[num].ToString() == "Πολλαπλής Επιλογής")
            {
                choices.Add(right[num]);
                choices.Add(a[num]);
                choices.Add(b[num]);
                choices.Add(c[num]);
                choices.Remove(""); //Για την περίπτωση που το πολλαπλής επιλογής δεν έχει 4 επιλογές βγάζουμε τις κενές επιλογές
                Console.WriteLine("num " + num + " i " + choices.Count);
                Scramble(choices); // Μπερδεύουμε τις επιλογές
                for (int i = 0; i < choices.Count; i++)
                {
                    labels[i].Content = choices[i];
                    labels[i].Visibility = Visibility.Visible;
                    labels2[i].Visibility = Visibility.Visible;
                }
            }
            else if (type[num].ToString() == "Σωστό Λάθος")
            {
                label2.Content = "Σωστό";
                label3.Content = "Λάθος";
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
            }
            else if (type[num].ToString() == "Συμπήρωση Κενού")
            {
                //not ready yet
            }
        }
        public void Scramble(ArrayList Choices)
        {
            int limit = Choices.Count;
            String temp;
            int swapindex;
            Random rnd = new Random();
            for (int i = 0; i < limit; i++)
            {
                temp = Choices[i].ToString();
                swapindex = rnd.Next(0, limit - 1);
                Choices[i] = Choices[swapindex];
                Choices[swapindex] = temp;
            }
        }
        private void Confirmation_Click(object sender, RoutedEventArgs e)
        {
            Confirmation.Visibility = Visibility.Hidden;
            for (int i = 0; i < Checks.Length; i++)
            {
                Checks[i].Visibility = Visibility.Hidden;
            }
            answers.Add(label9.Content);
            if (ekfonish.Count > (question + 1))
            {
                question++;
                NextQuestion(question);
            }
            else
            {
                Window newwindow = new Result(answers, right, ekfonish);
                newwindow.Show();
                this.Close();
            }
        }
	}
}