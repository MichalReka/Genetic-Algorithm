namespace GAui
{
    partial class mainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.indPerPopulationInput = new System.Windows.Forms.NumericUpDown();
            this.mutationInput = new System.Windows.Forms.NumericUpDown();
            this.maxPopulationInput = new System.Windows.Forms.NumericUpDown();
            this.simStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentRouteChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bestSolution = new System.Windows.Forms.Label();
            this.bestSolutionNum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indPerPopulationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPopulationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentRouteChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.indPerPopulationInput);
            this.groupBox1.Controls.Add(this.mutationInput);
            this.groupBox1.Controls.Add(this.maxPopulationInput);
            this.groupBox1.Controls.Add(this.simStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane wejsciowe";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(148, 195);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(130, 29);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // indPerPopulationInput
            // 
            this.indPerPopulationInput.Location = new System.Drawing.Point(117, 146);
            this.indPerPopulationInput.Name = "indPerPopulationInput";
            this.indPerPopulationInput.Size = new System.Drawing.Size(167, 22);
            this.indPerPopulationInput.TabIndex = 9;
            this.indPerPopulationInput.ValueChanged += new System.EventHandler(this.indPerPopulationInput_ValueChanged);
            // 
            // mutationInput
            // 
            this.mutationInput.Location = new System.Drawing.Point(117, 102);
            this.mutationInput.Name = "mutationInput";
            this.mutationInput.Size = new System.Drawing.Size(167, 22);
            this.mutationInput.TabIndex = 8;
            this.mutationInput.ValueChanged += new System.EventHandler(this.mutationInput_ValueChanged);
            // 
            // maxPopulationInput
            // 
            this.maxPopulationInput.Location = new System.Drawing.Point(117, 64);
            this.maxPopulationInput.Name = "maxPopulationInput";
            this.maxPopulationInput.Size = new System.Drawing.Size(167, 22);
            this.maxPopulationInput.TabIndex = 7;
            this.maxPopulationInput.ValueChanged += new System.EventHandler(this.maxPopulationInput_ValueChanged);
            // 
            // simStart
            // 
            this.simStart.Location = new System.Drawing.Point(9, 195);
            this.simStart.Name = "simStart";
            this.simStart.Size = new System.Drawing.Size(130, 29);
            this.simStart.TabIndex = 6;
            this.simStart.Text = "START";
            this.simStart.UseVisualStyleBackColor = true;
            this.simStart.Click += new System.EventHandler(this.simStart_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 53);
            this.label3.TabIndex = 2;
            this.label3.Text = "Liczba osobnikow w populacji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Procent mutacji";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max. ilosc populacji";
            // 
            // currentRouteChart
            // 
            chartArea1.Name = "ChartArea1";
            this.currentRouteChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.currentRouteChart.Legends.Add(legend1);
            this.currentRouteChart.Location = new System.Drawing.Point(302, 12);
            this.currentRouteChart.Name = "currentRouteChart";
            this.currentRouteChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.currentRouteChart.Series.Add(series1);
            this.currentRouteChart.Size = new System.Drawing.Size(486, 426);
            this.currentRouteChart.TabIndex = 1;
            this.currentRouteChart.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bestSolution);
            this.groupBox2.Controls.Add(this.bestSolutionNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 178);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rozwiazanie";
            // 
            // bestSolution
            // 
            this.bestSolution.AutoSize = true;
            this.bestSolution.Location = new System.Drawing.Point(197, 127);
            this.bestSolution.Name = "bestSolution";
            this.bestSolution.Size = new System.Drawing.Size(0, 17);
            this.bestSolution.TabIndex = 14;
            // 
            // bestSolutionNum
            // 
            this.bestSolutionNum.AutoSize = true;
            this.bestSolutionNum.Location = new System.Drawing.Point(197, 54);
            this.bestSolutionNum.Name = "bestSolutionNum";
            this.bestSolutionNum.Size = new System.Drawing.Size(0, 17);
            this.bestSolutionNum.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 55);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dlugosc drogi w najlepszym rozwiazaniu";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 56);
            this.label4.TabIndex = 11;
            this.label4.Text = "Numer generacji z najlepszym rozwiazaniem";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.currentRouteChart);
            this.Controls.Add(this.groupBox1);
            this.Name = "mainForm";
            this.Text = "Algorytm genetyczy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indPerPopulationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPopulationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentRouteChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button simStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart currentRouteChart;
        public System.Windows.Forms.NumericUpDown indPerPopulationInput;
        public System.Windows.Forms.NumericUpDown mutationInput;
        public System.Windows.Forms.NumericUpDown maxPopulationInput;
        public System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label bestSolution;
        public System.Windows.Forms.Label bestSolutionNum;
        private System.Windows.Forms.Label label5;
    }
}

