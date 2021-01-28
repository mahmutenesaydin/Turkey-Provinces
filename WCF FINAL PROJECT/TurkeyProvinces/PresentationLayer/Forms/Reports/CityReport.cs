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
    public partial class CityReport : Form
    {
        public CityReport()
        {
            InitializeComponent();
        }

        private void CityReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'turkeyProvincesDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.turkeyProvincesDataSet.City);

            this.reportCity.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
