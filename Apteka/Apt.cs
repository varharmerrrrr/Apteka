using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class Apt : Form
    {
        public Apt()
        {
            InitializeComponent();
            ShowItem();
        }

        void ShowItem()
        {
            listViewApteka.Items.Clear();
            foreach (Apteka apteka in Program.apteka.Apteka)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    apteka.Name, apteka.Adress,
                    apteka.Phone, apteka.Time
                });
                item.Tag = apteka;
                listViewApteka.Items.Add(item);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxAdress.Text == "" || textBoxPhone.Text == "" || textBoxTime.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Apteka apteka = new Apteka();
                apteka.Name = textBoxName.Text;
                apteka.Adress = textBoxAdress.Text;
                apteka.Phone = textBoxPhone.Text;
                apteka.Time = textBoxTime.Text;
                Program.apteka.Apteka.Add(apteka);
                Program.apteka.SaveChanges();
                Apt apt = new Apt();
                apt.Show();
                this.Hide();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            {
                if (listViewApteka.SelectedItems.Count == 1)
                {
                    Apteka apteka = listViewApteka.SelectedItems[0].Tag as Apteka;
                    apteka.Name = textBoxName.Text;
                    apteka.Adress = textBoxAdress.Text;
                    apteka.Phone = textBoxPhone.Text;
                    apteka.Time = textBoxTime.Text;
                    Program.apteka.SaveChanges();
                    Apt apt = new Apt();
                    apt.Show();
                    this.Hide();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewApteka.SelectedItems.Count == 1)
                {
                    Apteka apteka = listViewApteka.SelectedItems[0].Tag as Apteka;
                    Program.apteka.Apteka.Remove(apteka);
                    Program.apteka.SaveChanges();
                    Apt apt = new Apt();
                    apt.Show();
                    this.Hide();
                }
                textBoxName.Text = "";
                textBoxAdress.Text = "";
                textBoxPhone.Text = "";
                textBoxTime.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewApteka_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (listViewApteka.SelectedItems.Count == 1)
                {
                    Apteka apteka = listViewApteka.SelectedItems[0].Tag as Apteka;
                    textBoxName.Text = apteka.Name;
                    textBoxAdress.Text = apteka.Adress;
                    textBoxPhone.Text = apteka.Phone;
                    textBoxTime.Text = apteka.Time;
                }
                else
                {
                    textBoxName.Text = "";
                    textBoxAdress.Text = "";
                    textBoxPhone.Text = "";
                    textBoxTime.Text = "";
                }
            }
        }
    }
}
