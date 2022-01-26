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
using System.Windows.Forms.DataVisualization.Charting;

namespace MTPproject
{
    public partial class FormStatistici : Form
    {
        string nAdmin;
        string connect = @"Data Source=MARIANS_LAPTOP;Initial Catalog=EvidentaLocar;Integrated Security=True";

        public FormStatistici(string n)
        {
            nAdmin = n;
            InitializeComponent();
        }
    
        public void fillGraphInchirieri(string an)
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                conn.Open();
                string command = "SELECT * FROM(SELECT datename(month, Data_predare) as 'Luni1', COUNT(*) AS 'Inchirieri in desfasurare' FROM Inchirieri where Status = 'In desfasurare' and YEAR(Data_predare) = '" + an + "' GROUP BY datename(month, Data_predare)) s1 " +
                                 "full join " +
                                 "(SELECT datename(month, Data_predare) as 'Luni2', COUNT(*) AS 'Inchirieri finalizate' FROM Inchirieri where Status = 'Finalizata' and YEAR(Data_predare) = '" + an + "' GROUP BY datename(month, Data_predare)) s2 " +
                                 "on s1.Luni1 = s2.Luni2 " +
                                 "full join (SELECT datename(month, Data_predare) as 'Luni3', COUNT(*) AS 'Inchirieri anulate' FROM Inchirieri where Status = 'Anulata' and YEAR(Data_predare) = '" + an + "' GROUP BY datename(month, Data_predare)) s3 " +
                                 "on s2.Luni2 = s3.Luni3 " +
                                 "full join (SELECT datename(month, Data_predare) as 'Luni4', COUNT(*) AS 'Inchirieri rezervate' FROM Inchirieri where Status = 'Rezervata' and YEAR(Data_predare) = '" + an + "' GROUP BY datename(month, Data_predare)) s4 " +
                                 "on s3.Luni3 = s4.Luni4";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                da.SelectCommand = sqlCommand;
                DataSet ds = new DataSet();
                da.Fill(ds);

                chartStatistici.DataSource = ds.Tables[0];

                chartStatistici.ChartAreas[0].AxisX.Maximum = 13;

                chartStatistici.ChartAreas[0].AxisX.Title = "Luni";
                chartStatistici.ChartAreas[0].AxisY.Title = "Inchirieri";

                chartStatistici.Series[0].YValueMembers = "Inchirieri in desfasurare";
                chartStatistici.Series[0].XValueMember = "Luni1";

                chartStatistici.Series[1].YValueMembers = "Inchirieri finalizate";
                chartStatistici.Series[1].XValueMember = "Luni2";

                chartStatistici.Series[2].YValueMembers = "Inchirieri anulate";
                chartStatistici.Series[2].XValueMember = "Luni3";

                chartStatistici.Series[3].YValueMembers = "Inchirieri rezervate";
                chartStatistici.Series[3].XValueMember = "Luni4";

                chartStatistici.DataBind();
                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Inchirieri: {0}", ex.Message));
            }
        }
        public void fillGraphMasini(string an)
        {

            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                conn.Open();

                string command = "";
                SqlCommand sqlCommand;

                command = "select count(*) from Masini where Status = 'Avariata'";
                sqlCommand = new SqlCommand(command, conn);
                int nrMasiniAvariate = (int)sqlCommand.ExecuteScalar();

                command = "select count(*) from Masini where Status = 'Disponibila'";
                sqlCommand = new SqlCommand(command, conn);
                int nrMasiniInStareBuna = (int)sqlCommand.ExecuteScalar();

                chartMasini.Series[0].Points.AddXY("Masini avariate", nrMasiniAvariate);
                chartMasini.Series[0].Points.AddXY("Masini in stare buna", nrMasiniInStareBuna);

                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Inchirieri: {0}", ex.Message));
            }
        }
        public void fillGraphIncasari(string an)
        {

            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                conn.Open();
                string command = "select datename(month ,Data_predare) as 'Luni', sum(Cost) as 'Incasari' from Inchirieri where Status = 'Finalizata' and year(Data_predare) = '"+an+"'  group by datename(month ,Data_predare)";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                da.SelectCommand = sqlCommand;
                DataSet ds = new DataSet();
                da.Fill(ds);

                chartIncasari.DataSource = ds.Tables[0];

                chartIncasari.ChartAreas[0].AxisX.Title = "Luni";
                chartIncasari.ChartAreas[0].AxisY.Title = "Incasari";

                chartIncasari.Series[0].YValueMembers = "Incasari";
                chartIncasari.Series[0].XValueMember = "Luni";

                chartIncasari.Series[1].YValueMembers = "Incasari";
                chartIncasari.Series[1].XValueMember = "Luni";

                chartStatistici.DataBind();
                conn.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("A avut loc o eroare la interogare Inchirieri: {0}", ex.Message));
            }
        }
        private void FormStatistici_Load(object sender, EventArgs e)
        {
            numericUpDownAnInchirieri.Value = DateTime.Now.Year;
            string an = DateTime.Now.Year.ToString();
            fillGraphInchirieri(an);
            fillGraphMasini(an);
            fillGraphIncasari(an);

            numericUpDownAnInchirieri.Maximum = DateTime.Now.Year;
            numericUpDownAnIncasari.Maximum = DateTime.Now.Year;
        }

        private void FormStatistici_FormClosing(object sender, FormClosingEventArgs e)
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

        private void numericUpDownAn_ValueChanged(object sender, EventArgs e)
        {   
            fillGraphInchirieri(numericUpDownAnInchirieri.Value.ToString());
        }
        private void numericUpDownAnIncasari_ValueChanged(object sender, EventArgs e)
        {
            fillGraphIncasari(numericUpDownAnIncasari.Value.ToString());
        }
        private void buttonNextInchirieri_Click(object sender, EventArgs e)
        {
            panelTop2.BringToFront();
            panelChartMasini.BringToFront();
        }

        private void buttonInapoiMasini_Click(object sender, EventArgs e)
        {
            panelTop1.BringToFront();
            panelChartInchirieri.BringToFront();
        }

        private void buttonNextMasini_Click(object sender, EventArgs e)
        {
            panelTop3.BringToFront();
            panelChartIncasari.BringToFront();
        }

        private void buttonInapoiIncasari_Click(object sender, EventArgs e)
        {
            panelTop2.BringToFront();
            panelChartMasini.BringToFront();
        }
    }
}
