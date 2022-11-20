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

        private void button1_Click(object sender, EventArgs e)
        {
            view_model.SendToServer(list_result_statistics);
        }
    }
}
