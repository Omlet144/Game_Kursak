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
    public partial class FormStatistics : Form
    {
        View_model view_model = new View_model();

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view_model.SendToServer();
        }
    }
}
