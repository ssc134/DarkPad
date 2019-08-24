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
        private Color currFontColor = Color.FromArgb(255, 255, 255);
        private Color currBackColor = Color.FromArgb(40, 40, 40);
        private Font currFont = DarkPad.DefaultFont;
        private bool isStatusStripVisible = true;

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

        //does'nt properly work
        //make it undo a word at a time instead of whole sentence.
        //Add redo option and a keyboard shortcut for it in the next release.
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
            string datetime = DateTime.Now.ToString();
            int currPos = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, datetime);
            richTextBox1.SelectionStart = currPos + datetime.Length;
        }



        #endregion


        #region Format

        //this method needs reimplementing
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() != DialogResult.Cancel)
                currFont = fd.Font;
            richTextBox1.Font = currFont;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.Cancel)
                currFontColor = cd.Color;
            richTextBox1.ForeColor = currFontColor;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.Cancel)
                currBackColor = cd.Color;
            richTextBox1.BackColor = currBackColor;
        }




        #endregion


        #region View

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor += 0.05F;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor -= 0.05F;
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1.0F;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isStatusStripVisible)
            {
                statusBarToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
                isStatusStripVisible = false;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = true;
                statusStrip1.Visible = true;
                isStatusStripVisible = true;
            }
        }

        #endregion

        #region Help

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature in progress😅", "Oh snap!!", MessageBoxButtons.OK);
        }

        private void aboutDarkPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A simple alternative to Windows Notepad with a Dark Theme", "DarkPad v0.5 Beta", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        #endregion


    }
}
