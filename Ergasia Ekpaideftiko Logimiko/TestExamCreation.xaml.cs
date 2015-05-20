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
using System.Collections;

namespace Ergasia_Ekpaideftiko_Logimiko
{
	/// <summary>
	/// Interaction logic for TestExamCreation.xaml
	/// </summary>
	public partial class TestExamCreation : Window
    {
        public String d;
        ArrayList numaskhsh = new ArrayList();
        ArrayList right = new ArrayList();
        ArrayList a = new ArrayList();
        ArrayList b = new ArrayList();
        ArrayList c = new ArrayList();
        ArrayList ekfonish = new ArrayList();
        Label[] labels = new Label[10];
        Label[] labelsa = new Label[10];
        Label[] labelsb = new Label[10];
        Label[] labelsc = new Label[10];
        Canvas[] Canvdes = new Canvas[10];
        Canvas[] Canvadesg = new Canvas[10];
        Button[] Buttons = new Button[10];
        TextBox[] TextBoxesA = new TextBox[10];
        TextBox[] TextBoxesQ = new TextBox[10];
        TextBox[] TextBoxesa = new TextBox[10];
        TextBox[] TextBoxesb = new TextBox[10];
        TextBox[] TextBoxesc = new TextBox[10];
        ComboBox[] ComboBoxes = new ComboBox[10];
        ComboBox[] ComboBoxesRW = new ComboBox[10];
        int first = 0;
        int numberofCanvas = 0;
        Boolean edit = false;
        String TitleName;
        String TheoryReference;
		public TestExamCreation(String TitleName,String TheoryReference)
		{
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
            labelsa[0] = labela1;
            labelsa[1] = labela2;
            labelsa[2] = labela3;
            labelsa[3] = labela4;
            labelsa[4] = labela5;
            labelsa[5] = labela6;
            labelsa[6] = labela7;
            labelsa[7] = labela8;
            labelsa[8] = labela9;
            labelsa[9] = labela10;
            labelsb[0] = labelb1;
            labelsb[1] = labelb2;
            labelsb[2] = labelb3;
            labelsb[3] = labelb4;
            labelsb[4] = labelb5;
            labelsb[5] = labelb6;
            labelsb[6] = labelb7;
            labelsb[7] = labelb8;
            labelsb[8] = labelb9;
            labelsb[9] = labelb10;
            labelsc[0] = labelc1;
            labelsc[1] = labelc2;
            labelsc[2] = labelc3;
            labelsc[3] = labelc4;
            labelsc[4] = labelc5;
            labelsc[5] = labelc6;
            labelsc[6] = labelc7;
            labelsc[7] = labelc8;
            labelsc[8] = labelc9;
            labelsc[9] = labelc10;
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
            TextBoxesa[0] = textBoxa1;
            TextBoxesa[1] = textBoxa2;
            TextBoxesa[2] = textBoxa3;
            TextBoxesa[3] = textBoxa4;
            TextBoxesa[4] = textBoxa5;
            TextBoxesa[5] = textBoxa6;
            TextBoxesa[6] = textBoxa7;
            TextBoxesa[7] = textBoxa8;
            TextBoxesa[8] = textBoxa9;
            TextBoxesa[9] = textBoxa10;
            TextBoxesb[0] = textBoxb1;
            TextBoxesb[1] = textBoxb2;
            TextBoxesb[2] = textBoxb3;
            TextBoxesb[3] = textBoxb4;
            TextBoxesb[4] = textBoxb5;
            TextBoxesb[5] = textBoxb6;
            TextBoxesb[6] = textBoxb7;
            TextBoxesb[7] = textBoxb8;
            TextBoxesb[8] = textBoxb9;
            TextBoxesb[9] = textBoxb10;
            TextBoxesc[0] = textBoxc1;
            TextBoxesc[1] = textBoxc2;
            TextBoxesc[2] = textBoxc3;
            TextBoxesc[3] = textBoxc4;
            TextBoxesc[4] = textBoxc5;
            TextBoxesc[5] = textBoxc6;
            TextBoxesc[6] = textBoxc7;
            TextBoxesc[7] = textBoxc8;
            TextBoxesc[8] = textBoxc9;
            TextBoxesc[9] = textBoxc10;
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
            ComboBoxes[0] = comboBox1;
            ComboBoxes[1] = comboBox2;
            ComboBoxes[2] = comboBox3;
            ComboBoxes[3] = comboBox4;
            ComboBoxes[4] = comboBox5;
            ComboBoxes[5] = comboBox6;
            ComboBoxes[6] = comboBox7;
            ComboBoxes[7] = comboBox8;
            ComboBoxes[8] = comboBox9;
            ComboBoxes[9] = comboBox10;
            ComboBoxesRW[0] = comboBoxRW1;
            ComboBoxesRW[1] = comboBoxRW2;
            ComboBoxesRW[2] = comboBoxRW3;
            ComboBoxesRW[3] = comboBoxRW4;
            ComboBoxesRW[4] = comboBoxRW5;
            ComboBoxesRW[5] = comboBoxRW6;
            ComboBoxesRW[6] = comboBoxRW7;
            ComboBoxesRW[7] = comboBoxRW8;
            ComboBoxesRW[8] = comboBoxRW9;
            ComboBoxesRW[9] = comboBoxRW10;
            this.TitleName = TitleName;
            this.TheoryReference = TheoryReference;
			// Insert code required on object creation below this point.
		}
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            String name = (sender as Button).Name;
            name = name.Substring(6);
            int index = Convert.ToInt32(name) - 1;
            Canvdes[index].Visibility = Visibility.Visible;
            edit = true;
            right.RemoveAt(index);
            ekfonish.RemoveAt(index);
            a.RemoveAt(index);
            b.RemoveAt(index);
            c.RemoveAt(index);
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (first >= 10)
            {
                Console.WriteLine("mphke");
                String name = (sender as ComboBox).Name;
                Console.WriteLine(name);
                name = name.Substring(8);
                Console.WriteLine(name);
                int index = Convert.ToInt32(name) - 1;
                Console.WriteLine(index);
                Canvdes[index].Visibility = Visibility.Visible;
                for (int i = 0; i < ComboBoxes.Length; i++)
                {
                    if (i != index)
                    {
                        ComboBoxes[i].IsEnabled = false;
                    }
                }
                if ((sender as ComboBox).SelectedIndex == 1)
                {
                    labelsa[index].Visibility = Visibility.Visible;
                    labelsb[index].Visibility = Visibility.Visible;
                    labelsc[index].Visibility = Visibility.Visible;
                    TextBoxesa[index].Visibility = Visibility.Visible;
                    TextBoxesb[index].Visibility = Visibility.Visible;
                    TextBoxesc[index].Visibility = Visibility.Visible;
                    ComboBoxesRW[index].Visibility = Visibility.Hidden;
                }
                else if ((sender as ComboBox).SelectedIndex == 2)
                {
                    ComboBoxesRW[index].Visibility = Visibility.Visible;
                    TextBoxesA[index].Visibility = Visibility.Hidden;
                    labelsa[index].Visibility = Visibility.Hidden;
                    TextBoxesa[index].Visibility = Visibility.Hidden;
                    labelsb[index].Visibility = Visibility.Hidden;
                    labelsc[index].Visibility = Visibility.Hidden;
                    TextBoxesb[index].Visibility = Visibility.Hidden;
                    TextBoxesc[index].Visibility = Visibility.Hidden;
                }
                else if ((sender as ComboBox).SelectedIndex == 3)
                {
                    ComboBoxesRW[index].Visibility = Visibility.Hidden;
                    labelsa[index].Visibility = Visibility.Hidden;
                    labelsb[index].Visibility = Visibility.Hidden;
                    labelsc[index].Visibility = Visibility.Hidden;
                    TextBoxesa[index].Visibility = Visibility.Hidden;
                    TextBoxesb[index].Visibility = Visibility.Hidden;
                    TextBoxesc[index].Visibility = Visibility.Hidden;
                }
                else if ((sender as ComboBox).SelectedIndex == 0)
                {
                    Canvdes[index].Visibility = Visibility.Hidden;
                    for (int i = 0; i < ComboBoxes.Length; i++)
                    {
                        if (ComboBoxes[i].SelectedIndex == 0)
                        {
                            ComboBoxes[i].IsEnabled = true;
                        }
                    }
                }
            }
            first++;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            if (numberofCanvas < 9)
            {
                numberofCanvas++;
                Canvadesg[numberofCanvas].Visibility = Visibility.Visible;
                button11.IsEnabled = false;
                ComboBoxes[numberofCanvas].IsEnabled = true;
            }
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            if (numberofCanvas > 0)
            {
                Canvadesg[numberofCanvas].Visibility = Visibility.Hidden;
                TextBoxesQ[numberofCanvas].Text = "";
                TextBoxesA[numberofCanvas].Text = "";
                TextBoxesa[numberofCanvas].Text = "";
                TextBoxesb[numberofCanvas].Text = "";
                TextBoxesc[numberofCanvas].Text = "";
                ComboBoxes[numberofCanvas].SelectedIndex = 0;
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
                    if (ComboBoxes[i].IsEnabled == false && ComboBoxes[i].SelectedIndex != 0)
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

        private void buttonSaves_Click(object sender, RoutedEventArgs e)
        {

            String name = (sender as Button).Name;
            name = name.Substring(7);
            int index = Convert.ToInt32(name) - 1;
            if (ComboBoxes[index].SelectedIndex != 2 || ComboBoxesRW[index].SelectedIndex != 0) //Ελέγχουμε αν έχει επιλεχθεί απάντηση στο Σωστό ή Λάθος 
            {
                ComboBoxes[index].IsEnabled = false;
                Buttons[index].IsEnabled = true;
                if (edit == false)
                {
                    button11.IsEnabled = true;
                }
                Canvdes[index].Visibility = Visibility.Hidden;
                edit = false;
                if (ComboBoxes[index].SelectedIndex == 2)
                {
                    right.Insert(index, ComboBoxesRW[index].Text);
                    if (ComboBoxesRW[index].Text == "Σωστό")
                    {
                        a.Insert(index, "Λάθος");
                    }
                    else
                    {
                        a.Insert(index, "Σωστό");
                    }
                    b.Insert(index, TextBoxesb[index].Text);
                    c.Insert(index, TextBoxesc[index].Text);
                }
                else
                {
                    right.Insert(index, TextBoxesA[index].Text);
                    a.Insert(index, TextBoxesa[index].Text);
                    b.Insert(index, TextBoxesb[index].Text);
                    c.Insert(index, TextBoxesc[index].Text);
                }
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
                        using (OdbcCommand cmd = new OdbcCommand("INSERT INTO test" + "(question_number,test_name,test_type,test_question,test_answer,test_choice1,test_choice2,test_choice3,TheoryReference) VALUES (?,?,?,?,?,?,?,?,?)", connection))
                        {

                            cmd.Parameters.Add("@question_number", OdbcType.Int,
                                255).Value = i + 1;
                            Console.WriteLine(i);
                            cmd.Parameters.Add("@test_name", OdbcType.VarChar,
                                255).Value = TitleName;
                            cmd.Parameters.Add("@test_type", OdbcType.VarChar,
                                255).Value = ComboBoxes[i].Text;
                            Console.WriteLine(ComboBoxes[i].Text);
                            cmd.Parameters.Add("@test_question", OdbcType.VarChar,
                                255).Value = ekfonish[i];
                            Console.WriteLine(ekfonish[i]);
                            cmd.Parameters.Add("@test_answer", OdbcType.VarChar,
                               255).Value = right[i];
                            Console.WriteLine(right[i]);
                            cmd.Parameters.Add("@test_choice1", OdbcType.VarChar,
                                255).Value = a[i];
                            Console.WriteLine(a[i]);
                            cmd.Parameters.Add("@test_choice2", OdbcType.VarChar,
                                255).Value = b[i];
                            Console.WriteLine(b[i]);
                            cmd.Parameters.Add("@test_choice3", OdbcType.VarChar,
                                255).Value = c[i];
                            Console.WriteLine(c[i]);
                            cmd.Parameters.Add("@TheoryReference", OdbcType.VarChar,
                                255).Value = TheoryReference;
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
	}
}