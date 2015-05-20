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
	/// Interaction logic for StudentMain.xaml
	/// </summary>
	public partial class StudentMain : Window
	{
		public StudentMain(String User)
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Theory_Click(object sender, RoutedEventArgs e)
        {
            StudentTheory newwindow = new StudentTheory();
            newwindow.Show();
            Close();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            StudentTest newwindow = new StudentTest();
            newwindow.Show();
            Close();
        }
	}
}