using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTPproject
{
    public partial class RegisterForm : Form
    {
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public RegisterForm()
        {
            InitializeComponent();
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
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);

            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            DateTime dataNasterii = dateTimePicker1.Value;
            string email = textBoxEmail.Text;
            string parola = textBoxParola.Text;
            string confirmareParola = textBoxConfirmareParola.Text;

            conn.Open();

            string command = "select count(1) from Admini where Email = '" + email + "'";

            SqlCommand sqlCommand = new SqlCommand(command, conn);
            int userCount = (int)sqlCommand.ExecuteScalar();

            int n = 0;
            if (userCount == 0)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        if (textBox.Text == string.Empty)
                        {
                            n++;
                        }
                    }
                }

                if(n == 0)
                {
                    if (emailIsValid(email))
                    {
                        if (parola == confirmareParola)
                        {
                            try
                            {
                                parola = Criptare.Encrypt(parola);

                                command = "insert into Admini ([Nume], [Prenume], [Data_nastere], [Email], [Parola]) values(@nume, @prenume, @dataNastere, @email, @parola)";
                                sqlCommand = new SqlCommand(command, conn);

                                sqlCommand.Parameters.AddWithValue("@nume", nume);
                                sqlCommand.Parameters.AddWithValue("@prenume", prenume);
                                sqlCommand.Parameters.AddWithValue("@dataNastere", dataNasterii);
                                sqlCommand.Parameters.AddWithValue("@email", email);
                                sqlCommand.Parameters.AddWithValue("@parola", parola);
                                sqlCommand.ExecuteNonQuery();

                                MessageBox.Show("Ati fost inregistrat cu succes!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Hide();
                                LoginForm f = new LoginForm();
                                f.ShowDialog();
                            }
                            catch (SystemException ex)
                            {
                                MessageBox.Show(string.Format("A avut loc o eroare la insertie in Admini: {0}", ex.Message));
                            }
                        }
                        else
                        {
                            textBoxParola.Text = "";
                            textBoxConfirmareParola.Text = "";
                            MessageBox.Show("Parolele nu corespund!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        textBoxEmail.Text = "";
                        MessageBox.Show("Email-ul este incorect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(textBoxNume.Text == "")
                {
                    MessageBox.Show("Introduceti nume!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxPrenume.Text == "")
                {
                    MessageBox.Show("Introduceti prenume!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker1.Value.Year > 2006)
                {
                    MessageBox.Show("Varsta minima este 16 ani!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxEmail.Text == "")
                {
                    MessageBox.Show("Introduceti email!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxParola.Text == "")
                {
                    MessageBox.Show("Introduceti parola!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxConfirmareParola.Text == "")
                {
                    MessageBox.Show("Introduceti parola de confirmare!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Introduceti date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Un utilizator foloseste deja aceasta adresa de email!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Doriti sa iesiti?",
                               "Confirm",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Hide();
                    LoginForm f = new LoginForm();
                    f.ShowDialog();
                }

                else
                    e.Cancel = true;
            }
        }
    }
}
