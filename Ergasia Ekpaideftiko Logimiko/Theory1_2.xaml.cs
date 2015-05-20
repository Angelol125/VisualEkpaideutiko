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
using System.Windows.Media.Animation;

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for Theory1_2.xaml
	/// </summary>
	public partial class Theory1_2 : Window
    {
        int i = 0;
        RichTextBox[] RichTextBoxes = new RichTextBox[2];
		public Theory1_2()
		{
			this.InitializeComponent();
            RichTextBoxes[0] = Rich1;
            RichTextBoxes[1] = Rich2;
			// Insert code required on object creation below this point.
		}
        private void right_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBoxes[i].Visibility = Visibility.Hidden;
            left.Visibility = Visibility.Visible;
            i++;
            RichTextBoxes[i].Visibility = Visibility.Visible;
            if (i == RichTextBoxes.Length - 1)
            {
                right.Visibility = Visibility.Hidden;
                CloseButton.Visibility = Visibility.Visible;
            }
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            RichTextBoxes[i].Visibility = Visibility.Hidden;
            right.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Hidden;
            i--;
            RichTextBoxes[i].Visibility = Visibility.Visible;
            if (i == 0)
            {
                left.Visibility = Visibility.Hidden;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseButton.Visibility = Visibility.Hidden;
            sponge.Visibility = Visibility.Visible;
            thepath.Visibility = Visibility.Visible;
            Storyboard Thesponge = Resources["scrubbing"] as Storyboard;
            Storyboard sound = Resources["sponge_mp3"] as Storyboard;
            sound.Begin();
            Thesponge.Completed += new EventHandler(Thesponge_Completed);
            Thesponge.Begin();
        }
        private void Thesponge_Completed(object sender, EventArgs e)
        {
            StudentTheory newwin = new StudentTheory();
            newwin.Show();
            this.Close();
        }
	}
}