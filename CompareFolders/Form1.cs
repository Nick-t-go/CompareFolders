using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CompareFolders
{
    public partial class Form1 : Form
    {

        private string[] files1;
        private string[] files2;
        private List<string> filesList1 = new List<string>();
        private List<string> filesList2 = new List<string>();

        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath.Length > 0)
            {
                //
                // The user selected a folder and pressed the OK button.
                // A message pops up and identifies the number of files found within that folder.
                //
                files1 = Directory.GetFiles(folderDialog.SelectedPath);
                MessageBox.Show("Files found: " + files1.Length.ToString(), "Message");
                textBox1.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath.Length > 0)
            {
                //
                // The user selected a folder and pressed the OK button.
                // A message pops up and identifies the number of files found within that folder.
                //
                files2 = Directory.GetFiles(folderDialog.SelectedPath);
                MessageBox.Show("Files found: " + files2.Length.ToString(), "Message");
                textBox2.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            foreach (string file in files1)
            {
                this.filesList1.Add(Path.GetFileNameWithoutExtension(file));
            }
            foreach (string file in files2)
            {
                this.filesList2.Add(Path.GetFileNameWithoutExtension(file));
            }
            IEnumerable<string> unique1 = filesList1.Except(filesList2);
            foreach(String file in unique1)
            {
                if (!listBox1.Items.Cast<string>().Contains(file))
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
            }

            IEnumerable<string> unique2 = filesList2.Except(filesList1);

            foreach(String file in unique2)
            {
                if (!listBox2.Items.Cast<string>().Contains(file))
                {
                    listBox2.Items.Add(Path.GetFileName(file));
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
