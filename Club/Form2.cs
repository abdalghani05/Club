using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Club
{
    public partial class Form2 : Form
    {
        SqlConnection cnx = new SqlConnection("server=DESKTOP-SRN5SP1;database=Club;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnx;
            cmd.CommandText = "";
            cnx.Open();

            cmd.CommandText = "select NomSupport from Supports_Film where NumFilm=" + textBox1.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Exemplaire(NumFilm,CodExe,DateAcquisition,NomSupport)values(@NF,@CE,@DA,@NS)";
            cmd.Parameters.AddWithValue("@NF", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@CE", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@NS",comboBox1.Text);
            cmd.Parameters.AddWithValue("@DA", textBox3.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Exemplaire est Enregistrer ");
        }
    }
}
