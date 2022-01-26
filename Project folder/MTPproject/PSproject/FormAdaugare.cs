using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTPproject
{
    public partial class FormAdaugare : Form
    {
        string nAdmin;
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public FormAdaugare(string n)
        {
            nAdmin = n;
            InitializeComponent();
        }
        private void FormAdaugare_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);
            string command;
            SqlCommand sqlCommand;
            SqlDataReader sqlReader;

            panelMenu1.BackColor = Color.WhiteSmoke;
            panelMenu2.BackColor = Color.Gold;
            panelMenu3.BackColor = Color.Gold;

            string[] categorii = { "Mici", "Medii", "Mari", "Monovolum", "Premium" };
            comboBoxCategorie.Items.AddRange(categorii);

            string[] tipTransmisie = { "Manuala", "Automata" };
            comboBoxTransmisie.Items.AddRange(tipTransmisie);

            string[] tipCombustibil = { "Motorina", "Benzina", "Electrica" };
            comboBoxCombustibil.Items.AddRange(tipCombustibil);

            try
            {
                conn.Open();
                command = "select * from Locatii";
                sqlCommand = new SqlCommand(command, conn);
                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBoxLocatie.Items.Add(sqlReader["Nume"].ToString());
                }

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
            }
            comboBoxTara.Items.AddRange(GetAllCountryNames().ToArray());
        }
        public static List<string> GetAllCountryNames()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            var rez = cultures.Select(cult => (new RegionInfo(cult.LCID)).EnglishName).Distinct().OrderBy(q => q).ToList();

            return rez;
        }

        private void FormAdaugare_FormClosing(object sender, FormClosingEventArgs e)
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

        private void buttonNext1_Click(object sender, EventArgs e)
        {
            panelMenu1.BackColor = Color.Gold;
            panelMenu2.BackColor = Color.WhiteSmoke;
            panelMenu3.BackColor = Color.Gold;

            panelAdaugareClient.BringToFront();
        }
        private void buttonPrevious2_Click(object sender, EventArgs e)
        {
            panelMenu1.BackColor = Color.WhiteSmoke;
            panelMenu2.BackColor = Color.Gold;
            panelMenu3.BackColor = Color.Gold;

            panelAdaugareMasina.BringToFront();
        }
        private void buttonNext2_Click(object sender, EventArgs e)
        {
            panelMenu1.BackColor = Color.Gold;
            panelMenu2.BackColor = Color.Gold;
            panelMenu3.BackColor = Color.WhiteSmoke;

            panelAdaugareLocatie.BringToFront();
        }

        private void buttonPrevious3_Click(object sender, EventArgs e)
        {
            panelMenu1.BackColor = Color.Gold;
            panelMenu2.BackColor = Color.WhiteSmoke;
            panelMenu3.BackColor = Color.Gold;

            panelAdaugareClient.BringToFront();
        }

        private void buttonPathPoza_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath + "\\ImaginiMasini";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathImagine = Path.GetFileName(fileDialog.FileName);
                textBoxPath.Text = pathImagine;
            }
        }
        private void clearInputs()
        {
            try
            {
                if(this.Controls.GetChildIndex(panelAdaugareMasina) == 0)
                {
                    foreach (Control c in panelDataMasini.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                        else if (c is ComboBox)
                        {
                            c.Text = "";
                        }
                        else if (c is NumericUpDown)
                        {
                            if (c.Name == "numericUpDownPret")
                            {
                                c.Text = "100,00";
                            }
                            else c.Text = "0";
                        }
                    }
                }
                if (this.Controls.GetChildIndex(panelAdaugareClient) == 0)
                {
                    foreach (Control c in panelDataClient.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                        if (c is ComboBox)
                        {
                            c.Text = "";
                        }
                    }
                }
                if (this.Controls.GetChildIndex(panelAdaugareLocatie) == 0)
                {
                    foreach (Control c in panelDataLocatie.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                    }
                }

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la Clear: {0}", ex.Message));
            }
        }
        public bool emailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void buttonAdaugareMasina_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);
            string command;
            SqlCommand sqlCommand;
            SqlDataReader sqlReader;

            string marca = textBoxMarca.Text;
            string model = textBoxModel.Text;
            string categorie = comboBoxCategorie.Text;
            string poza = textBoxPath.Text;
            string transmisie = comboBoxTransmisie.Text;
            string combustibil = comboBoxCombustibil.Text;
            bool aerConditionat = false;
            if (checkBoxAerConditionat.Checked)
            {
                aerConditionat = true;
            }
            decimal nrLocuri = numericUpDownLocuri.Value;
            decimal nrBagaje = numericUpDownBagaje.Value;
            float pret = float.Parse(numericUpDownPret.Value.ToString());
            string status = "Disponibila";
            int idLocatie = -1;

            if (textBoxMarca.Text == "")
            {
                MessageBox.Show("Introduceti marca!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxModel.Text == "")
            {
                MessageBox.Show("Introduceti model!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxCategorie.Text == "")
            {
                MessageBox.Show("Selectati categorie!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPath.Text == "")
            {
                MessageBox.Show("Introduceti path imagine!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxTransmisie.Text == "")
            {
                MessageBox.Show("Selectati transmisie!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxCombustibil.Text == "")
            {
                MessageBox.Show("Selectati combustibil!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxLocatie.Text == "")
            {
                MessageBox.Show("Selectati locatie!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    command = "select ID_Locatie from Locatii where Nume = '" + comboBoxLocatie.Text + "'";
                    sqlCommand = new SqlCommand(command, conn);
                    sqlCommand.ExecuteScalar();
                    idLocatie = (int)sqlCommand.ExecuteScalar();
                    conn.Close();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("A avut loc o eroare la interogare Locatii: {0}", ex.Message));
                }
                try
                {
                    conn.Open();

                    command = "insert into Masini ([Marca], [Model], [Categorie], [Poza], [Transmisie],[Combustibil]," +
                        " [Aer_conditionat], [Nr_locuri], [Nr_bagaje], [Pret_per_zi],[Status], [ID_Locatie]) " +
                        "values(@marca, @model, @categorie, @poza, @transmisie, @combustibil, @aerConditionat," +
                        " @nrLocuri, @nrBagaje, @pret, @status, @idLocatie)";
                    sqlCommand = new SqlCommand(command, conn);

                    sqlCommand.Parameters.AddWithValue("@marca", marca);
                    sqlCommand.Parameters.AddWithValue("@model", model);
                    sqlCommand.Parameters.AddWithValue("@categorie", categorie);
                    sqlCommand.Parameters.AddWithValue("@poza", poza);
                    sqlCommand.Parameters.AddWithValue("@transmisie", transmisie);
                    sqlCommand.Parameters.AddWithValue("@combustibil", combustibil);
                    sqlCommand.Parameters.AddWithValue("@aerConditionat", aerConditionat);
                    sqlCommand.Parameters.AddWithValue("@nrLocuri", nrLocuri);
                    sqlCommand.Parameters.AddWithValue("@nrBagaje", nrBagaje);
                    sqlCommand.Parameters.AddWithValue("@pret", pret);
                    sqlCommand.Parameters.AddWithValue("@status", status);
                    sqlCommand.Parameters.AddWithValue("@idLocatie", idLocatie);
                    sqlCommand.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Masina inregistrata in baza de date!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearInputs();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("A avut loc o eroare la insertie in Masini: {0}", ex.Message));
                }
            }
        }

        private void buttonAdaugareClient_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);
            string command;
            SqlCommand sqlCommand;
            SqlDataReader sqlReader;

            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            DateTime dataNasterii = DateTime.Parse(dateTimePickerDataNasterii.Text);
            int an = DateTime.Now.Year;
            int varsta = an - dateTimePickerDataNasterii.Value.Year;
            string telefon = textBoxTelefon.Text;
            string email = textBoxEmail.Text;
            string tara = comboBoxTara.Text;
            string adresa = textBoxAdresa.Text;
            string oras = textBoxOras.Text;

            if (textBoxNume.Text == "")
            {
                MessageBox.Show("Introduceti nume!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPrenume.Text == "")
            {
                MessageBox.Show("Introduceti prenume!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (varsta < 18)
            {
                MessageBox.Show("Clientul nu poate avea o varsta mai mica de 18 ani!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxTelefon.Text == "")
            {
                MessageBox.Show("Introduceti telefon!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Introduceti email!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxTara.Text == "")
            {
                MessageBox.Show("Introduceti tara!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxOras.Text == "")
            {
                MessageBox.Show("Introduceti oras!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxAdresa.Text == "")
            {
                MessageBox.Show("Introduceti adresa!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (emailIsValid(email))
                {
                    try
                    {
                        conn.Open();

                        command = "insert into Clienti ([Nume], [Prenume], [Data_nastere], [Telefon], [Email],[Adresa]," +
                            " [Oras], [Tara]) " +
                            "values(@nume, @prenume, @dataNasterii, @telefon, @email, @adresa," +
                            " @oras, @tara)";
                        sqlCommand = new SqlCommand(command, conn);

                        sqlCommand.Parameters.AddWithValue("@nume", nume);
                        sqlCommand.Parameters.AddWithValue("@prenume", prenume);
                        sqlCommand.Parameters.AddWithValue("@dataNasterii", dataNasterii);
                        sqlCommand.Parameters.AddWithValue("@telefon", telefon);
                        sqlCommand.Parameters.AddWithValue("@email", email);
                        sqlCommand.Parameters.AddWithValue("@adresa", adresa);
                        sqlCommand.Parameters.AddWithValue("@oras", oras);
                        sqlCommand.Parameters.AddWithValue("@tara", tara);
                        sqlCommand.ExecuteNonQuery();

                        conn.Close();
                        MessageBox.Show("Client inregistrat in baza de date!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearInputs();
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(string.Format("A avut loc o eroare la insertie in Clienti: {0}", ex.Message));
                    }
                }
                else
                {
                    MessageBox.Show("Email-ul este incorect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonAdaugareLocatie_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);
            string command;
            SqlCommand sqlCommand;
            SqlDataReader sqlReader;

            string nume = textBoxNumeLocatie.Text;
            string adresa = textBoxAdresaLocatie.Text;
            string oras = textBoxOrasLocatie.Text;
            string codPostal = textBoxCodPostal.Text;

            if (textBoxNumeLocatie.Text == "")
            {
                MessageBox.Show("Introduceti nume!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxAdresaLocatie.Text == "")
            {
                MessageBox.Show("Introduceti adresa!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxOrasLocatie.Text == "")
            {
                MessageBox.Show("Introduceti oras!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxCodPostal.Text == "")
            {
                MessageBox.Show("Introduceti cod postal!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();

                    command = "insert into Locatii ([Nume], [Adresa], [Oras], [Cod_postal]) " +
                        "values(@nume, @adresa, @oras, @codPostal)";
                    sqlCommand = new SqlCommand(command, conn);

                    sqlCommand.Parameters.AddWithValue("@nume", nume);
                    sqlCommand.Parameters.AddWithValue("@adresa", adresa);
                    sqlCommand.Parameters.AddWithValue("@oras", oras);
                    sqlCommand.Parameters.AddWithValue("@codPostal", codPostal);
                    sqlCommand.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Locatie inregistrata in baza de date!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearInputs();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("A avut loc o eroare la insertie in Locatii: {0}", ex.Message));
                }
            }
        }
    }
}
