using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Константин Постукян 
 1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не
создана база данных, обращение к несуществующему вопросу, открытие слишком большого
файла и т.д.).
б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив
другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню «О программе» с информацией о программе (автор, версия,
авторские права и др.).
г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных
(элемент SaveFileDialog).
2. *Используя полученные знания и класс TrueFalse, разработать игру «Верю — не верю».*/
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
            saveFileDialog.Filter = "Xml файлы|*.xml|Все файлы|*.*";
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dataBase = new TrueOrFalse(openFileDialog.FileName);
                dataBase.Load();
                toolStripStatusLabel1.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                bindingSource.DataSource = dataBase;
                bindingSource.DataMember = "list";
                tbQuestions.DataBindings.Add("Text", bindingSource, "Text");
                checkBox1.DataBindings.Add("Checked", bindingSource, "TrueOrFalse");
                bindingNavigator1.BindingSource = bindingSource;
                
            }

            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Уверены?");
        }

        private void игратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
