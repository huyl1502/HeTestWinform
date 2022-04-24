using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();

            var patient1 = new Models.Patient { Name = "Le Quang Huy", Age = 22 };
            var patient2 = new Models.Patient { Name = "Nguyen Thi Hien", Age = 22 };
            var lstPatient = new List<Models.Patient>();
            lstPatient.Add(patient1);
            lstPatient.Add(patient2);

            var lstView = new Views.MyListView<Models.Patient>(lstPatient);
            lstView.Width = panel4.Width;
            lstView.Height = panel4.Height;

            panel4.Controls.Add(lstView);
        }

        private void App_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
