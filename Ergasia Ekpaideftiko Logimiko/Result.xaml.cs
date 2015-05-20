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

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for Result.xaml
	/// </summary>
	public partial class Result : Window
    {
        ArrayList answers;
        ArrayList correct;
        ArrayList questions;
        Canvas[] CanvadesR = new Canvas[10];
        Canvas[] CanvadesW = new Canvas[10];
        Label[] LabelsQuestions = new Label[10];
        public Result(ArrayList answers, ArrayList correct, ArrayList questions)
        {
            this.answers = answers;
            this.correct = correct;
            this.questions = questions;
			this.InitializeComponent();
            CanvadesR[0] = Check1;
            CanvadesR[1] = Check2;
            CanvadesR[2] = Check3;
            CanvadesR[3] = Check4;
            CanvadesR[4] = Check5;
            CanvadesR[5] = Check6;
            CanvadesR[6] = Check7;
            CanvadesR[7] = Check8;
            CanvadesR[8] = Check9;
            CanvadesR[9] = Check10;
            CanvadesW[0] = Cross1;
            CanvadesW[1] = Cross2;
            CanvadesW[2] = Cross3;
            CanvadesW[3] = Cross4;
            CanvadesW[4] = Cross5;
            CanvadesW[5] = Cross6;
            CanvadesW[6] = Cross7;
            CanvadesW[7] = Cross8;
            CanvadesW[8] = Cross9;
            CanvadesW[9] = Cross10;
            LabelsQuestions[0] = Question1;
            LabelsQuestions[1] = Question2;
            LabelsQuestions[2] = Question3;
            LabelsQuestions[3] = Question4;
            LabelsQuestions[4] = Question5;
            LabelsQuestions[5] = Question6;
            LabelsQuestions[6] = Question7;
            LabelsQuestions[7] = Question8;
            LabelsQuestions[8] = Question9;
            LabelsQuestions[9] = Question10;
		}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                LabelsQuestions[i].Visibility = Visibility.Visible;
                if (answers[i] == correct[i])
                {
                    CanvadesR[i].Visibility = Visibility.Visible;
                }
                else
                {
                    CanvadesW[i].Visibility = Visibility.Visible;
                }
            }
        }
        private void Questions_MouseEnter(object sender, MouseEventArgs e)
        {
            String name = (sender as Label).Name;
            name = name.Substring(8);
            int index = Convert.ToInt32(name) - 1;
            Question.Content = questions[index];
            theanswer.Content = answers[index];
            canvas1.Visibility = Visibility.Visible;
        }

        private void Questions_MouseLeave(object sender, MouseEventArgs e)
        {
            canvas1.Visibility = Visibility.Hidden;
        }
	}
}