using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapleStory_SaveEditor
{
    public partial class SaveEditor : Form
    {
        public SaveEditor()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            string path = null;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }

            textBox1.Text = "";

            if (path != null)
            {
                if (File.Exists(path + "\\playerData.dat"))
                {
                    BinaryReader character = new BinaryReader(File.OpenRead(path + "\\playerData.dat"));
                    numericUpDown1.Value = character.ReadChar();
                    character.BaseStream.Position = 0x04;
                    numericUpDown2.Value = character.ReadInt32();
                    character.Dispose();
                }

                if (File.Exists(path + "\\summary_1.dat"))
                {
                    BinaryReader summary = new BinaryReader(File.OpenRead(path + "\\summary_1.dat"));
                    summary.BaseStream.Position = 0x0C;
                    char check = summary.ReadChar();

                    if (check == 0x0) //Because my savefile contained a 0x6B on 0x0E. Name is 8 chars every second byte is 00
                    {
                        summary.BaseStream.Position = 0x0;
                        foreach (char myChar in summary.ReadChars(0xB)) textBox1.Text += myChar;
                    }
                    else
                    {
                        summary.BaseStream.Position = 0x0;
                        foreach (char myChar in summary.ReadChars(0xF)) textBox1.Text += myChar;
                    }

                }
                else if (File.Exists(path + "\\summary_2.dat"))
                {
                    BinaryReader summary = new BinaryReader(File.OpenRead(path + "\\summary_2.dat"));
                    summary.BaseStream.Position = 0x0C;
                    char check = summary.ReadChar();
                    if (check == 0x0)
                    {
                        summary.BaseStream.Position = 0x0;
                        foreach (char myChar in summary.ReadChars(0xB)) textBox1.Text += myChar;

                    }
                    else
                    {
                        summary.BaseStream.Position = 0x0;
                        foreach (char myChar in summary.ReadChars(0xF)) textBox1.Text += myChar;

                    }
                }
                else
                {
                    MessageBox.Show("Can't find savefiles!");
                }


            }

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Maplestory Savegame Editor  Copyright (C) 2016  Flyingsky\n\nThis program comes with ABSOLUTELY NO WARRANTY. This is free software, and you are welcome to redistribute it under certain conditions; see license.md for more information", "Credits");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}