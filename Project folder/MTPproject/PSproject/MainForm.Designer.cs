
namespace MTPproject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonStatistici = new System.Windows.Forms.Button();
            this.buttonAnulareInchiriere = new System.Windows.Forms.Button();
            this.buttonAdaugare = new System.Windows.Forms.Button();
            this.buttonInchiriere = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerOraPredare = new System.Windows.Forms.DateTimePicker();
            this.buttonFiltrare = new System.Windows.Forms.Button();
            this.buttonResetareFiltre = new System.Windows.Forms.Button();
            this.dateTimePickerDataPredare = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerOraPreluare = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDataPreluare = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPredare = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxPredare = new System.Windows.Forms.CheckBox();
            this.comboBoxPreluare = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPreluare = new System.Windows.Forms.CheckBox();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gold;
            this.panelMenu.Controls.Add(this.buttonStatistici);
            this.panelMenu.Controls.Add(this.buttonAnulareInchiriere);
            this.panelMenu.Controls.Add(this.buttonAdaugare);
            this.panelMenu.Controls.Add(this.buttonInchiriere);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 547);
            this.panelMenu.TabIndex = 9;
            // 
            // buttonStatistici
            // 
            this.buttonStatistici.BackColor = System.Drawing.Color.Gold;
            this.buttonStatistici.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStatistici.FlatAppearance.BorderSize = 0;
            this.buttonStatistici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatistici.Location = new System.Drawing.Point(0, 219);
            this.buttonStatistici.Name = "buttonStatistici";
            this.buttonStatistici.Size = new System.Drawing.Size(200, 39);
            this.buttonStatistici.TabIndex = 17;
            this.buttonStatistici.Text = "Vizualizare statistici";
            this.buttonStatistici.UseVisualStyleBackColor = false;
            this.buttonStatistici.Click += new System.EventHandler(this.buttonStatistici_Click);
            // 
            // buttonAnulareInchiriere
            // 
            this.buttonAnulareInchiriere.BackColor = System.Drawing.Color.Gold;
            this.buttonAnulareInchiriere.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAnulareInchiriere.FlatAppearance.BorderSize = 0;
            this.buttonAnulareInchiriere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnulareInchiriere.Location = new System.Drawing.Point(0, 180);
            this.buttonAnulareInchiriere.Name = "buttonAnulareInchiriere";
            this.buttonAnulareInchiriere.Size = new System.Drawing.Size(200, 39);
            this.buttonAnulareInchiriere.TabIndex = 18;
            this.buttonAnulareInchiriere.Text = "Anulare inchiriere";
            this.buttonAnulareInchiriere.UseVisualStyleBackColor = false;
            this.buttonAnulareInchiriere.Click += new System.EventHandler(this.buttonAnulareInchiriere_Click);
            // 
            // buttonAdaugare
            // 
            this.buttonAdaugare.BackColor = System.Drawing.Color.Gold;
            this.buttonAdaugare.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAdaugare.FlatAppearance.BorderSize = 0;
            this.buttonAdaugare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugare.Location = new System.Drawing.Point(0, 141);
            this.buttonAdaugare.Name = "buttonAdaugare";
            this.buttonAdaugare.Size = new System.Drawing.Size(200, 39);
            this.buttonAdaugare.TabIndex = 14;
            this.buttonAdaugare.Text = "Adaugare elemente";
            this.buttonAdaugare.UseVisualStyleBackColor = false;
            this.buttonAdaugare.Click += new System.EventHandler(this.buttonAdaugareMasina_Click);
            // 
            // buttonInchiriere
            // 
            this.buttonInchiriere.BackColor = System.Drawing.Color.Gold;
            this.buttonInchiriere.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonInchiriere.FlatAppearance.BorderSize = 0;
            this.buttonInchiriere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInchiriere.Location = new System.Drawing.Point(0, 100);
            this.buttonInchiriere.Name = "buttonInchiriere";
            this.buttonInchiriere.Size = new System.Drawing.Size(200, 41);
            this.buttonInchiriere.TabIndex = 13;
            this.buttonInchiriere.Text = "Inchiriere masina";
            this.buttonInchiriere.UseVisualStyleBackColor = false;
            this.buttonInchiriere.Click += new System.EventHandler(this.buttonInchiriere_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Admin:";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogOut.BackColor = System.Drawing.Color.Silver;
            this.buttonLogOut.FlatAppearance.BorderSize = 0;
            this.buttonLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Location = new System.Drawing.Point(707, 3);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(92, 29);
            this.buttonLogOut.TabIndex = 12;
            this.buttonLogOut.Text = "LOGOUT";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "adminLogat";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.buttonLogOut);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(200, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(802, 32);
            this.panelTop.TabIndex = 14;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.comboBoxStatus);
            this.panelData.Controls.Add(this.label3);
            this.panelData.Controls.Add(this.dateTimePickerOraPredare);
            this.panelData.Controls.Add(this.buttonFiltrare);
            this.panelData.Controls.Add(this.buttonResetareFiltre);
            this.panelData.Controls.Add(this.dateTimePickerDataPredare);
            this.panelData.Controls.Add(this.label7);
            this.panelData.Controls.Add(this.dateTimePickerOraPreluare);
            this.panelData.Controls.Add(this.dateTimePickerDataPreluare);
            this.panelData.Controls.Add(this.label6);
            this.panelData.Controls.Add(this.comboBoxPredare);
            this.panelData.Controls.Add(this.label5);
            this.panelData.Controls.Add(this.checkBoxPredare);
            this.panelData.Controls.Add(this.comboBoxPreluare);
            this.panelData.Controls.Add(this.label4);
            this.panelData.Controls.Add(this.checkBoxPreluare);
            this.panelData.Controls.Add(this.panelDataGridView);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(200, 32);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(10);
            this.panelData.Size = new System.Drawing.Size(802, 515);
            this.panelData.TabIndex = 15;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(337, 44);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(121, 24);
            this.comboBoxStatus.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "Status inchiriere";
            // 
            // dateTimePickerOraPredare
            // 
            this.dateTimePickerOraPredare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePickerOraPredare.CustomFormat = "HH:mm";
            this.dateTimePickerOraPredare.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOraPredare.Location = new System.Drawing.Point(717, 126);
            this.dateTimePickerOraPredare.Name = "dateTimePickerOraPredare";
            this.dateTimePickerOraPredare.Size = new System.Drawing.Size(65, 22);
            this.dateTimePickerOraPredare.TabIndex = 35;
            this.dateTimePickerOraPredare.Value = new System.DateTime(2022, 1, 3, 12, 0, 0, 0);
            // 
            // buttonFiltrare
            // 
            this.buttonFiltrare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonFiltrare.BackColor = System.Drawing.Color.Silver;
            this.buttonFiltrare.FlatAppearance.BorderSize = 0;
            this.buttonFiltrare.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonFiltrare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltrare.Location = new System.Drawing.Point(669, 206);
            this.buttonFiltrare.Name = "buttonFiltrare";
            this.buttonFiltrare.Size = new System.Drawing.Size(113, 34);
            this.buttonFiltrare.TabIndex = 37;
            this.buttonFiltrare.Text = "Filtreaza";
            this.buttonFiltrare.UseVisualStyleBackColor = false;
            this.buttonFiltrare.Click += new System.EventHandler(this.buttonFiltrare_Click);
            // 
            // buttonResetareFiltre
            // 
            this.buttonResetareFiltre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonResetareFiltre.BackColor = System.Drawing.Color.Silver;
            this.buttonResetareFiltre.FlatAppearance.BorderSize = 0;
            this.buttonResetareFiltre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonResetareFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetareFiltre.Location = new System.Drawing.Point(20, 206);
            this.buttonResetareFiltre.Name = "buttonResetareFiltre";
            this.buttonResetareFiltre.Size = new System.Drawing.Size(113, 34);
            this.buttonResetareFiltre.TabIndex = 36;
            this.buttonResetareFiltre.Text = "Resetare filtre";
            this.buttonResetareFiltre.UseVisualStyleBackColor = false;
            this.buttonResetareFiltre.Click += new System.EventHandler(this.buttonResetareFiltre_Click);
            // 
            // dateTimePickerDataPredare
            // 
            this.dateTimePickerDataPredare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePickerDataPredare.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataPredare.Location = new System.Drawing.Point(581, 126);
            this.dateTimePickerDataPredare.Name = "dateTimePickerDataPredare";
            this.dateTimePickerDataPredare.Size = new System.Drawing.Size(130, 22);
            this.dateTimePickerDataPredare.TabIndex = 34;
            this.dateTimePickerDataPredare.ValueChanged += new System.EventHandler(this.dateTimePickerDataPredare_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(697, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Data predare";
            // 
            // dateTimePickerOraPreluare
            // 
            this.dateTimePickerOraPreluare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerOraPreluare.CustomFormat = "HH:mm";
            this.dateTimePickerOraPreluare.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOraPreluare.Location = new System.Drawing.Point(144, 126);
            this.dateTimePickerOraPreluare.Name = "dateTimePickerOraPreluare";
            this.dateTimePickerOraPreluare.Size = new System.Drawing.Size(65, 22);
            this.dateTimePickerOraPreluare.TabIndex = 33;
            this.dateTimePickerOraPreluare.Value = new System.DateTime(2022, 1, 3, 10, 0, 0, 0);
            // 
            // dateTimePickerDataPreluare
            // 
            this.dateTimePickerDataPreluare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePickerDataPreluare.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataPreluare.Location = new System.Drawing.Point(21, 126);
            this.dateTimePickerDataPreluare.Name = "dateTimePickerDataPreluare";
            this.dateTimePickerDataPreluare.Size = new System.Drawing.Size(117, 22);
            this.dateTimePickerDataPreluare.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Data preluare";
            // 
            // comboBoxPredare
            // 
            this.comboBoxPredare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxPredare.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPredare.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPredare.FormattingEnabled = true;
            this.comboBoxPredare.Location = new System.Drawing.Point(525, 44);
            this.comboBoxPredare.Name = "comboBoxPredare";
            this.comboBoxPredare.Size = new System.Drawing.Size(257, 24);
            this.comboBoxPredare.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Locatie predare";
            // 
            // checkBoxPredare
            // 
            this.checkBoxPredare.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxPredare.AutoSize = true;
            this.checkBoxPredare.Location = new System.Drawing.Point(686, 156);
            this.checkBoxPredare.Name = "checkBoxPredare";
            this.checkBoxPredare.Size = new System.Drawing.Size(96, 21);
            this.checkBoxPredare.TabIndex = 39;
            this.checkBoxPredare.Text = "Orice data";
            this.checkBoxPredare.UseVisualStyleBackColor = true;
            this.checkBoxPredare.CheckedChanged += new System.EventHandler(this.checkBoxPredare_CheckedChanged);
            // 
            // comboBoxPreluare
            // 
            this.comboBoxPreluare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxPreluare.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPreluare.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPreluare.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPreluare.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxPreluare.FormattingEnabled = true;
            this.comboBoxPreluare.Location = new System.Drawing.Point(21, 44);
            this.comboBoxPreluare.Name = "comboBoxPreluare";
            this.comboBoxPreluare.Size = new System.Drawing.Size(254, 24);
            this.comboBoxPreluare.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Locatie preluare";
            // 
            // checkBoxPreluare
            // 
            this.checkBoxPreluare.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxPreluare.AutoSize = true;
            this.checkBoxPreluare.Location = new System.Drawing.Point(21, 156);
            this.checkBoxPreluare.Name = "checkBoxPreluare";
            this.checkBoxPreluare.Size = new System.Drawing.Size(96, 21);
            this.checkBoxPreluare.TabIndex = 38;
            this.checkBoxPreluare.Text = "Orice data";
            this.checkBoxPreluare.UseVisualStyleBackColor = true;
            this.checkBoxPreluare.CheckedChanged += new System.EventHandler(this.checkBoxPreluare_CheckedChanged);
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.dataGridView1);
            this.panelDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDataGridView.Location = new System.Drawing.Point(10, 246);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Padding = new System.Windows.Forms.Padding(10);
            this.panelDataGridView.Size = new System.Drawing.Size(782, 259);
            this.panelDataGridView.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(762, 239);
            this.dataGridView1.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1002, 547);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Meniu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonInchiriere;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStatistici;
        private System.Windows.Forms.Button buttonAdaugare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAnulareInchiriere;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.CheckBox checkBoxPreluare;
        private System.Windows.Forms.CheckBox checkBoxPredare;
        private System.Windows.Forms.Button buttonFiltrare;
        private System.Windows.Forms.Button buttonResetareFiltre;
        private System.Windows.Forms.DateTimePicker dateTimePickerOraPredare;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataPredare;
        private System.Windows.Forms.DateTimePicker dateTimePickerOraPreluare;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataPreluare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPredare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPreluare;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label3;
    }
}