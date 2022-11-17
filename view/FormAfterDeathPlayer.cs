using System;
using System.Windows.Forms;

namespace Game_Kursak.view
{
    public partial class FormAfterDeathPlayer : Form
    {
        public string Btn = "";
        public string NickNameOfPlayer = "";

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
            Btn = "save";
            NickNameOfPlayer = textBox_nickName.Text;
            this.Close();
        }
    }
}
