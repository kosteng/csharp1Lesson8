using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLesson8
{
    public partial class Form1 : Form
    {
        TrueOrFalse dataBase;
        BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            label1.DataBindings.Add("Text", trackBar1, "Value");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml файлы | */.xml | Все файлы | *.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataBase = new TrueOrFalse(saveFileDialog.FileName);
                toolStripStatusLabel1.Text = System.IO.Path.GetFileName(saveFileDialog.FileName);
                bindingSource.DataSource = dataBase;
                bindingSource.DataMember = "list";
                tbQuestions.DataBindings.Add("Text", bindingSource, "Text");
                checkBox1.DataBindings.Add("Checked", bindingSource, "TrueOrFalse");
                bindingNavigator1.BindingSource = bindingSource;
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            dataBase?.Save();
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            //dataBase.Load();
        }
    }
}
