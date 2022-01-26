
namespace MTPproject
{
    partial class FormAnulare
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
            this.dataGridViewInchirieri = new System.Windows.Forms.DataGridView();
            this.buttonAnulare = new System.Windows.Forms.Button();
            this.panelButon = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMotivAnulare = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInchirieri)).BeginInit();
            this.panelButon.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewInchirieri
            // 
            this.dataGridViewInchirieri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInchirieri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInchirieri.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewInchirieri.Name = "dataGridViewInchirieri";
            this.dataGridViewInchirieri.RowHeadersWidth = 51;
            this.dataGridViewInchirieri.RowTemplate.Height = 24;
            this.dataGridViewInchirieri.Size = new System.Drawing.Size(780, 383);
            this.dataGridViewInchirieri.TabIndex = 0;
            this.dataGridViewInchirieri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInchirieri_CellClick);
            // 
            // buttonAnulare
            // 
            this.buttonAnulare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnulare.BackColor = System.Drawing.Color.Silver;
            this.buttonAnulare.FlatAppearance.BorderSize = 0;
            this.buttonAnulare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonAnulare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnulare.Location = new System.Drawing.Point(638, 9);
            this.buttonAnulare.Name = "buttonAnulare";
            this.buttonAnulare.Size = new System.Drawing.Size(159, 35);
            this.buttonAnulare.TabIndex = 1;
            this.buttonAnulare.Text = "Anulare inchiriere";
            this.buttonAnulare.UseVisualStyleBackColor = false;
            this.buttonAnulare.Click += new System.EventHandler(this.buttonAnulare_Click);
            // 
            // panelButon
            // 
            this.panelButon.Controls.Add(this.comboBoxMotivAnulare);
            this.panelButon.Controls.Add(this.label1);
            this.panelButon.Controls.Add(this.buttonAnulare);
            this.panelButon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButon.Location = new System.Drawing.Point(0, 403);
            this.panelButon.Name = "panelButon";
            this.panelButon.Size = new System.Drawing.Size(800, 47);
            this.panelButon.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewInchirieri);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(800, 403);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Motiv anulare:";
            // 
            // comboBoxMotivAnulare
            // 
            this.comboBoxMotivAnulare.FormattingEnabled = true;
            this.comboBoxMotivAnulare.Location = new System.Drawing.Point(111, 15);
            this.comboBoxMotivAnulare.Name = "comboBoxMotivAnulare";
            this.comboBoxMotivAnulare.Size = new System.Drawing.Size(193, 24);
            this.comboBoxMotivAnulare.TabIndex = 3;
            // 
            // FormAnulare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAnulare";
            this.Text = "Anulare inchiriere";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAnulare_FormClosing);
            this.Load += new System.EventHandler(this.FormAnulare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInchirieri)).EndInit();
            this.panelButon.ResumeLayout(false);
            this.panelButon.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInchirieri;
        private System.Windows.Forms.Button buttonAnulare;
        private System.Windows.Forms.Panel panelButon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxMotivAnulare;
        private System.Windows.Forms.Label label1;
    }
}