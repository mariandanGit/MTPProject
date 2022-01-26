using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTPproject
{
    public partial class FormInchiriere : Form
    {
        int masinaSelectata = -1;
        int clientSelectat = -1;
        int asigurareSelectata = -1;
        string nAdmin;
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public FormInchiriere(string n)
        {
            nAdmin = n;
            InitializeComponent();
        }
        private void FormInchiriere_Load(object sender, EventArgs e)
        {
            panel5.BackColor = Color.WhiteSmoke;
            panel1.BackColor = Color.Gold;
            panel2.BackColor = Color.Gold;
            panel3.BackColor = Color.Gold;
            panel4.BackColor = Color.Gold;

            dateTimePickerOraPreluare.ShowUpDown = true;
            dateTimePickerOraPredare.ShowUpDown = true;
            dateTimePickerDataPredare.Value = dateTimePickerDataPreluare.Value.AddDays(2);
            panelUnderlayBasic.Hide();
            panelUnderlayPro.Hide();

            string[] categorii = { "Orice categorie", "Mici", "Medii", "Mari", "Premium", "Monovolum" };
            comboBoxCategorie.Items.AddRange(categorii);

            dataGridviewDesign(dataGridViewClienti);
            fillDataGridViewClienti();
            fillComboBoxes();
        }
        private void dataGridviewDesign(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.ReadOnly = true;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gold;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.RowHeadersVisible = false;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.Silver;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Silver;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Gold;
        }
        private void fillDataGridViewClienti()
        {
            SqlConnection conn = new SqlConnection(connect);

            try
            {
                conn.Open();

                string tabelDate = "select * from Clienti";
                SqlDataAdapter da = new SqlDataAdapter(tabelDate, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Clienti");
                dataGridViewClienti.DataSource = ds.Tables["Clienti"].DefaultView;
                dataGridViewClienti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewClienti.MultiSelect = false;

                conn.Close();

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare: {0}", ex.Message));
            }
        }
        private void fillComboBoxes()
        {

            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            string command = "select * from Locatii";
            SqlCommand sqlCommand = new SqlCommand(command, conn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                comboBoxPreluare.Items.Add(sqlReader["Nume"].ToString());
                comboBoxPredare.Items.Add(sqlReader["Nume"].ToString());
            }

            conn.Close();
        }
        
        private void buttonNextClient_Click(object sender, EventArgs e)
        {
            if (clientSelectat == -1)
            {
                MessageBox.Show("Selectati un client!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                panel5.BackColor = Color.Gold;
                panel1.BackColor = Color.WhiteSmoke;
                panel2.BackColor = Color.Gold;
                panel3.BackColor = Color.Gold;
                panel4.BackColor = Color.Gold;

                panelLocatie.BringToFront();
            }
        }
        private void buttonBackLocatie_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.WhiteSmoke;
            panel1.BackColor = Color.Gold;
            panel2.BackColor = Color.Gold;
            panel3.BackColor = Color.Gold;
            panel4.BackColor = Color.Gold;

            panelClient.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connect);

            if (comboBoxPreluare.Text == "" && comboBoxPredare.Text == "")
            {
                MessageBox.Show("Selectati date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxPreluare.Text == "")
            {
                MessageBox.Show("Selectati data de preluare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxPredare.Text == "")
            {
                MessageBox.Show("Selectati data de predare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                labelNumeLocatie.Text = comboBoxPreluare.Text;
                DateTime ziPreluareDT = DateTime.Parse(dateTimePickerDataPreluare.Text);
                DateTime ziPredareDT = DateTime.Parse(dateTimePickerDataPredare.Text);
                DateTime oraPreluareDT = DateTime.Parse(dateTimePickerOraPreluare.Text);
                DateTime oraPredareDT = DateTime.Parse(dateTimePickerOraPredare.Text);
                int numarZile = (ziPredareDT - ziPreluareDT).Days;
                int numarOre = (oraPredareDT - oraPreluareDT).Hours;
                if(numarZile == 0 && numarOre < 0)
                {
                    MessageBox.Show("Ora de predare nu poate fi mai devreme decat ora de preluare in aceeasi zi!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerOraPredare.Value = dateTimePickerOraPreluare.Value.AddHours(2);
                }
                else if (numarZile < 0)
                {
                    MessageBox.Show("Ziua de predare nu poate fi mai devreme de ziua de preluare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerDataPredare.Value = dateTimePickerDataPreluare.Value.AddDays(2);
                }
                else
                {
                    try
                    {
                        conn.Open();

                        string command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPreluare.Text + "'";
                        SqlCommand sqlCommand = new SqlCommand(command, conn);
                        int idPreluare = (int)sqlCommand.ExecuteScalar();
                        string commandFlowLayout = "select * from Masini where ID_Locatie = '" + idPreluare.ToString() + "'";
                        fillFlowLayoutMasini(commandFlowLayout);

                        conn.Close();

                        panel5.BackColor = Color.Gold;
                        panel1.BackColor = Color.Gold;
                        panel2.BackColor = Color.WhiteSmoke;
                        panel3.BackColor = Color.Gold;
                        panel4.BackColor = Color.Gold;

                        panelMasina.BringToFront();
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
                    }                    
                }
            }
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            if(masinaSelectata == -1)
            {
                MessageBox.Show("Selectati o masina!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                panel5.BackColor = Color.Gold;
                panel1.BackColor = Color.Gold;
                panel2.BackColor = Color.Gold;
                panel3.BackColor = Color.WhiteSmoke;
                panel4.BackColor = Color.Gold;

                panelAsigurare.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gold;
            panel1.BackColor = Color.Gold;
            panel2.BackColor = Color.WhiteSmoke;
            panel3.BackColor = Color.Gold;
            panel4.BackColor = Color.Gold;

            panelMasina.BringToFront();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (asigurareSelectata == 0)
            {
                MessageBox.Show("Selectati un tip de asigurare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                panel5.BackColor = Color.Gold;
                panel1.BackColor = Color.Gold;
                panel2.BackColor = Color.Gold;
                panel3.BackColor = Color.Gold;
                panel4.BackColor = Color.WhiteSmoke;

                panelFinalizare.BringToFront();

                fillReview();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gold;
            panel1.BackColor = Color.Gold;
            panel2.BackColor = Color.Gold;
            panel3.BackColor = Color.WhiteSmoke;
            panel4.BackColor = Color.Gold;

            panelAsigurare.BringToFront();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Gold;
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.Gold;
            panel3.BackColor = Color.Gold;
            panel4.BackColor = Color.Gold;

            panelLocatie.BringToFront();
            flowLayoutPanelMasini.Controls.Clear();
        }
        private void comboBoxCategorie_SelectedValueChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connect);

            try
            {
                flowLayoutPanelMasini.Controls.Clear();

                conn.Open();

                string command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPreluare.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                int idPreluare = (int)sqlCommand.ExecuteScalar();

                string flowLayoutCommand = "";

                if (comboBoxCategorie.Text == "Orice categorie")
                {
                    flowLayoutCommand =  "select * from Masini where ID_Locatie = '" + idPreluare.ToString() + "' and Pret_per_zi <= '" + numericUpDownPret.Value + "'";
                }
                else
                {
                    flowLayoutCommand = "select * from Masini where ID_Locatie = '" + idPreluare.ToString() + "' and Categorie = '" + comboBoxCategorie.Text + "' and Pret_per_zi <= '" + numericUpDownPret.Value + "'";
                }
                fillFlowLayoutMasini(flowLayoutCommand);

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
            }
        }
        private void numericUpDownPret_ValueChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connect);

            try
            {
                flowLayoutPanelMasini.Controls.Clear();

                conn.Open();

                string command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPreluare.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                int idPreluare = (int)sqlCommand.ExecuteScalar();
                string flowLayoutCommand = "";
                if (comboBoxCategorie.Text == "Orice categorie")
                {
                    flowLayoutCommand = "select * from Masini where ID_Locatie = '" + idPreluare.ToString() + "' and Pret_per_zi <= '" + numericUpDownPret.Value + "'";
                }
                else
                {
                    flowLayoutCommand = "select * from Masini where ID_Locatie = '" + idPreluare.ToString() + "' and Categorie = '" + comboBoxCategorie.Text + "' and Pret_per_zi <= '" + numericUpDownPret.Value + "'";
                }
                fillFlowLayoutMasini(flowLayoutCommand);

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
            }
        }
        private void fillFlowLayoutMasini(string cmd)
        {

            SqlConnection conn = new SqlConnection(connect);
            try
            {
                conn.Open();
                string command = cmd;
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    Panel underlayPanel = new Panel();
                    Panel dataPanel = new Panel();
                    PictureBox pictureBox = new PictureBox();
                    TableLayoutPanel tableLayout = new TableLayoutPanel();

                    Label marca = new Label();
                    Label model = new Label();
                    Label transmisie = new Label();
                    Label combustibil = new Label();
                    Label locuri = new Label();
                    Label bagaje = new Label();
                    Label pret = new Label();

                    Label transmisieValue = new Label();
                    Label combustibilValue = new Label();
                    Label locuriValue = new Label();
                    Label bagajeValue = new Label();
                    Label pretValue = new Label();

                    marca.Text = sqlReader["Marca"].ToString();
                    model.Text = sqlReader["Model"].ToString();
                    transmisie.Text = "Transmisie";
                    combustibil.Text = "Combustibil";
                    locuri.Text = "Locuri";
                    bagaje.Text = "Bagaje";
                    pret.Text = "Pret / zi";

                    transmisieValue.Text = sqlReader["Transmisie"].ToString();
                    combustibilValue.Text = sqlReader["Combustibil"].ToString();
                    locuriValue.Text = sqlReader["Nr_locuri"].ToString();
                    bagajeValue.Text = sqlReader["Nr_bagaje"].ToString();
                    pretValue.Text = sqlReader["Pret_per_zi"].ToString() + " RON";

                    underlayPanel.Size = new Size(208, 288);
                    underlayPanel.BackColor = Color.Empty;
                    underlayPanel.Margin = new Padding(18);

                    dataPanel.Size = new Size(200, 280);
                    dataPanel.Location = new Point((underlayPanel.Width - dataPanel.Width) / 2, (underlayPanel.Height - dataPanel.Height) / 2);
                    dataPanel.Anchor = AnchorStyles.None;
                    dataPanel.BackColor = Color.Silver;
                    dataPanel.Name = "panel" + sqlReader["ID_Masina"].ToString();

                    pictureBox.Dock = DockStyle.Top;
                    pictureBox.Height = 130;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = Application.StartupPath + "\\ImaginiMasini\\" + sqlReader["Poza"].ToString();

                    pictureBox.Click += (s, e) => {
                        foreach (Control c in flowLayoutPanelMasini.Controls)
                        {
                            if (c is Panel)
                            {
                                c.BackColor = Color.Empty;
                            }
                        }
                        dataPanel.Parent.BackColor = Color.Gold;
                        string indexMasinaSelectata = new String(dataPanel.Name.Where(Char.IsDigit).ToArray());
                        masinaSelectata = Int32.Parse(indexMasinaSelectata);
                    };

                    tableLayout.Dock = DockStyle.Bottom;
                    tableLayout.RowCount = 6;
                    tableLayout.ColumnCount = 2;
                    tableLayout.Height = 140;

                    tableLayout.Controls.Add(marca);
                    tableLayout.Controls.Add(model);
                    tableLayout.Controls.Add(transmisie);
                    tableLayout.Controls.Add(transmisieValue);
                    tableLayout.Controls.Add(combustibil);
                    tableLayout.Controls.Add(combustibilValue);
                    tableLayout.Controls.Add(locuri);
                    tableLayout.Controls.Add(locuriValue);
                    tableLayout.Controls.Add(bagaje);
                    tableLayout.Controls.Add(bagajeValue);
                    tableLayout.Controls.Add(pret);
                    tableLayout.Controls.Add(pretValue);

                    dataPanel.Controls.Add(tableLayout);
                    dataPanel.Controls.Add(pictureBox);
                    underlayPanel.Controls.Add(dataPanel);
                    flowLayoutPanelMasini.Controls.Add(underlayPanel);

                }
                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Masini: {0}", ex.Message));
            }
        }
        private void fillReview()
        {

            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            string command = "select * from Masini where ID_Masina = '"+masinaSelectata+"'";
            SqlCommand sqlCommand = new SqlCommand(command, conn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            string locatiePreluare = comboBoxPreluare.Text;
            string locatiePredare = comboBoxPredare.Text;
            string dataPreluare = dateTimePickerDataPreluare.Text + " " + dateTimePickerOraPreluare.Text;
            string dataPredare = dateTimePickerDataPredare.Text + " " + dateTimePickerOraPredare.Text;
            DateTime ziPreluareDT = DateTime.Parse(dateTimePickerDataPreluare.Text);
            DateTime ziPredareDT = DateTime.Parse(dateTimePickerDataPredare.Text);
            int numarZile = (ziPredareDT - ziPreluareDT).Days;

            string costPerZi = "";
            string marca = "";
            string model = "";
            string poza = "";
            string transmisie = "";
            string combustibil = "";
            string nrLocuri = "";
            string nrBagaje = "";

            if(sqlReader.Read())
            {
                costPerZi = sqlReader["Pret_per_zi"].ToString();
                marca = sqlReader["Marca"].ToString();
                model = sqlReader["Model"].ToString();
                poza = sqlReader["Poza"].ToString();
                transmisie = sqlReader["Transmisie"].ToString();
                combustibil = sqlReader["Combustibil"].ToString();
                nrLocuri = sqlReader["Nr_locuri"].ToString();
                nrBagaje = sqlReader["Nr_bagaje"].ToString();
            }
            else
            {
                MessageBox.Show("Eroare la extragerea datelor din baza de date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            float costPerZiFloat = float.Parse(costPerZi);
            float costAsigurare;

            if(asigurareSelectata == 1)
            {
                costAsigurare = 110;
            }
            else
            {
                costAsigurare = 130;
            }
            string costTotal = "";
            if(numarZile == 0)
            {
                costTotal = (costPerZiFloat + costAsigurare).ToString();
            }
            else
            {
                costTotal = ((costPerZiFloat + costAsigurare) * numarZile).ToString();
            }

            pictureBox2.ImageLocation = Application.StartupPath + "\\ImaginiMasini\\"+poza; 
            labelMarca.Text = marca;
            labelModel.Text = model;
            labelTransmisie.Text = transmisie;
            labelCombustibil.Text = combustibil;
            labelNrLocuri.Text = nrLocuri;
            labelNrBagaje.Text = nrBagaje;

            labelLocatiePreluare.Text = locatiePreluare;
            labelLocatiePredare.Text = locatiePredare;
            labelDataPreluare.Text = dataPreluare;
            labelDataPredare.Text = dataPredare;
            labelCost.Text = costTotal + " RON";
        }
        private void dataGridViewClienti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clientSelectat = dataGridViewClienti.CurrentCell.RowIndex;
        }

        private void FormInchiriere_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Doriti sa iesiti?",
                               "Confirm",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Hide();
                    MainForm f = new MainForm(nAdmin);
                    f.ShowDialog();
                }

                else
                    e.Cancel = true;
            }
        }
        private void buttonInchiriere_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            string command = "select * from Masini where ID_Masina = '" + masinaSelectata + "'";
            SqlCommand sqlCommand = new SqlCommand(command, conn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            string locatiePreluare = comboBoxPreluare.Text;
            string locatiePredare = comboBoxPredare.Text;

            DateTime dataPreluare = DateTime.Parse(dateTimePickerDataPreluare.Text + " " + dateTimePickerOraPreluare.Text);
            DateTime dataPredare = DateTime.Parse(dateTimePickerDataPredare.Text + " " + dateTimePickerOraPredare.Text);
            
            int numarZile = (dataPredare - dataPreluare).Days;
            int idMasina = masinaSelectata;
            float costPerZi = 0;

            if (sqlReader.Read())
            {
                costPerZi = float.Parse(sqlReader["Pret_per_zi"].ToString());
                sqlReader.Close();
            }
            else
            {
                MessageBox.Show("Eroare la extragerea datelor din baza de date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string numeAsigurare;
            string tipAsigurare;
            float costAsigurare;
            if (asigurareSelectata == 1)
            {
                numeAsigurare = "Asigurare Basic";
                tipAsigurare = "De baza";
                costAsigurare = 110;
            }
            else
            {
                numeAsigurare = "Asigurare Pro";
                tipAsigurare = "De baza + asistenta";
                costAsigurare = 130;
            }
            float costTotalAsigurare = 0;
            float costTotal = 0;
            if (numarZile > 0)
            {
                costTotalAsigurare = costAsigurare * numarZile;
                costTotal = (costPerZi + costAsigurare) * numarZile;
            }
            else
            {
                costTotalAsigurare = costAsigurare;
                costTotal = costPerZi + costAsigurare;
            }

            string status = "In desfasurare";

            int rowIndexClienti = dataGridViewClienti.CurrentCell.RowIndex;
            int idClient = Int32.Parse(dataGridViewClienti.Rows[rowIndexClienti].Cells[0].Value.ToString());

            int idPreluare = -1;
            int idPredare = -1;

            try
            {
                command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPreluare.Text + "'";
                sqlCommand = new SqlCommand(command, conn);
                idPreluare = (int)sqlCommand.ExecuteScalar();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
            }

            try
            {
                command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPredare.Text + "'";
                sqlCommand = new SqlCommand(command, conn);
                idPredare = (int)sqlCommand.ExecuteScalar();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
            }

            try
            {
                command = "update Masini set Status = 'Indisponibil' where ID_Masina = '"+idMasina+"'";
                sqlCommand = new SqlCommand(command, conn);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la update Masini: {0}", ex.Message));
            }

            try
            {
                command = "update Masini set ID_Locatie = '" + idPredare + "' where ID_Masina = '" + idMasina + "'";
                sqlCommand = new SqlCommand(command, conn);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la update Masini: {0}", ex.Message));
            }

            try
            {
                command = "insert into Inchirieri ([Data_preluare], [Data_predare], [Cost], [Nume_asigurare],[Tip_asigurare], [Cost_asigurare], [Status], [ID_Client], [ID_Locatie_preluare], [ID_Locatie_predare], [ID_Masina]) " +
                "values(@dataPreluare, @dataPredare, @cost, @nAsigurare, @tAsigurare, @cAsigurare, @status, @idClient, @idLocPreluare, @idLocPredare, @idMasina)";
                sqlCommand = new SqlCommand(command, conn);
                sqlCommand.Parameters.AddWithValue("@dataPreluare", dataPreluare);
                sqlCommand.Parameters.AddWithValue("@dataPredare", dataPredare);
                sqlCommand.Parameters.AddWithValue("@cost", costTotal);
                sqlCommand.Parameters.AddWithValue("@nAsigurare", numeAsigurare);
                sqlCommand.Parameters.AddWithValue("@tAsigurare", tipAsigurare);
                sqlCommand.Parameters.AddWithValue("@cAsigurare", costTotalAsigurare);
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@idClient", idClient);
                sqlCommand.Parameters.AddWithValue("@idLocPreluare", idPreluare);
                sqlCommand.Parameters.AddWithValue("@idLocPredare", idPredare);
                sqlCommand.Parameters.AddWithValue("@idMasina", idMasina);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inchiriere realizata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm f = new MainForm(nAdmin);
                f.ShowDialog();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la inchiriere: {0}", ex.Message));
            }
            conn.Close();
        }

        private void buttonClientNou_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdaugare f = new FormAdaugare(nAdmin);
            f.ShowDialog();
        }

        private void buttonMasinaNoua_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdaugare f = new FormAdaugare(nAdmin);
            f.ShowDialog();
        }

        private void buttonLocatieNoua_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdaugare f = new FormAdaugare(nAdmin);
            f.ShowDialog();
        }
        private void panelBasic_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Show();
            panelUnderlayPro.Hide();
            asigurareSelectata = 1;
        }

        private void pictureBoxBasic_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Show();
            panelUnderlayPro.Hide();
            asigurareSelectata = 1;
        }

        private void tableLayoutPanelBasic_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Show();
            panelUnderlayPro.Hide();
            asigurareSelectata = 1;
        }
        private void panelPro_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Hide();
            panelUnderlayPro.Show();
            asigurareSelectata = 2;
        }
        private void pictureBoxPro_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Hide();
            panelUnderlayPro.Show();
            asigurareSelectata = 2;
        }

        private void tableLayoutPanelPro_Click(object sender, EventArgs e)
        {
            panelUnderlayBasic.Hide();
            panelUnderlayPro.Show();
            asigurareSelectata = 2;
        }
    }
}
