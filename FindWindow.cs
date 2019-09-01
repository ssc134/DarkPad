using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkPad
{
    public partial class FindWindow : Form
    {
        public string text = "";
        public bool matchCase = true;

        public FindWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Textbox empty");
            }
            else
            {
                text = textBox1.Text;
                button2_Click(sender, e);
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //            Application.Exit();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            matchCase = !matchCase;
            return;
        }
    }
}
