using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GAui
{
    public partial class mainForm : Form
    {
        List<City> baseRoute;
        Series SP;
        Series SL;
        List<PointF> points;
        public mainForm()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            maxPopulationInput.Value = 1;
            mutationInput.Value = 1;
            indPerPopulationInput.Value = 1;
            baseRoute = new List<City>();
            //wspolrzedne miast - na oko z mapy
            baseRoute.Add(new City(1, 10, "Szczecin"));
            baseRoute.Add(new City(5, 7, "Poznan"));
            baseRoute.Add(new City(10, 1, "Krakow"));
            baseRoute.Add(new City(8, 3, "Czestochowa"));
            baseRoute.Add(new City(12, 7, "Warszawa"));
            baseRoute.Add(new City(2, 8, "Gorzow"));
            baseRoute.Add(new City(16, 10, "Bialystok"));
            baseRoute.Add(new City(5, 3, "Wroclaw"));
            baseRoute.Add(new City(7, 9, "Bydgoszcz"));
            baseRoute.Add(new City(9, 6, "Lodz"));
            baseRoute.Add(new City(15, 5, "Lublin"));
            baseRoute.Add(new City(14, 1, "Rzeszow"));
            baseRoute.Add(new City(9, 1, "Katowice"));
            baseRoute.Add(new City(1, 10, "Szczecin"));

            currentRouteChart.Series.Clear();
            currentRouteChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            currentRouteChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            // the series with all the points
            SP = currentRouteChart.Series.Add("SPoint");
            SP.IsVisibleInLegend = false;
            SP.ChartType = SeriesChartType.Point;
            // and the series with a few (visible) lines:
            SL = currentRouteChart.Series.Add("SLine");
            SL.ChartType = SeriesChartType.Line;
            SL.Color = Color.Black;
            SL.IsVisibleInLegend = false;
            points = new List<PointF>();  // charts actually uses double by default
            for (int i = 0; i < baseRoute.Count; i++)
                points.Add(new PointF(baseRoute[i].x, baseRoute[i].y));

            foreach (PointF pt in points) SP.Points.AddXY(pt.X, pt.Y);

            

        }

        private void simStart_Click(object sender, EventArgs e)
        {

            var subjectsPerPop = Decimal.ToInt32(indPerPopulationInput.Value);
            var maxPop = Decimal.ToInt32(maxPopulationInput.Value);
            var mutationRate = Decimal.ToDouble(mutationInput.Value) / 100.0;
            simStart.Enabled = false;
            maxPopulationInput.Enabled = false;
            mutationInput.Enabled = false;
            indPerPopulationInput.Enabled = false;
            clearButton.Enabled = false;
            GeneticSimulation geneticSimulation = new GeneticSimulation(baseRoute, maxPop, subjectsPerPop,mutationRate, currentRouteChart,points,this);
            
            //currentRouteChart.Series["SLine"].Points.Clear();


        }

        private void maxPopulationInput_ValueChanged(object sender, EventArgs e)
        {
            maxPopulationInput.Maximum = 100000;
            maxPopulationInput.Minimum = 1;
            /*
            if (maxPopulationInput.Value<1)
            {
                maxPopulationInput.Value = 1;
            }
            */
        }

        private void mutationInput_ValueChanged(object sender, EventArgs e)
        {
            mutationInput.Maximum = 100;
            maxPopulationInput.Minimum = 0;
        }

        private void indPerPopulationInput_ValueChanged(object sender, EventArgs e)
        {
            mutationInput.Maximum = 100;
            maxPopulationInput.Minimum = 1;
            /*
            if (indPerPopulationInput.Value<1)
            {
                indPerPopulationInput.Value = 1;
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentRouteChart.Series["SLine"].Points.Clear();
            bestSolution.Text = "";
            bestSolutionNum.Text = "";
        }


    }
}
