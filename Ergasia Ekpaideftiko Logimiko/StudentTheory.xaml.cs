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

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for StudentTheory.xaml
	/// </summary>
	public partial class StudentTheory : Window
	{
		public StudentTheory()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Hyperlink1_1_Click(object sender, RoutedEventArgs e)
        {
            Theory1_1 Theory = new Theory1_1();
            Theory.Show();
            Close();
        }

        private void Hyperlink1_2_Click(object sender, RoutedEventArgs e)
        {
            Theory1_2 Theory = new Theory1_2();
            Theory.Show();
            Close();
        }
        private void Hyperlink2_1_Click(object sender, RoutedEventArgs e)
        {
            Theory2_1 Theory = new Theory2_1();
            Theory.Show();
            Close();
        }
        private void Hyperlink2_2_Click(object sender, RoutedEventArgs e)
        {
            Theory2_2 Theory = new Theory2_2();
            Theory.Show();
            Close();
        }
        private void Hyperlink3_1_Click(object sender, RoutedEventArgs e)
        {
            Theory3_1 Theory = new Theory3_1();
            Theory.Show();
            Close();
        }
        private void Hyperlink3_2_Click(object sender, RoutedEventArgs e)
        {
            Theory3_2 Theory = new Theory3_2();
            Theory.Show();
            Close();
        }

        private void left_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StudentMain newwin = new StudentMain("user");
            newwin.Show();
            Close();
			
        }
	}
}