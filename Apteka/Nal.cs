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
    public partial class Nal : Form
    {
        public Nal()
        {
            InitializeComponent();
            ShowItem();
            ShowApteka();
            ShowLekarstvo();
        }
        void ShowItem()
        {
            listViewNal.Items.Clear();
            foreach (Nalichie nalichie in Program.apteka.Nalichie)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    nalichie.IdApteka.ToString(), nalichie.IdLekarstvo.ToString(),
                    nalichie.Count, nalichie.Price
                });
                item.Tag = nalichie;
                listViewNal.Items.Add(item);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxApteka.Text == "" || comboBoxLekarstvo.Text == "" || textBoxCount.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Nalichie nalichie = new Nalichie();
                nalichie.Count = textBoxCount.Text;
                nalichie.Price = textBoxPrice.Text;
                nalichie.IdApteka = Convert.ToInt32(comboBoxApteka.SelectedItem.ToString().Split('.')[0]);
                nalichie.IdLekarstvo = Convert.ToInt32(comboBoxLekarstvo.SelectedItem.ToString().Split('.')[0]);
                Program.apteka.Nalichie.Add(nalichie);
                Program.apteka.SaveChanges();
                Nal nal = new Nal();
                nal.Show();
                this.Hide();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            {
                if (listViewNal.SelectedItems.Count == 1)
                {
                    Nalichie nalichie = listViewNal.SelectedItems[0].Tag as Nalichie;
                    nalichie.IdApteka = comboBoxApteka.SelectedItem.ToString()[0];
                    nalichie.IdLekarstvo = comboBoxLekarstvo.SelectedItem.ToString()[0];
                    nalichie.Count = textBoxCount.Text;
                    nalichie.Price = textBoxPrice.Text;
                    Program.apteka.SaveChanges();
                    Nal nal = new Nal();
                    nal.Show();
                    this.Hide();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewNal.SelectedItems.Count == 1)
                {
                    Nalichie nalichie = listViewNal.SelectedItems[0].Tag as Nalichie;
                    Program.apteka.Nalichie.Remove(nalichie);
                    Program.apteka.SaveChanges();
                    Nal nal = new Nal();
                    nal.Show();
                    this.Hide();
                }
                comboBoxApteka.SelectedItem = null;
                comboBoxLekarstvo.SelectedItem = null;
                textBoxCount.Text = "";
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewNal_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (listViewNal.SelectedItems.Count == 1)
                {
                    Nalichie nalichie = listViewNal.SelectedItems[0].Tag as Nalichie;
                    comboBoxApteka.SelectedItem = nalichie.IdApteka;
                    comboBoxLekarstvo.SelectedItem = nalichie.IdLekarstvo;
                    textBoxCount.Text = nalichie.Count;
                    textBoxPrice.Text = nalichie.Price;
                }
                else
                {
                    comboBoxApteka.SelectedItem = null;
                    comboBoxLekarstvo.SelectedItem = null;
                    textBoxCount.Text = "";
                    textBoxPrice.Text = "";
                }
            }
        }
        void ShowApteka()
        {
            comboBoxApteka.Items.Clear();
            foreach (Apteka apteka in Program.apteka.Apteka)
            {
                string[] item = { apteka.Name.ToString() };
                comboBoxApteka.Items.Add(string.Join(" ", item));
            }
        }
        void ShowLekarstvo()
        {
            comboBoxLekarstvo.Items.Clear();
            foreach (Lekarstvo lekarstvo in Program.apteka.Lekarstvo)
            {
                string[] item = { lekarstvo.Name.ToString() };
                comboBoxLekarstvo.Items.Add(string.Join(" ", item));
            }
        }
    }
}
