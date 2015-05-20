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
	/// Interaction logic for AskhshCreationGAP.xaml
	/// </summary>
	public partial class AskhshCreationGAP : Window
    {
        public String d;
        ArrayList numaskhsh = new ArrayList();
        ArrayList right = new ArrayList();
        ArrayList a = new ArrayList();
        ArrayList b = new ArrayList();
        ArrayList c = new ArrayList();
        ArrayList ekfonish = new ArrayList();
        Label[] labels = new Label[10];
        Canvas[] Canvdes = new Canvas[10];
        Canvas[] Canvadesg = new Canvas[10];
        Button[] Buttons = new Button[10];
        TextBox[] TextBoxesA = new TextBox[10];
        TextBox[] TextBoxesQ = new TextBox[10];
        int numberofCanvas = 0;
        Boolean edit = false;
        ArrayList assd = new ArrayList();
        String askhshname;
        String Theory;
        String difficulty;
        public AskhshCreationGAP(String askhshname, String Theory, String difficulty)
		{
            this.askhshname = askhshname;
            this.Theory = Theory;
            this.difficulty = difficulty;
            this.InitializeComponent();
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
            labels[5] = label6;
            labels[6] = label7;
            labels[7] = label8;
            labels[8] = label9;
            labels[9] = label10;
            Canvdes[0] = canvas1;
            Canvdes[1] = canvas2;
            Canvdes[2] = canvas3;
            Canvdes[3] = canvas4;
            Canvdes[4] = canvas5;
            Canvdes[5] = canvas6;
            Canvdes[6] = canvas7;
            Canvdes[7] = canvas8;
            Canvdes[8] = canvas9;
            Canvdes[9] = canvas10;
            Buttons[0] = button1;
            Buttons[1] = button2;
            Buttons[2] = button3;
            Buttons[3] = button4;
            Buttons[4] = button5;
            Buttons[5] = button6;
            Buttons[6] = button7;
            Buttons[7] = button8;
            Buttons[8] = button9;
            Buttons[9] = button10;
            TextBoxesQ[0] = textBoxQ1;
            TextBoxesQ[1] = textBoxQ2;
            TextBoxesQ[2] = textBoxQ3;
            TextBoxesQ[3] = textBoxQ4;
            TextBoxesQ[4] = textBoxQ5;
            TextBoxesQ[5] = textBoxQ6;
            TextBoxesQ[6] = textBoxQ7;
            TextBoxesQ[7] = textBoxQ8;
            TextBoxesQ[8] = textBoxQ9;
            TextBoxesQ[9] = textBoxQ10;
            TextBoxesA[0] = textBoxA1;
            TextBoxesA[1] = textBoxA2;
            TextBoxesA[2] = textBoxA3;
            TextBoxesA[3] = textBoxA4;
            TextBoxesA[4] = textBoxA5;
            TextBoxesA[5] = textBoxA6;
            TextBoxesA[6] = textBoxA7;
            TextBoxesA[7] = textBoxA8;
            TextBoxesA[8] = textBoxA9;
            TextBoxesA[9] = textBoxA10;
            Canvadesg[0] = canvasg1;
            Canvadesg[1] = canvasg2;
            Canvadesg[2] = canvasg3;
            Canvadesg[3] = canvasg4;
            Canvadesg[4] = canvasg5;
            Canvadesg[5] = canvasg6;
            Canvadesg[6] = canvasg7;
            Canvadesg[7] = canvasg8;
            Canvadesg[8] = canvasg9;
            Canvadesg[9] = canvasg10;
			// Insert code required on object creation below this point.
		}
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            String name = (sender as Button).Name;
            name = name.Substring(6);
            int index = Convert.ToInt32(name) - 1;
            Canvdes[index].Visibility = Visibility.Visible;
            edit = true;

        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            if (numberofCanvas < 9)
            {
                numberofCanvas++;
                Canvadesg[numberofCanvas].Visibility = Visibility.Visible;
                Canvdes[numberofCanvas].Visibility = Visibility.Visible;
                button11.IsEnabled = false;
                // ComboBoxes[numberofCanvas].IsEnabled = true;
            }
        }

        /*  private void button12_Click(object sender, RoutedEventArgs e)
           {
               if (numberofCanvas > 0)
               {
                   Canvadesg[numberofCanvas].Visibility = Visibility.Hidden;
                   TextBoxesQ[numberofCanvas].Text = "";
                   TextBoxesA[numberofCanvas].Text = "";
                   TextBoxesa[numberofCanvas].Text = "";
                   TextBoxesb[numberofCanvas].Text = "";
                   TextBoxesc[numberofCanvas].Text = "";
                   Console.WriteLine("Problem " + numberofCanvas);
                   if (ekfonish.Count > numberofCanvas)
                   {
                       right.RemoveAt(numberofCanvas);
                       ekfonish.RemoveAt(numberofCanvas);
                       a.RemoveAt(numberofCanvas);
                       b.RemoveAt(numberofCanvas);
                       c.RemoveAt(numberofCanvas);
                   }
                   numberofCanvas--;
                   int j=0;
                   for (int i = 0; i < numberofCanvas; i++)
                   {
                       if(ComboBoxes[i].IsEnabled==false && ComboBoxes[i].SelectedIndex!=0)
                       {
                           j++;
                       }
                   }
                   if (j == numberofCanvas)
                   {
                       button11.IsEnabled=true;
                   }
               }
           }*/

        private void buttonSaves_Click(object sender, RoutedEventArgs e)
        {
            String name = (sender as Button).Name;
            name = name.Substring(7);
            int index = Convert.ToInt32(name) - 1;
            Buttons[index].IsEnabled = true;
            if (edit == false)
            {
                button11.IsEnabled = true;
            }
            Canvdes[index].Visibility = Visibility.Hidden;
            edit = false;
            if (ekfonish.Count > numberofCanvas)
            {
                right.RemoveAt(numberofCanvas);
                ekfonish.RemoveAt(numberofCanvas);
                a.RemoveAt(numberofCanvas);
                b.RemoveAt(numberofCanvas);
                c.RemoveAt(numberofCanvas);
            }
            right.Insert(index, TextBoxesA[index].Text);
            a.Insert(index, "");
            b.Insert(index, "");
            c.Insert(index, "");
            Console.WriteLine("right " + right[index]);
            ekfonish.Insert(index, TextBoxesQ[index].Text);
            Console.WriteLine("pipihs " + ekfonish.Count);
            for (int i = 0; i < ekfonish.Count; i++)
            {
                string value = a[i] as string;
                Console.WriteLine(value);
                Console.Write(ekfonish[i] as string);
                Console.Write(right[i] as string);
                Console.Write(a[i] as string);
                Console.Write(b[i] as string);
                Console.WriteLine(c[i] as string);
            }
        }

          private void button13_Click(object sender, RoutedEventArgs e)
          {
              String str = "Dsn=database;uid=root;pwd=paok4890";
              for (int i = 0; i < ekfonish.Count; i++)
              {
                  try
                  {
                      using (OdbcConnection connection = new OdbcConnection(str))
                      {
                          connection.Open();
                          using (OdbcCommand cmd = new OdbcCommand("INSERT INTO askhseis" + "(question_number,askhsh_name,askhsh_difficulty,askhsh_type,askhsh_question,askhsh_answer,TheoryReference) VALUES (?,?,?,?,?,?,?)", connection))
                          {

                              cmd.Parameters.Add("@question_number", OdbcType.Int,
                                  255).Value = i+1;
                              Console.WriteLine(i);
                              cmd.Parameters.Add("@askhsh_name", OdbcType.VarChar,
                                  255).Value = askhshname;
                              cmd.Parameters.Add("@askhsh_difficulty", OdbcType.VarChar,
                                  255).Value = difficulty;
                              cmd.Parameters.Add("@askhsh_type", OdbcType.VarChar,
                                  255).Value = "Συμπλήρωση Κενού";
                              Console.WriteLine("Συμπλήρωση Κενού");
                              cmd.Parameters.Add("@askhsh_question", OdbcType.VarChar,
                                  255).Value = ekfonish[i];
                              Console.WriteLine(ekfonish[i]);
                              cmd.Parameters.Add("@askhsh_answer", OdbcType.VarChar,
                                 255).Value = right[i];
                              Console.WriteLine(right[i]);
                              cmd.Parameters.Add("@askhsh_choice1", OdbcType.VarChar,
                                  255).Value = a[i];
                              Console.WriteLine(a[i]);
                              cmd.Parameters.Add("@askhsh_choice2", OdbcType.VarChar,
                                  255).Value = b[i];
                              Console.WriteLine(b[i]);
                              cmd.Parameters.Add("@askhsh_choice3", OdbcType.VarChar,
                                  255).Value = c[i];
                              Console.WriteLine(c[i]);
                              cmd.Parameters.Add("@TheoryReference", OdbcType.VarChar,
                                  255).Value = Theory;
                              cmd.ExecuteNonQuery();
                              connection.Close();
                          }
                      }
                  }

                  catch (Exception ex)
                  {
                      Console.Write("An error occured: " + ex.Message.ToString());
                  }
              }
          }

          private void button12_Click(object sender, RoutedEventArgs e)
          {
              if (numberofCanvas > 0)
              {
                  Canvadesg[numberofCanvas].Visibility = Visibility.Hidden;
                  TextBoxesQ[numberofCanvas].Text = "";
                  TextBoxesA[numberofCanvas].Text = "";
                  Console.WriteLine("Problem " + numberofCanvas);
                  if (ekfonish.Count > numberofCanvas)
                  {
                      right.RemoveAt(numberofCanvas);
                      ekfonish.RemoveAt(numberofCanvas);
                      a.RemoveAt(numberofCanvas);
                      b.RemoveAt(numberofCanvas);
                      c.RemoveAt(numberofCanvas);
                  }
                  numberofCanvas--;
                  int j = 0;
                  for (int i = 0; i < numberofCanvas; i++)
                  {
                      if (Buttons[i].IsEnabled == false)
                      {
                          j++;
                      }
                  }
                  if (j == numberofCanvas)
                  {
                      button11.IsEnabled = true;
                  }
              }
          }
	}
}