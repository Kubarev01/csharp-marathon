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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace практа_4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=U315-S7\\SQLEXPRESS07;Initial Catalog=marathon;User ID=egor;Password=egor;";

            if (string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Измененный SQL-запрос для получения id пользователя
                    string query = "SELECT id FROM USERS WHERE email = @email AND password = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметров запроса
                        command.Parameters.AddWithValue("@email", email.Text.Trim());
                        command.Parameters.AddWithValue("@password", password.Text.Trim()); // Рассмотрите возможность хеширования пароля

                        // Выполнение запроса
                        object result = command.ExecuteScalar(); // Получаем id пользователя

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result); // Преобразуем результат в int
                            MessageBox.Show("Успешный вход!");

                            this.Hide(); // Скрыть текущую форму
                            Form4 form = new Form4(userId); // Передаем id пользователя в Form4
                            form.ShowDialog(); // Показать новую форму как модальную
                        }
                        else
                        {
                            MessageBox.Show("Неверный адрес электронной почты или пароль.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
