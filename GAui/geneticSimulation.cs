using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
namespace GAui 
{
    class GeneticSimulation
    {
        private List<List<City>> currentGeneration;
        private List<City> bestSolution;
        private int chromosomeLength;
        private int bestSolutionGenNum = 0;
        public int currentGenNum=0;
        private int maxGenNum = 0;
        Random rnd;
        double mutationRate;
        Chart chartLink;        //wykres z form - dynamiczne dodawanie linii
        List<PointF> points;
        List<Point> lines;
        mainForm formLink;
        public GeneticSimulation(List<City> baseRoute,int maxGenNum, int subjectsPerGen, double mutationRate,Chart chart,List<PointF> points,mainForm link)
        {
            createGen0(baseRoute, subjectsPerGen);
            this.maxGenNum = maxGenNum;
            chromosomeLength = currentGeneration[0].Count-1;//kazdy osobnik ma ten sam kariotyp
            List<double> routeLenghts = new List<double>(new double[currentGeneration.Count]);
            foreach (var individual in currentGeneration)    //licze w kontruktorze bestSolution by uniknac wyswietlania dwukrotnie generacji 0 w output
            {
                routeLenghts[currentGeneration.IndexOf(individual)] = calculateRouteLength(individual);
            }
            bestSolution = currentGeneration[routeLenghts.IndexOf(routeLenghts.Min())]; //lepiej tutaj przyrownac niz za kazdym razem sprawdzac czy istnieje w petli
            rnd = new Random();
            this.mutationRate = mutationRate;
            this.points = points;
            chartLink = chart;
            formLink = link;
            lines = new List<Point>();
            Thread thread = new Thread(simStart);
            thread.IsBackground = true;
            thread.Start();
        }
        private void createGen0(List<City> route,int subjectsPerGen)
        {
            Random rnd = new Random();
            List<List<City>> gen0 = new List<List<City>>();
            for (int i = 0; i < subjectsPerGen; i++)
            {
                int n = route.Count;
                List<City> tempRoute = new List<City>();
                tempRoute.AddRange(route);
                while (n > 2)
                {
                    n--;
                    int k = rnd.Next(n + 1);
                    City tempCity = tempRoute[k];
                    tempRoute[k] = tempRoute[n];
                    tempRoute[n] = tempCity;
                }
                tempRoute.Add(tempRoute[0]);
                gen0.Add(tempRoute);
            }
            currentGeneration = gen0;
        }
        private double calculateRouteLength(List<City> route)
        {
            double roadLength = 0;
            double routeLength = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                roadLength = Math.Sqrt(Math.Pow(route[i].x - route[i + 1].x, 2) + Math.Pow(route[i].y - route[i + 1].y, 2));
                routeLength = routeLength + roadLength;
            }
            return Math.Round(routeLength, 3);
        }
        private void displayRoute(List<City> route)
        {
            foreach (City town in route)
            {
                Console.Write(town.name + " ");
            }
            Console.WriteLine();
        }
        private void drawChart()
        {
            foreach (Point ln in lines)
            {
                int p0=0;
                int p1=0;
                chartLink.Invoke(new Action(() => p0=chartLink.Series["SLine"].Points.AddXY(points[ln.X].X, points[ln.X].Y)));
                chartLink.Invoke(new Action(() => p1=chartLink.Series["SLine"].Points.AddXY(points[ln.Y].X, points[ln.Y].Y)));
                chartLink.Invoke(new Action(() => chartLink.Series["SLine"].Points[p0].Color = Color.Transparent));
                chartLink.Invoke(new Action(() => chartLink.Series["SLine"].Points[p1].Color = Color.Black));

            }
        }
        private void seekBest()
        {

        }
        private void simStart()
        {
            var stopwatch = Stopwatch.StartNew();
            List<double> routeLenghts = new List<double>(new double[currentGeneration.Count]);
            double currentBestValue;
            double currentSecondBestValue;
            List<City> currentBest;
            List<City> currentSecondBest;
            while(currentGenNum!=maxGenNum)
            {
                foreach(var individual in currentGeneration)    //wyznaczam rodzicow
                {
                    routeLenghts[currentGeneration.IndexOf(individual)] = calculateRouteLength(individual); 
                }
                currentBestValue = routeLenghts.Min();
                if(calculateRouteLength(bestSolution)>currentBestValue)
                {
                    Thread.Sleep(500);
                    
                    bestSolution = currentGeneration[routeLenghts.IndexOf(currentBestValue)];
                    bestSolutionGenNum = currentGenNum;
                    lines.Clear();
                    chartLink.Invoke(new Action(() => chartLink.Series["SLine"].Points.Clear()));

                    for (int i = 0; i < bestSolution.Count-1; i++)    //wszystkie rozwiazania maja ta sama dlugosc 
                    {
                        PointF tempPoint = new PointF(bestSolution[i].x, bestSolution[i].y);
                        int pointIndex = points.IndexOf(tempPoint);
                        tempPoint = new PointF(bestSolution[i+1].x, bestSolution[i+1].y);
                        int nextIndex = points.IndexOf(tempPoint);
                        lines.Add(new Point(pointIndex, nextIndex));
                    }
                    
                    drawChart();
                    formLink.Invoke(new Action(() => formLink.bestSolution.Text = calculateRouteLength(bestSolution).ToString()));
                    formLink.Invoke(new Action(() => formLink.bestSolutionNum.Text = bestSolutionGenNum.ToString()));
                }
                int minValueIndex = routeLenghts.IndexOf(routeLenghts.Min());
                routeLenghts[minValueIndex] = routeLenghts.Max();    //zamieniam najmniejsza w najwieksza - uzyskam tak prosto druga najmniejsza
                currentSecondBestValue = routeLenghts.Min();
                routeLenghts[minValueIndex] = currentBestValue;
                currentBest = currentGeneration[routeLenghts.IndexOf(currentBestValue)];
                currentSecondBest = currentGeneration[routeLenghts.IndexOf(currentSecondBestValue)];
                for (int i=0;i<currentGeneration.Count;i++)
                {
                    currentGeneration[i] = Mate(currentBest, currentSecondBest);
                }
                
                currentGenNum++;
            }
            formLink.Invoke(new Action(() => formLink.simStart.Enabled = true));
            formLink.Invoke(new Action(() => formLink.maxPopulationInput.Enabled = true));
            formLink.Invoke(new Action(() => formLink.mutationInput.Enabled = true));
            formLink.Invoke(new Action(() => formLink.indPerPopulationInput.Enabled = true));
            formLink.Invoke(new Action(() => formLink.clearButton.Enabled = true));
            


        }
        public List<City> Mate(List<City> parent1,List<City> parent2)
        {
            //krzyzowanie polega na pobieraniu losowej ilosci genow z rodzica 1
            //brakujace geny dobieram z odpowiadajacych z rodzica 2
            //jesli dany gen juz istnieje w dziecku, dobieram index wyzej az do skutku (przy maksyalnym indexu sie zeruje)
            List<City> child = new List<City>(new City[chromosomeLength]); 
            int noFirstGenes = rnd.Next(1, chromosomeLength);
            List<int> genesFromParent1= new List<int>();
            List<int> genesFromParent2 = new List<int>();
            while (genesFromParent1.Count!=noFirstGenes)
            {
                int pickedGene=rnd.Next(chromosomeLength);
                if(genesFromParent1.Count>0)
                {
                    while (genesFromParent1.Contains(pickedGene))
                    {
                        pickedGene = rnd.Next(chromosomeLength);
                    }
                }
                genesFromParent1.Add(pickedGene);
                child[pickedGene] = parent1[pickedGene];    //przypisywanie genu z rodzica 1
            }
            for(int i=0;i<chromosomeLength;i++) //sprawdzam ktore geny w dziecku nie zostaly przydzielone
            {
                if(!genesFromParent1.Contains(i))
                {
                    genesFromParent2.Add(i);
                }
            }
            foreach(int gene in genesFromParent2)   //przydzielam geny z rodzica 2
            {
                int tempGeneIndex = gene;
                while(child.Contains(parent2[tempGeneIndex]))    //sprawdzam czy gen sie powtarza w dziecku
                {
                    tempGeneIndex = tempGeneIndex + 1;
                    if(tempGeneIndex==chromosomeLength)
                    {
                        tempGeneIndex = 0;
                    }
                }
                child[gene]=parent2[tempGeneIndex];
            }
            for(int i=0;i<child.Count;i++)
            {
                double chance = rnd.NextDouble();
                if(chance<mutationRate) //obsluga mutacji - mutacja obejmuje zmiane indexu genu z losowym innym genem
                {
                    int geneSwapIndex = rnd.Next(child.Count);
                    City tempGene = child[i];
                    child[i] = child[geneSwapIndex];
                    child[geneSwapIndex] = tempGene;
                }
            }
            child.Add(child[0]);
            return child; 
        }
    }
}
