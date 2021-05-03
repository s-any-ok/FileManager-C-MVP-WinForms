using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            btnOpen.Click += BtnOpen_Click;
            btnSave.Click += BtnSave_Click;
            fldText.TextChanged += FldText_TextChanged;
            btnSelect.Click += BtnSelect_Click;
            numFont.ValueChanged += NumFont_ValueChanged;
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            fldText.Font = new Font("Calibri", (float)numFont.Value);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fildFilePath.Text = ofd.FileName;
                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }

        private void FldText_TextChanged(object sender, EventArgs e)
        {
            if (ChangeContent != null) ChangeContent(this, EventArgs.Empty);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }

        public string FilePath { get { return fildFilePath.Text; } }
        public string Content { get { return fldText.Text; } set { fldText.Text = value;  } }
        public void SetSymbolCount(int count)
        {
            lblSymbolsCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ChangeContent;
       
    }
}