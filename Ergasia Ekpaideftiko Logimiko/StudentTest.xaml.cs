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
	/// Interaction logic for StudentTest.xaml
	/// </summary>
	public partial class StudentTest : Window
	{
		public StudentTest()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}
        private void Hyperlink1_1_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Ακέραιο και δεκαδικό μέρος");
            Theory.Show();
            Close();
        }

        private void Hyperlink1_2_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Δέκατα, εκατοστά, χιλιοστά");
            Theory.Show();
            Close();
        }
        private void Hyperlink2_1_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Πρόσθεση και αφαίρεση απλών δεκαδικών");
            Theory.Show();
            Close();
        }
        private void Hyperlink2_2_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Υπολογισμός παραστάσεων");
            Theory.Show();
            Close();
        }
        private void Hyperlink3_1_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Απλές πράξεις");
            Theory.Show();
            Close();
        }
        private void Hyperlink3_2_Click(object sender, RoutedEventArgs e)
        {
            Tests Theory = new Tests("Σύνθετες πράξεις");
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