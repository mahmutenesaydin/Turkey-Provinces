using BusinessLayer.UnitOfWork;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
    public partial class PieCharts : Form
    {
        public PieCharts()
        {
            InitializeComponent();


            TownBusiness townBus = new TownBusiness();
            VillageBusiness vilBus = new VillageBusiness();


            pieChtTownByCity.InnerRadius = 100;
            pieChtTownByCity.LegendLocation = LiveCharts.LegendLocation.Right;
            SeriesCollection series = new SeriesCollection();
            foreach (var t in townBus.TownByCity())
            {
                series.Add(new PieSeries
                {
                    Title = t.TownName,
                    Values = new ChartValues<int> { (int)t.City},
                    DataLabels = true
                });
            }
            pieChtTownByCity.Series = series;

            /*--------*/

            pieChtVillageByTown.InnerRadius = 100;
            pieChtVillageByTown.LegendLocation = LiveCharts.LegendLocation.Right;
            SeriesCollection series2 = new SeriesCollection();
            foreach (var v in vilBus.VillageByTown())
            {
                series2.Add(new PieSeries
                {
                    Title = v.VillageName,
                    Values = new ChartValues<int> { (int)v.Town},
                    DataLabels = true
                });
            }
            pieChtVillageByTown.Series = series2;
        }
    }
}
