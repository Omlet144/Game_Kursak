using Game_Kursak.model;
using Game_Kursak.view_model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game_Kursak.view
{
    public partial class FormStatistics : Form
    {
        View_model view_model = new View_model();
        public List<SaveResult> list_result_statistics = new List<SaveResult>();
       

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void buttonRefrash_Click(object sender, EventArgs e)
        {
            button_Refresh.Enabled = false;
            view_model.SendToServer(list_result_statistics, dataGridView_network_results);
            view_model.OpenFromTxt2(dataGridView_network_results);
        }

        private void button_Back_to_Menu_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            view_model.OpenFromTxt(list_result_statistics, dataGridView_local_results);
            view_model.OpenFromTxt2(dataGridView_network_results);

        }
    }
}
