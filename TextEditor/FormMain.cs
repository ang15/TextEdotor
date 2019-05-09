using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.BisnessLogic.Service;

namespace TextEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public void CheckMenuFontCharacterStyle()
        {
            if (richTextBox1.SelectionFont.Bold == true)
                boldToolStripMenuItem.Checked = true;
            else boldToolStripMenuItem.Checked = false;


            if (richTextBox1.SelectionFont.Italic == true)
                italicToolStripMenuItem.Checked = true;
            else italicToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Underline == true)
                underLineToolStripMenuItem.Checked = true;
            else underLineToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Strikeout == true)
                strikeoutToolStripMenuItem.Checked = true;
            else strikeoutToolStripMenuItem.Checked = false;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);

                }
                catch (ArgumentException ex)
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);

                }
                this.Text = openFileDialog1.FileName;

            }
        }
        private readonly IFileService _fileService = new FileService();

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                catch (ArgumentException ex)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);

                }
                this.Text = saveFileDialog1.FileName;
                
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void StyleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void RigthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                    newFontStyle = FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily,
                    currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }

        }
        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                CheckMenuFontCharacterStyle();
                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                    newFontStyle = FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily,
                    currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }
        private void UnderLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                CheckMenuFontCharacterStyle();
                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                    newFontStyle = FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily,
                    currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        private void StrikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                    newFontStyle = FontStyle.Strikeout;
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily,
                    currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
