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
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        private void button1_Click(object sender, EventArgs e)
        {
            folderDialog.ShowDialog();
            explore1.Enabled = true;

            if (folderDialog.SelectedPath.Length > 0 && deepSearch.Checked == false)
            {
                files1 = Directory.GetFiles(folderDialog.SelectedPath);
                label3.Text = files1.Length.ToString() + " File(s) Found in Folder 1";
                textBox1.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }
            else if (folderDialog.SelectedPath.Length > 0 && deepSearch.Checked == true)
            {
                files1 = Directory.GetFiles(folderDialog.SelectedPath, "*", SearchOption.AllDirectories);
                label3.Text = files1.Length.ToString() + " File(s) Found in Folder 1";
                textBox1.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            explore2.Enabled = true;

            if (folderDialog.SelectedPath.Length > 0 && deepSearch.Checked == false)
            {

                files2 = Directory.GetFiles(folderDialog.SelectedPath);
                label4.Text = files2.Length.ToString() + " File(s) Found in Folder 2";
                textBox2.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }
            else if (folderDialog.SelectedPath.Length > 0 && deepSearch.Checked == true)
            {
                files2 = Directory.GetFiles(folderDialog.SelectedPath,  "*", SearchOption.AllDirectories);
                label4.Text = files2.Length.ToString() + " File(s) Found in Folder 2";
                textBox2.Text = folderDialog.SelectedPath;
                button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            filesList1 = new List<string>();
            filesList2 = new List<string>();

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void deepSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (deepSearch.Checked == true)
            {
                deepSearch.Text = "Deep Search Enabled";
                deepSearch.ForeColor = Color.Green;
                if (textBox1.Text.Length > 0)
                {
                    files1 = Directory.GetFiles(textBox1.Text, "*", SearchOption.AllDirectories);
                    label3.Text = files1.Length.ToString() + " File(s) Found in Folder 1";
                }
                if (textBox2.Text.Length > 0)
                {
                    files2 = Directory.GetFiles(textBox2.Text, "*", SearchOption.AllDirectories);
                    label4.Text = files2.Length.ToString() + " File(s) Found in Folder 2";
                    button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
                }
            }
               
            else if (deepSearch.Checked == false)
            {
                deepSearch.Text = "Deep Search Disabled";
                deepSearch.ForeColor = Color.Red;
                if (textBox1.Text.Length > 0)
                {
                    files1 = Directory.GetFiles(textBox1.Text);
                    label3.Text = files1.Length.ToString() + " File(s) Found in Folder 1";
                }
                if (textBox2.Text.Length > 0)
                {
                    files2 = Directory.GetFiles(textBox2.Text);
                    label4.Text = files2.Length.ToString() + " File(s) Found in Folder 2";
                    button3.Enabled = textBox1.Text.Length > 0 && textBox2.Text.Length > 0;
                }
            }
        }

        private void explore1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);
        }

        private void explore2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2.Text);
        }
    }
}
