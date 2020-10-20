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
        private bool isStatusStripVisible = false;
        private bool isMouseHovered = false;
        private bool isFileLabelClicked = false;

        public DarkPad()
        {
            InitializeComponent();
        }
        public DarkPad(string path)
        {
            InitializeComponent();
            richTextBox1.Text = System.IO.File.ReadAllText(path);
        }
            

        #region Click
  
        #region File

        private void fileLabel_Click(object sender, EventArgs e)
        {
            isMouseHovered = true;
 //           fileLabel.BackColor = Color.FromArgb(45, 45, 45);
//            fileLabel.ForeColor = Color.White;
 //           fileLabel.DropDown.BackColor = Color.FromArgb(55, 55, 55);
//            fileLabel.DropDown.ForeColor = Color.White;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DarkPad newInstance = new DarkPad();
            newInstance.Show();
            isMouseHovered = false;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //            String cmd = @"/C C:\Users\JELLAX\source\repos\ssc134\DarkPad\bin\Debug\DarkPad.exe";
            //            System.Diagnostics.Process.Start("CMD.exe", cmd);
            System.Diagnostics.Process.Start(@"C:\Users\JELLAX\source\repos\ssc134\DarkPad\bin\Debug\DarkPad.exe");
            isMouseHovered = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string filepath = dialog.FileName;
            if(filepath.Length != 0)
                richTextBox1.Text = System.IO.File.ReadAllText(filepath);
            isMouseHovered = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSaved == false)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Files(*.txt)|*.txt";
                dlg.ShowDialog();
                currentFilePath = dlg.FileName;
                if (currentFilePath.Length == 0)
                    return;
                isSaved = true;
            }
        
            System.IO.File.WriteAllText(currentFilePath, richTextBox1.Text);
            isMouseHovered = false;
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
                if (currentFilePath.Length == 0)
                    return;
                isSaved = true;
            }
            System.IO.File.WriteAllText(filePath, richTextBox1.Text);
            isMouseHovered = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region Edit

        private void editLabel_Click(object sender, EventArgs e)
        {
            isMouseHovered = true;
        }

        //does'nt properly work
        //make it undo a word at a time instead of whole sentence.
        //Add redo option and a keyboard shortcut for it in the next release.
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            isMouseHovered = false;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            isMouseHovered = false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            isMouseHovered = false;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            isMouseHovered = false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
            isMouseHovered = false;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature still in progress", "Snap!", MessageBoxButtons.OK);
            isMouseHovered = false;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^a");
            isMouseHovered = false;
        }

        private void insertDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string datetime = DateTime.Now.ToString();
            int currPos = richTextBox1.SelectionStart;
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, datetime);
            richTextBox1.SelectionStart = currPos + datetime.Length;
            isMouseHovered = false;
        }



        #endregion


        #region Format

        private void formatLabel_Click(object sender, EventArgs e)
        {
            isMouseHovered = true;
        }

        //this method needs reimplementing
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() != DialogResult.Cancel)
                currFont = fd.Font;
            richTextBox1.Font = currFont;
            isMouseHovered = false;
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.Cancel)
                currFontColor = cd.Color;
            richTextBox1.ForeColor = currFontColor;
            isMouseHovered = false;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.Cancel)
                currBackColor = cd.Color;
            richTextBox1.BackColor = currBackColor;
            isMouseHovered = false;
        }




        #endregion


        #region View

        private void viewLabel_Click(object sender, EventArgs e)
        {
            isMouseHovered = true;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor += 0.05F;
            isMouseHovered = false;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor -= 0.05F;
            isMouseHovered = false;
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1.0F;
            isMouseHovered = false;
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
            isMouseHovered = false;
        }

        #endregion


        #region Help

        private void helpLabel_Click(object sender, EventArgs e)
        {
            isMouseHovered = true;
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature in progress😅", "Oh snap!!", MessageBoxButtons.OK);
            isMouseHovered = false;
        }

        private void aboutDarkPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A simple alternative to Windows Notepad with a Dark Theme", "DarkPad v0.5 Beta", MessageBoxButtons.OK, MessageBoxIcon.Question);
            isMouseHovered = false;
        }

        #endregion

        #region RichtextBox1
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            isMouseHovered = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Length: " + richTextBox1.SelectionStart.ToString();
        }
        #endregion
        #endregion

        #region MouseHover
        private void fileLabel_MouseHover(object sender, EventArgs e)
        {
            if (isMouseHovered == true)
                fileLabel.ShowDropDown();
        }
        private void editLabel_MouseHover(object sender, EventArgs e)
        {
            if (isMouseHovered == true)
                editLabel.ShowDropDown();
        }
        private void formatLabel_MouseHover(object sender, EventArgs e)
        {
            if (isMouseHovered == true)
                formatLabel.ShowDropDown();
        }
        private void viewLabel_MouseHover(object sender, EventArgs e)
        {
            if (isMouseHovered == true)
                viewLabel.ShowDropDown();
        }
        private void helpLabel_MouseHover(object sender, EventArgs e)
        {
            if (isMouseHovered == true)
                helpLabel.ShowDropDown();
        }



        #endregion


        #region ButtonPress



        #endregion
    }
}
