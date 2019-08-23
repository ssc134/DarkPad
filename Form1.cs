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
    public partial class DarkPad : Form
    {
        private bool isSaved = false;
        private string currentFilePath;

        public DarkPad()
        {
            InitializeComponent();
        }


        #region File

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DarkPad newInstance = new DarkPad();
            newInstance.Show();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DarkPad newInstance = new DarkPad();
            newInstance.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string filepath = dialog.FileName;
            richTextBox1.Text = System.IO.File.ReadAllText(filepath);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSaved == false)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Files(*.txt)|*.txt";
                dlg.ShowDialog();
                currentFilePath = dlg.FileName;
                isSaved = true;
            }
        
            System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text FIles(*.txt)|*.txt";
            dlg.ShowDialog();
            string filePath = dlg.FileName;
            if(isSaved == false)
            {
                currentFilePath = filePath;
                isSaved = true;
            }
            System.IO.File.WriteAllText(filePath, richTextBox1.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region Edit

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature still in progress", "Snap!", MessageBoxButtons.OK);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^a");
        }

        private void insertDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTimeConverter dtc = new DateTimeConverter();
            string datetime = dtc.ConvertToString(DateTime.Now);

        }

        #endregion

    }
}
