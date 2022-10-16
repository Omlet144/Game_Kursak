using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Kursak.view
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button_company_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Game formGame = new Form_Game();
            formGame.Show();
        }

        private void button_Survival_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Game formGame = new Form_Game();
            formGame.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
