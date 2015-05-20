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
	/// Interaction logic for TeacherMain.xaml
	/// </summary>
	public partial class TeacherMain : Window
	{
		public TeacherMain()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void TestCreate_Click(object sender, RoutedEventArgs e)
        {
            PreCreation newwin = new PreCreation("Test");
            newwin.Show();
            Close();
        }

        private void ExerciseCreate_Click(object sender, RoutedEventArgs e)
        {
            PreCreation newwin = new PreCreation("Askhsh");
            newwin.Show();
            Close();
        }

        private void ExamCreate_Click(object sender, RoutedEventArgs e)
        {
            PreCreation newwin = new PreCreation("Exam");
            newwin.Show();
            Close();
        }
	}
}