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

namespace практа_4
{
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=U315-S7\\SQLEXPRESS07;Initial Catalog=marathon;User ID=egor;Password=egor;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (password1.Text == password2.Text)
                {
                    try
                    {
                        connection.Open();

                        string query = "INSERT INTO users (is_runner, first_name, second_name, is_admin, is_sponsor, email, password, sex, dateOfBirth, country) VALUES (@is_runner, @first_name, @second_name, @is_admin, @is_sponsor, @email, @password, @sex, @dateOfBirth, @country)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@first_name", first_name.Text);
                            command.Parameters.AddWithValue("@is_runner", 1);
                            command.Parameters.AddWithValue("@is_sponsor", 2);
                            command.Parameters.AddWithValue("@is_admin", 1);
                            command.Parameters.AddWithValue("@second_name", last_name.Text);
                            command.Parameters.AddWithValue("@email", email.Text);
                            command.Parameters.AddWithValue("@password", password1.Text);
                            command.Parameters.AddWithValue("@sex", sex.Text);
                            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth.Text);
                            command.Parameters.AddWithValue("@country", Country.Text);


                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Пользователь успешно зарегистрирован!");
                                this.Hide();
                                Form3 form = new Form3();
                                form.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка при регистрации пользователя.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка: " + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
               
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
