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
    public partial class Form1 : Form
    {
        SqlConnection cnx = new SqlConnection("server=DESKTOP-SRN5SP1;database=Club;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnx;
            cmd.CommandText = "";
            cnx.Open();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into Film values(@num,@titre,@annee,@duree,@nbrcoscar,@resume,@prix)";
                cmd.Parameters.AddWithValue("@num", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@titre", textBox2.Text);
                cmd.Parameters.AddWithValue("@annee", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@duree", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@nbrcoscar", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@prix", float.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@resume", textBox7.Text);
                cmd.ExecuteNonQuery();
                if (Cassette.Checked)
                {
                    cmd.Parameters.AddWithValue("@support", Cassette.Text);
                    cmd.CommandText = "insert into Supports_Film values(@num,@support)";
                    cmd.ExecuteNonQuery();
                }
                if (CD.Checked)
                {
                    cmd.Parameters.AddWithValue("@supportcd", CD.Text);
                    cmd.CommandText = "insert into Supports_Film values(@num,@supportcd)";
                    cmd.ExecuteNonQuery();
                }
                if (DVD.Checked)
                {
                    cmd.Parameters.AddWithValue("@supportdvd", DVD.Text);
                    cmd.CommandText = "insert into Supports_Film values(@num,@supportdvd)";
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("le film est ajoute");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExemplaires_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.textBox1.Text = textBox1.Text;
            f2.ShowDialog();
        }
    }
}
