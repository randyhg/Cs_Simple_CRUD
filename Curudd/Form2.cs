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
using System.Xml.Linq;

namespace Curudd
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NR11B30\SQLEXPRESS;Initial Catalog=pbd;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Isi dulu kocak!");
                return;
            }
            else if (OthersRadioButton.Checked)
            {
                MessageBox.Show("FUCK YALL SJW!");
                return;
            }
            else if (!MaleRadioButton.Checked && !FemaleRadioButton.Checked)
            {
                MessageBox.Show("Isi jenis kelamin!");
                return;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("UPDATE Mahasiswa SET name = @Name, email = @Email, birth = @Birth, sex = @Sex WHERE id = @ID");
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                cmd.Parameters.AddWithValue("@Birth", birth.Value);
                cmd.Parameters.AddWithValue("@Sex", MaleRadioButton.Checked ? "M" : "F");
                cmd.Parameters.AddWithValue("@ID", id.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                // Form2_Load(sender, e);

                MessageBox.Show("Sukses coy!");
                name.Text = "";
                email.Text = "";
                birth.Value = DateTime.Today;
                MaleRadioButton.Checked = false;
                FemaleRadioButton.Checked = false;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pbdDataSet1.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter1.Fill(this.pbdDataSet1.Mahasiswa);

        }
    }
}
