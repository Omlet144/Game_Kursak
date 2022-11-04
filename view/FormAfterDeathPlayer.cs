using Game_Kursak.model;
using Game_Kursak.view_model;
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
    public partial class FormAfterDeathPlayer : Form
    {
        public string Btn = "";
        
        public FormAfterDeathPlayer()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Btn = "menu";
            this.Close();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Btn = "restart";
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {

        }
    }
}
