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
    public partial class Form2 : Form
    {
        TrueOrFalse dataBase;
        int turn = 0;
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataBase = new TrueOrFalse(openFileDialog.FileName);
                dataBase.Load();
                turn = 0;
                label1.Text = dataBase.List[turn].Text;
                turn++;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (turn >= dataBase.List.Count)
            {
                MessageBox.Show("Закончилась база");
                return;
            }
            else
            {

                label1.Text = dataBase.List[turn].Text;
                if (!dataBase.List[turn].TrueOrFalse)
                { MessageBox.Show("Верно!"); }
                else { MessageBox.Show("Неверно!"); }
                turn++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turn >= dataBase.List.Count)
            {
                MessageBox.Show("Закончилась база");
                return;
            }
            else
            {

                label1.Text = dataBase.List[turn].Text;
                if (dataBase.List[turn].TrueOrFalse)
                { MessageBox.Show("Верно!"); }
                else { MessageBox.Show("Неверно!"); }
                turn++;
            }
        }
    }
}
