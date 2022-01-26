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
    public partial class FormAnulare : Form
    {
        string nAdmin;
        int inchiriereSelectata = -1;
        int idInchiriere = -1;
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public FormAnulare(string n)
        {
            nAdmin = n;
            InitializeComponent();
        }

        private void FormAnulare_Load(object sender, EventArgs e)
        {
            dataGridviewDesign(dataGridViewInchirieri);
            fillDataGridView();
            string[] motiveAnulare = { "Cerere client", "Masina avariata", "Alt motiv" };
            comboBoxMotivAnulare.Items.AddRange(motiveAnulare);
        }
        private void fillDataGridView()
        {
            SqlConnection conn = new SqlConnection(connect);

            try
            {
                conn.Open();

                string command = "select * from Inchirieri where Status = 'In desfasurare'";
                SqlDataAdapter da = new SqlDataAdapter(command, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Inchirieri");
                dataGridViewInchirieri.DataSource = ds.Tables["Inchirieri"].DefaultView;
                dataGridViewInchirieri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewInchirieri.MultiSelect = false;

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la update Inchirieri: {0}", ex.Message));
            }            
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
        private void dataGridViewInchirieri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inchiriereSelectata = dataGridViewInchirieri.CurrentCell.RowIndex;
            idInchiriere = Int32.Parse(dataGridViewInchirieri.Rows[inchiriereSelectata].Cells[0].Value.ToString());
        }

        private void buttonAnulare_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect);
            string command = "";
            SqlCommand sqlCommand;

            if(inchiriereSelectata != -1)
            {
                if (MessageBox.Show("Doriti sa anulati inchirierea?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    if(comboBoxMotivAnulare.Text == "")
                    {
                        try
                        {
                            conn.Open();

                            command = "update Inchirieri set Status = 'Anulata' where ID_Inchiriere= '" + idInchiriere + "'";
                            sqlCommand = new SqlCommand(command, conn);
                            sqlCommand.ExecuteNonQuery();

                            conn.Close();
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(string.Format("A avut loc o eroare la update Inchirieri: {0}", ex.Message));
                        }
                        if(comboBoxMotivAnulare.Text == "Masina avariata")
                        {
                            try
                            {
                                conn.Open();

                                command = "update Masini set Masini.Status = 'Avariata' from Masini, Inchirieri where Inchirieri.ID_Inchiriere = '" + idInchiriere + "' and Inchirieri.ID_Masina = Masini.ID_Masina";
                                sqlCommand = new SqlCommand(command, conn);
                                sqlCommand.ExecuteNonQuery();

                                conn.Close();
                                MessageBox.Show("Anulare realizata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MainForm f = new MainForm(nAdmin);
                                f.ShowDialog();
                            }
                            catch (SystemException ex)
                            {
                                MessageBox.Show(string.Format("A avut loc o eroare la update Masini: {0}", ex.Message));
                            }
                        }
                        else
                        {
                            try
                            {
                                conn.Open();

                                command = "update Masini set Masini.Status = 'Disponibila' from Masini, Inchirieri where Inchirieri.ID_Inchiriere = '" + idInchiriere + "' and Inchirieri.ID_Masina = Masini.ID_Masina";
                                sqlCommand = new SqlCommand(command, conn);
                                sqlCommand.ExecuteNonQuery();

                                conn.Close();
                                MessageBox.Show("Anulare realizata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MainForm f = new MainForm(nAdmin);
                                f.ShowDialog();
                            }
                            catch (SystemException ex)
                            {
                                MessageBox.Show(string.Format("A avut loc o eroare la update Masini: {0}", ex.Message));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selectati motivul anularii!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectati o inchiriere!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAnulare_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
