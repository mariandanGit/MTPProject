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
    public partial class LoginForm : Form
    {
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBoxUtilizator.Text = "admin@locar.com";
            textBoxParola.Text = "parola";
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm f = new RegisterForm();
            f.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);

            string numeAdmin = "";
            string parola = "";
            bool utilizatorExistent = false;

            if (textBoxUtilizator.Text == "" && textBoxParola.Text == "")
            {
                MessageBox.Show("Introduceti date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxUtilizator.Text == "")
            {
                MessageBox.Show("Introduceti email!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxParola.Text == "")
            {
                MessageBox.Show("Introduceti parola!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                conn.Open();

                string command = "select * from Admini where Email = '" + textBoxUtilizator.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    numeAdmin = sqlDataReader["Nume"].ToString().Trim() + " " + sqlDataReader["Prenume"].ToString().Trim();
                    parola = sqlDataReader["Parola"].ToString();
                    utilizatorExistent = true;
                }
                if (utilizatorExistent)
                {
                    if (Criptare.Decrypt(parola).Equals(textBoxParola.Text))
                    {
                        this.Hide();
                        MainForm f = new MainForm(numeAdmin);
                        f.ShowDialog();
                    }
                    else
                    {
                        textBoxParola.Text = "";
                        MessageBox.Show("Parola incorecta!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    textBoxUtilizator.Text = "";
                    MessageBox.Show("Email utilizator incorect sau utilizator inexistent!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la logare: {0}", ex.Message));
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Gold;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
    }
}
