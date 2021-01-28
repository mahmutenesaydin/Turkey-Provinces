using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Reports
{
    public partial class VillageReport : Form
    {
        public VillageReport()
        {
            InitializeComponent();
        }

        private void VillageReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'turkeyProvincesDataSet2.Village' table. You can move, or remove it, as needed.
            this.villageTableAdapter.Fill(this.turkeyProvincesDataSet2.Village);

            this.reportViewer1.RefreshReport();
        }
    }
}
