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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form apt = new Apt();
            apt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form lek = new Lek();
            lek.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form nal = new Nal();
            nal.Show();
        }
    }
}
