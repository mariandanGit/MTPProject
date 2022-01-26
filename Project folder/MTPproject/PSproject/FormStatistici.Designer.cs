
namespace MTPproject
{
    partial class FormStatistici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartStatistici = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAnInchirieri = new System.Windows.Forms.NumericUpDown();
            this.panelChartInchirieri = new System.Windows.Forms.Panel();
            this.panelTop1 = new System.Windows.Forms.Panel();
            this.buttonNextInchirieri = new System.Windows.Forms.Button();
            this.panelTop2 = new System.Windows.Forms.Panel();
            this.buttonInapoiMasini = new System.Windows.Forms.Button();
            this.buttonNextMasini = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTopContainer = new System.Windows.Forms.Panel();
            this.panelTop3 = new System.Windows.Forms.Panel();
            this.buttonInapoiIncasari = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAnIncasari = new System.Windows.Forms.NumericUpDown();
            this.panelChartMasini = new System.Windows.Forms.Panel();
            this.chartMasini = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChartIncasari = new System.Windows.Forms.Panel();
            this.chartIncasari = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnInchirieri)).BeginInit();
            this.panelChartInchirieri.SuspendLayout();
            this.panelTop1.SuspendLayout();
            this.panelTop2.SuspendLayout();
            this.panelTopContainer.SuspendLayout();
            this.panelTop3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnIncasari)).BeginInit();
            this.panelChartMasini.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMasini)).BeginInit();
            this.panelChartIncasari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncasari)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStatistici
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatistici.ChartAreas.Add(chartArea1);
            this.chartStatistici.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Inchirieri";
            this.chartStatistici.Legends.Add(legend1);
            this.chartStatistici.Location = new System.Drawing.Point(10, 10);
            this.chartStatistici.Name = "chartStatistici";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Inchirieri";
            series1.Name = "In desfasurare";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Legend = "Inchirieri";
            series2.Name = "Finalizate";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Inchirieri";
            series3.Name = "Anulate";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Inchirieri";
            series4.Name = "Rezervate";
            this.chartStatistici.Series.Add(series1);
            this.chartStatistici.Series.Add(series2);
            this.chartStatistici.Series.Add(series3);
            this.chartStatistici.Series.Add(series4);
            this.chartStatistici.Size = new System.Drawing.Size(713, 341);
            this.chartStatistici.TabIndex = 0;
            this.chartStatistici.Text = "chartStatistici";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Statistica inchirierilor pentru anul";
            // 
            // numericUpDownAnInchirieri
            // 
            this.numericUpDownAnInchirieri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownAnInchirieri.Location = new System.Drawing.Point(398, 14);
            this.numericUpDownAnInchirieri.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownAnInchirieri.Name = "numericUpDownAnInchirieri";
            this.numericUpDownAnInchirieri.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAnInchirieri.TabIndex = 4;
            this.numericUpDownAnInchirieri.ValueChanged += new System.EventHandler(this.numericUpDownAn_ValueChanged);
            // 
            // panelChartInchirieri
            // 
            this.panelChartInchirieri.Controls.Add(this.chartStatistici);
            this.panelChartInchirieri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartInchirieri.Location = new System.Drawing.Point(0, 60);
            this.panelChartInchirieri.Name = "panelChartInchirieri";
            this.panelChartInchirieri.Padding = new System.Windows.Forms.Padding(10);
            this.panelChartInchirieri.Size = new System.Drawing.Size(733, 361);
            this.panelChartInchirieri.TabIndex = 5;
            // 
            // panelTop1
            // 
            this.panelTop1.Controls.Add(this.buttonNextInchirieri);
            this.panelTop1.Controls.Add(this.label1);
            this.panelTop1.Controls.Add(this.numericUpDownAnInchirieri);
            this.panelTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop1.Location = new System.Drawing.Point(0, 0);
            this.panelTop1.Name = "panelTop1";
            this.panelTop1.Size = new System.Drawing.Size(733, 60);
            this.panelTop1.TabIndex = 6;
            // 
            // buttonNextInchirieri
            // 
            this.buttonNextInchirieri.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonNextInchirieri.BackColor = System.Drawing.Color.Silver;
            this.buttonNextInchirieri.FlatAppearance.BorderSize = 0;
            this.buttonNextInchirieri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonNextInchirieri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextInchirieri.Location = new System.Drawing.Point(615, 13);
            this.buttonNextInchirieri.Name = "buttonNextInchirieri";
            this.buttonNextInchirieri.Size = new System.Drawing.Size(115, 30);
            this.buttonNextInchirieri.TabIndex = 5;
            this.buttonNextInchirieri.Text = "Mai departe";
            this.buttonNextInchirieri.UseVisualStyleBackColor = false;
            this.buttonNextInchirieri.Click += new System.EventHandler(this.buttonNextInchirieri_Click);
            // 
            // panelTop2
            // 
            this.panelTop2.Controls.Add(this.buttonInapoiMasini);
            this.panelTop2.Controls.Add(this.buttonNextMasini);
            this.panelTop2.Controls.Add(this.label2);
            this.panelTop2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop2.Location = new System.Drawing.Point(0, 0);
            this.panelTop2.Name = "panelTop2";
            this.panelTop2.Size = new System.Drawing.Size(733, 60);
            this.panelTop2.TabIndex = 7;
            // 
            // buttonInapoiMasini
            // 
            this.buttonInapoiMasini.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonInapoiMasini.BackColor = System.Drawing.Color.Silver;
            this.buttonInapoiMasini.FlatAppearance.BorderSize = 0;
            this.buttonInapoiMasini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonInapoiMasini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInapoiMasini.Location = new System.Drawing.Point(3, 13);
            this.buttonInapoiMasini.Name = "buttonInapoiMasini";
            this.buttonInapoiMasini.Size = new System.Drawing.Size(115, 30);
            this.buttonInapoiMasini.TabIndex = 6;
            this.buttonInapoiMasini.Text = "Inapoi";
            this.buttonInapoiMasini.UseVisualStyleBackColor = false;
            this.buttonInapoiMasini.Click += new System.EventHandler(this.buttonInapoiMasini_Click);
            // 
            // buttonNextMasini
            // 
            this.buttonNextMasini.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonNextMasini.BackColor = System.Drawing.Color.Silver;
            this.buttonNextMasini.FlatAppearance.BorderSize = 0;
            this.buttonNextMasini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonNextMasini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextMasini.Location = new System.Drawing.Point(615, 13);
            this.buttonNextMasini.Name = "buttonNextMasini";
            this.buttonNextMasini.Size = new System.Drawing.Size(115, 30);
            this.buttonNextMasini.TabIndex = 5;
            this.buttonNextMasini.Text = "Mai departe";
            this.buttonNextMasini.UseVisualStyleBackColor = false;
            this.buttonNextMasini.Click += new System.EventHandler(this.buttonNextMasini_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Statistica masinilor avariate";
            // 
            // panelTopContainer
            // 
            this.panelTopContainer.Controls.Add(this.panelTop1);
            this.panelTopContainer.Controls.Add(this.panelTop2);
            this.panelTopContainer.Controls.Add(this.panelTop3);
            this.panelTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopContainer.Location = new System.Drawing.Point(0, 0);
            this.panelTopContainer.Name = "panelTopContainer";
            this.panelTopContainer.Size = new System.Drawing.Size(733, 60);
            this.panelTopContainer.TabIndex = 1;
            // 
            // panelTop3
            // 
            this.panelTop3.Controls.Add(this.buttonInapoiIncasari);
            this.panelTop3.Controls.Add(this.label3);
            this.panelTop3.Controls.Add(this.numericUpDownAnIncasari);
            this.panelTop3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop3.Location = new System.Drawing.Point(0, 0);
            this.panelTop3.Name = "panelTop3";
            this.panelTop3.Size = new System.Drawing.Size(733, 60);
            this.panelTop3.TabIndex = 7;
            // 
            // buttonInapoiIncasari
            // 
            this.buttonInapoiIncasari.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonInapoiIncasari.BackColor = System.Drawing.Color.Silver;
            this.buttonInapoiIncasari.FlatAppearance.BorderSize = 0;
            this.buttonInapoiIncasari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonInapoiIncasari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInapoiIncasari.Location = new System.Drawing.Point(3, 13);
            this.buttonInapoiIncasari.Name = "buttonInapoiIncasari";
            this.buttonInapoiIncasari.Size = new System.Drawing.Size(115, 30);
            this.buttonInapoiIncasari.TabIndex = 5;
            this.buttonInapoiIncasari.Text = "Inapoi";
            this.buttonInapoiIncasari.UseVisualStyleBackColor = false;
            this.buttonInapoiIncasari.Click += new System.EventHandler(this.buttonInapoiIncasari_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Statistica incasarilor pentru anul";
            // 
            // numericUpDownAnIncasari
            // 
            this.numericUpDownAnIncasari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownAnIncasari.Location = new System.Drawing.Point(398, 14);
            this.numericUpDownAnIncasari.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownAnIncasari.Name = "numericUpDownAnIncasari";
            this.numericUpDownAnIncasari.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAnIncasari.TabIndex = 4;
            this.numericUpDownAnIncasari.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.numericUpDownAnIncasari.ValueChanged += new System.EventHandler(this.numericUpDownAnIncasari_ValueChanged);
            // 
            // panelChartMasini
            // 
            this.panelChartMasini.Controls.Add(this.chartMasini);
            this.panelChartMasini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartMasini.Location = new System.Drawing.Point(0, 60);
            this.panelChartMasini.Name = "panelChartMasini";
            this.panelChartMasini.Padding = new System.Windows.Forms.Padding(10);
            this.panelChartMasini.Size = new System.Drawing.Size(733, 361);
            this.panelChartMasini.TabIndex = 1;
            // 
            // chartMasini
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMasini.ChartAreas.Add(chartArea2);
            this.chartMasini.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartMasini.Legends.Add(legend2);
            this.chartMasini.Location = new System.Drawing.Point(10, 10);
            this.chartMasini.Name = "chartMasini";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Masini avariate";
            series5.YValuesPerPoint = 4;
            this.chartMasini.Series.Add(series5);
            this.chartMasini.Size = new System.Drawing.Size(713, 341);
            this.chartMasini.TabIndex = 0;
            this.chartMasini.Text = "chart1";
            // 
            // panelChartIncasari
            // 
            this.panelChartIncasari.Controls.Add(this.chartIncasari);
            this.panelChartIncasari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartIncasari.Location = new System.Drawing.Point(0, 60);
            this.panelChartIncasari.Name = "panelChartIncasari";
            this.panelChartIncasari.Padding = new System.Windows.Forms.Padding(10);
            this.panelChartIncasari.Size = new System.Drawing.Size(733, 361);
            this.panelChartIncasari.TabIndex = 2;
            // 
            // chartIncasari
            // 
            chartArea3.Name = "ChartArea1";
            this.chartIncasari.ChartAreas.Add(chartArea3);
            this.chartIncasari.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartIncasari.Legends.Add(legend3);
            this.chartIncasari.Location = new System.Drawing.Point(10, 10);
            this.chartIncasari.Name = "chartIncasari";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Crestere";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Incasari";
            this.chartIncasari.Series.Add(series6);
            this.chartIncasari.Series.Add(series7);
            this.chartIncasari.Size = new System.Drawing.Size(713, 341);
            this.chartIncasari.TabIndex = 0;
            this.chartIncasari.Text = "chart1";
            // 
            // FormStatistici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 421);
            this.Controls.Add(this.panelChartInchirieri);
            this.Controls.Add(this.panelChartMasini);
            this.Controls.Add(this.panelChartIncasari);
            this.Controls.Add(this.panelTopContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormStatistici";
            this.Text = "Statistici";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatistici_FormClosing);
            this.Load += new System.EventHandler(this.FormStatistici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnInchirieri)).EndInit();
            this.panelChartInchirieri.ResumeLayout(false);
            this.panelTop1.ResumeLayout(false);
            this.panelTop1.PerformLayout();
            this.panelTop2.ResumeLayout(false);
            this.panelTop2.PerformLayout();
            this.panelTopContainer.ResumeLayout(false);
            this.panelTop3.ResumeLayout(false);
            this.panelTop3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnIncasari)).EndInit();
            this.panelChartMasini.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMasini)).EndInit();
            this.panelChartIncasari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIncasari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownAnInchirieri;
        private System.Windows.Forms.Panel panelChartInchirieri;
        private System.Windows.Forms.Panel panelTop1;
        private System.Windows.Forms.Button buttonNextInchirieri;
        private System.Windows.Forms.Panel panelTop2;
        private System.Windows.Forms.Button buttonInapoiMasini;
        private System.Windows.Forms.Button buttonNextMasini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTopContainer;
        private System.Windows.Forms.Panel panelTop3;
        private System.Windows.Forms.Button buttonInapoiIncasari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAnIncasari;
        private System.Windows.Forms.Panel panelChartMasini;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMasini;
        private System.Windows.Forms.Panel panelChartIncasari;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIncasari;
    }
}