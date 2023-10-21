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

namespace Curudd
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NR11B30\SQLEXPRESS;Initial Catalog=pbd;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pbdDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.pbdDataSet.Mahasiswa);

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namee.Text) || string.IsNullOrEmpty(emaill.Text))
            {
                MessageBox.Show("Isi dulu kocak!");
                return;
            }
            else if (othersRadioButton.Checked)
            {
                MessageBox.Show("FUCK YALL SJW!");
                return;
            }
            else if (!maleRadioButton.Checked && !femaleRadioButton.Checked)
            {
                MessageBox.Show("Isi jenis kelamin!");
                return;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertMahasiswa";
                // cmd.CommandType = CommandType.Text;
                // cmd.CommandText = ("INSERT INTO Mahasiswa (name, email, birth, sex) VALUES (@Name, @Email, @Birth, @Sex)");
                cmd.Parameters.AddWithValue("@Name", namee.Text);
                cmd.Parameters.AddWithValue("@Email", emaill.Text);
                cmd.Parameters.AddWithValue("@Birth", birthh.Value);
                cmd.Parameters.AddWithValue("@Sex", maleRadioButton.Checked ? "M" : "F");
                cmd.ExecuteNonQuery();
                conn.Close();

                Form1_Load(sender, e);

                MessageBox.Show("Sukses coy!");
                namee.Text = "";
                emaill.Text = "";
                birthh.Value = DateTime.Today;
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = false;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
