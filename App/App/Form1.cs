using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My \nprogs", "About");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            count++;
            label1.Text = count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            count=0;
            label1.Text = Convert.ToString(count);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            count--;
            label1.Text = count.ToString();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value)+1);
            lblRandom.Text = n.ToString();
            if (cbRandom.Checked)
            {
                while (tbRandom.Text.IndexOf(n.ToString()) != -1)
                n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
                tbRandom.AppendText(n + "\n");
            }
            else tbRandom.AppendText(n + "\n");
        }

        private void lblRandom_Click(object sender, EventArgs e)
        {

        }

        private void tbRandom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
