using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTPproject
{
    public partial class MainForm : Form
    {
        string numeAdmin;
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public MainForm(string n)
        {
            numeAdmin = n;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            label2.Text = numeAdmin;
            dateTimePickerOraPreluare.ShowUpDown = true;
            dateTimePickerOraPredare.ShowUpDown = true;
            dateTimePickerDataPredare.Value = dateTimePickerDataPreluare.Value.AddDays(2);

            dateTimePickerDataPreluare.Enabled = false;
            dateTimePickerDataPredare.Enabled = false;

            dateTimePickerOraPreluare.Enabled = false;
            dateTimePickerOraPredare.Enabled = false;

            checkBoxPreluare.Checked = true;
            checkBoxPredare.Checked = true;

            comboBoxPreluare.Items.Add("Orice locatie");
            comboBoxPredare.Items.Add("Orice locatie");
            comboBoxPreluare.SelectedIndex = 0;
            comboBoxPredare.SelectedIndex = 0;

            string[] statusuri = { "In desfasurare", "Anulata", "Rezervata" };
            comboBoxStatus.Items.AddRange(statusuri);

            comboBoxStatus.SelectedIndex = 0;

            dataGridviewDesign(dataGridView1);
            updateDisponibilitate();
            fillDataGridView();
            fillComboBoxes();
        }

        private void dataGridviewDesign(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ReadOnly = true;
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

        private void fillDataGridView()
        {

            SqlConnection conn = new SqlConnection(connect);
            try
            {
                conn.Open();
                string tabelDate = "select * from Inchirieri where Status = 'In desfasurare'";
                SqlDataAdapter da = new SqlDataAdapter(tabelDate, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Inchirieri");
                dataGridView1.DataSource = ds.Tables["Inchirieri"].DefaultView;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Inchirieri: {0}", ex.Message));
            }
        }

        private void updateDisponibilitate()
        {

            SqlConnection conn = new SqlConnection(connect);

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            try
            {
                conn.Open();

                string command = "update Masini set Masini.Status = 'Disponibila' from Masini, Inchirieri where Inchirieri.ID_Masina = Masini.ID_Masina and Inchirieri.Data_predare < '" + now + "'";
                SqlCommand sqlComand = new SqlCommand(command, conn);
                sqlComand.ExecuteNonQuery();

                command = "update Inchirieri set Status = 'Finalizata' where Data_predare < '" + now + "'";
                sqlComand = new SqlCommand(command, conn);
                sqlComand.ExecuteNonQuery();

                command = "update Inchirieri set Status = 'Rezervata' where Data_preluare > '" + now + "'";
                sqlComand = new SqlCommand(command, conn);
                sqlComand.ExecuteNonQuery();

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la update: {0}", ex.Message));
            }
        }

        private void fillComboBoxes()
        {

            SqlConnection conn = new SqlConnection(connect);

            try
            {
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
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la update: {0}", ex.Message));
            }
        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Doriti sa va delogati?", "Confirm", MessageBoxButtons.OKCancel);

            if (res == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            this.Hide();
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }


        private void filtrare(string lpr, string lpd, string dpr, string dpd, string status)
        {

            SqlConnection conn = new SqlConnection(connect);

            Console.WriteLine(lpr +", "+ lpd + ", " + dpr + ", " + dpd);

            if(dpr != "Orice data")
            {
                dpr = DateTime.ParseExact(dpr, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm");
            }
            if (dpd != "Orice data")
            {
                dpd = DateTime.ParseExact(dpd, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm");
            }

            try
            { 

            conn.Open();
            string command = "";

                if (lpr == "Orice locatie" && lpd == "Orice locatie")
                {
                    if (dpr == "Orice data" && dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '"+ status + "'";
                    }
                    else if (dpr == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_predare <= '" + dpd + "'";
                    }
                    else if (dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "'";
                    }
                    else
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and Data_predare <= '" + dpd + "'";
                    }
                }
                else if (lpr == "Orice locatie")
                {
                    if (dpr == "Orice data" && dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and ID_Locatie_predare = '" + lpd + "'";
                    }
                    else if (dpr == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_predare <= '" + dpd + "' and ID_Locatie_predare = '" + lpd + "'";
                    }
                    else if (dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and ID_Locatie_predare <= '" + lpd + "'";
                    }
                    else
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and Data_predare <= '" + dpd + "' and ID_Locatie_predare= '" + lpd + "'";
                    }
                }
                else if (lpd == "Orice locatie")
                {
                    if (dpr == "Orice data" && dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and ID_Locatie_preluare = '" + lpr + "'";
                    }
                    else if (dpr == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_predare <= '" + dpd + "' and ID_Locatie_preluare = '" + lpr + "'";
                    }
                    else if (dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and ID_Locatie_preluare = '" + lpr + "'";
                    }
                    else
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and Data_predare <= '" + dpd + "' and ID_Locatie_preluare = '" + lpr + "'";
                    }
                }
                else 
                {
                    if (dpr == "Orice data" && dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and ID_Locatie_preluare = '" + lpr + "' and ID_Locatie_predare= '" + lpd + "'";
                    }
                    else if (dpr == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_predare <= '" + dpd + "' and ID_Locatie_preluare = '" + lpr + "' and ID_Locatie_predare= '" + lpd + "'";
                    }
                    else if (dpd == "Orice data")
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and ID_Locatie_preluare = '" + lpr + "' and ID_Locatie_predare= '" + lpd + "'";
                    }
                    else
                    {
                        command = "select * from Inchirieri where Status = '" + status + "' and Data_preluare >= '" + dpr + "' and Data_predare <= '" + dpd + "' and ID_Locatie_preluare = '" + lpr + "' and ID_Locatie_predare= '" + lpd + "'";
                    }
                }
            SqlDataAdapter da = new SqlDataAdapter(command, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Inchirieri");
            dataGridView1.DataSource = ds.Tables["Inchirieri"].DefaultView;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            conn.Close(); 
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Inchirieri: {0}", ex.Message));
            }
        }

        private void buttonFiltrare_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connect);
            conn.Open();
            string command;
            SqlCommand sqlCommand;

            string locatiePreluare = "Orice locatie";
            string locatiePredare = "Orice locatie";
            
            string dataPreluare = "Orice data";
            string dataPredare = "Orice data";

            string status = comboBoxStatus.Text;

            if (comboBoxPreluare.Text != "Orice locatie")
            {
                try
                {
                    command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPreluare.Text + "'";
                    sqlCommand = new SqlCommand(command, conn);
                    int idPreluare = (int)sqlCommand.ExecuteScalar();
                    locatiePreluare = idPreluare.ToString();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
                }                
            }

            if (comboBoxPredare.Text != "Orice locatie")
            {
                try
                {
                    command = "select ID_Locatie from Locatii where Nume = '" + comboBoxPredare.Text + "'";
                    sqlCommand = new SqlCommand(command, conn);
                    int idPredare = (int)sqlCommand.ExecuteScalar();
                    locatiePredare = idPredare.ToString();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
                }
            }
            
            if(checkBoxPreluare.Checked == false)
            {
                dataPreluare = dateTimePickerDataPreluare.Text + " " + dateTimePickerOraPreluare.Text;

            }
            if (checkBoxPredare.Checked == false)
            {
                dataPredare = dateTimePickerDataPredare.Text + " " + dateTimePickerOraPredare.Text;
            }

            filtrare(locatiePreluare, locatiePredare, dataPreluare, dataPredare, status);
        }

        
        private void buttonInchiriere_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInchiriere f = new FormInchiriere(numeAdmin);
            f.ShowDialog();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Doriti sa inchideti aplicatia?",
                               "Confirm",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                    Environment.Exit(0);
                else
                    e.Cancel = true;
            }
        }

        private void checkBoxPreluare_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPreluare.Checked == true)
            {
                dateTimePickerDataPreluare.Enabled = false;
                dateTimePickerOraPreluare.Enabled = false;
            }
            else
            {
                dateTimePickerDataPreluare.Enabled = true;
                dateTimePickerOraPreluare.Enabled = true;
            }
        }

        private void checkBoxPredare_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPredare.Checked == true)
            {
                dateTimePickerDataPredare.Enabled = false;
                dateTimePickerOraPredare.Enabled = false;
            }
            else
            {
                dateTimePickerDataPredare.Enabled = true;
                dateTimePickerOraPredare.Enabled = true;
            }
        }
        private void buttonAnulareInchiriere_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAnulare f = new FormAnulare(numeAdmin);
            f.ShowDialog();
        }

        private void buttonAdaugareMasina_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdaugare f = new FormAdaugare(numeAdmin);
            f.ShowDialog();
        }

        private void buttonStatistici_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatistici f = new FormStatistici(numeAdmin);
            f.ShowDialog();
        }
        private void buttonResetareFiltre_Click(object sender, EventArgs e)
        {
            comboBoxPreluare.SelectedIndex = 0;
            comboBoxPredare.SelectedIndex = 0;

            dateTimePickerDataPreluare.Value = DateTime.Now;
            dateTimePickerDataPredare.Value = dateTimePickerDataPreluare.Value.AddDays(2);

            dateTimePickerOraPreluare.Value = DateTime.Parse("10:00");
            dateTimePickerOraPredare.Value = DateTime.Parse("12:00");

            checkBoxPreluare.Checked = true;
            checkBoxPredare.Checked = true;

            fillDataGridView();
        }
        private void dateTimePickerDataPredare_ValueChanged(object sender, EventArgs e)
        {
            DateTime ziPreluareDT = DateTime.Parse(dateTimePickerDataPreluare.Text);
            DateTime ziPredareDT = DateTime.Parse(dateTimePickerDataPredare.Text);
            int numarZile = (ziPredareDT - ziPreluareDT).Days;

            if (numarZile < 0)
            {
                MessageBox.Show("Ziua de predare nu poate fi mai devreme de ziua de preluare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerDataPredare.Value = dateTimePickerDataPreluare.Value.AddDays(2);
            }
        }
        class RandomDateTime
        {
            DateTime start;
            Random gen;
            int range;

            public RandomDateTime()
            {
                start = new DateTime(2021, 1, 1);
                gen = new Random();
                range = (DateTime.Today - start).Days;
            }

            public DateTime Next()
            {
                return start.AddDays(gen.Next(range)).AddHours(gen.Next(10, 24)).AddMinutes(gen.Next(0, 60));
            }
        }
    }
}
