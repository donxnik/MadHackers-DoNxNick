﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace G15Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // იდეა 1.  იყოს ისეთი შესანახი სისტემა სადაც მოითხოვს პაროლის დამატებასაც
            // ანუ სპეცალური საწყობი სადაც შენ არ გჭირდება მითითება თუ საიდან უნდა ჩაწეროს ან საიდან უნდა ამოიღოს.
            // ან შესაძლებელია იყოს სკრიპტული 
              // და აიტვირტოს Githubze

            // იდეა 2. background  და font ების ფერების შეცვლის ფუნქციის დამატება. და ფონტების ზომის და სტილის შეცვლის ფუნქციაც
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quickDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //ინახავს დესკტოპზე თუმცა დროებით გადავდეთ C-ის რომელიღაც ფოლდერში რადგან ისე აკრძალულია
            StreamWriter str = new StreamWriter((new FileStream(@"C:\Csharp\G15Text.txt", FileMode.Create)));
            str.Write(richTextBox1.Text);
            str.Close();
            MessageBox.Show("File Have Been Sucessfuly Saved", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void quickDesktopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ვამოწმებთ თუ რამე გვიწერია ტექსტში გახხსნამდე გამოიტანოს გაფრთხილება შეინაოხს თუ არა ეს ტექსტი
            if(richTextBox1.TextLength>0)
            {
                MessageBox.Show("Save this text", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                
            }
            StreamReader str = new StreamReader((new FileStream(@"C:\Csharp\G15text.txt", FileMode.Open)));
            richTextBox1.Text = str.ReadLine();
            str.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.TextLength>0)
            {
                MessageBox.Show("Are You Sure To Quit?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
            }
            this.Close();
            
            
        }

        private void myComputerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "text files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            richTextBox1.LoadFile(myStream, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void myComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Title = "Save Text File";
            theDialog.Filter = "text files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                           
                            richTextBox1.SaveFile(myStream, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
