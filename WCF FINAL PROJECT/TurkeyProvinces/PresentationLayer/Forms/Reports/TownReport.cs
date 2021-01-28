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
    public partial class TownReport : Form
    {
        public TownReport()
        {
            InitializeComponent();
        }

        private void TownReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'turkeyProvincesDataSet1.Town' table. You can move, or remove it, as needed.
            this.townTableAdapter.Fill(this.turkeyProvincesDataSet1.Town);

            this.reportTown.RefreshReport();
        }
    }
}
