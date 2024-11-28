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
    public partial class Form5 : Form
    {
        int userid;
        public Form5(int userid)
        {
            InitializeComponent();
            this.userid = userid;
            Console.WriteLine(this.userid);
            LoadUserData();
           
        }
        private void LoadUserData()
        {
            string connectionString = "Server=U315-S7\\SQLEXPRESS07;Initial Catalog=marathon;User ID=egor;Password=egor;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL-запрос для получения данных пользователя по userId
                    string query = "SELECT first_name, second_name, email, dateOfBirth, sex, country FROM users WHERE id = @userId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userid); // Добавление параметра userId

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Читаем данные из результата запроса
                            {
                                // Заполняем TextBox значениями из базы данных
                                first_name.Text = reader["first_name"].ToString();
                                last_name.Text = reader["second_name"].ToString();
                                email.Text = reader["email"].ToString();
                                sex.Text = reader["sex"].ToString() ;
                                country.Text = reader["country"].ToString();
                                dateOfBirth.Text = Convert.ToDateTime(reader["dateOfBirth"]).ToString("yyyy-MM-dd"); // Форматируем дату
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button2_click(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(userid);
            this.Hide();
            form.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=U315-S7\\SQLEXPRESS07;Initial Catalog=marathon;User ID=egor;Password=egor;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Начинаем транзакцию для обеспечения целостности данных
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;

                            // Обновляем имя, фамилию, email и дату рождения
                            command.CommandText = "UPDATE users SET first_name = @firstName, second_name = @lastName, email = @email, dateOfBirth = @dateOfBirth WHERE id = @userId";
                            command.Parameters.AddWithValue("@firstName", first_name.Text.Trim());
                            command.Parameters.AddWithValue("@lastName", last_name.Text.Trim()); ;
                            command.Parameters.AddWithValue("@email", email.Text.Trim());
                            command.Parameters.AddWithValue("@dateOfBirth", DateTime.Parse(dateOfBirth.Text));
                            command.Parameters.AddWithValue("@userId", userid);

                            // Выполняем обновление основных данных
                            command.ExecuteNonQuery();

                            // Проверяем поля для пароля
                            if (!string.IsNullOrWhiteSpace(password1.Text) && !string.IsNullOrWhiteSpace(password2.Text))
                            {
                                if (password1.Text == password2.Text) // Проверяем совпадение паролей
                                {
                                    // Обновляем пароль
                                    command.CommandText = "UPDATE users SET password = @password WHERE id = @userId";
                                    command.Parameters.Clear(); // Очищаем параметры перед новым запросом
                                    command.Parameters.AddWithValue("@password", password1.Text.Trim());
                                    command.Parameters.AddWithValue("@userId", userid);
                                    command.ExecuteNonQuery();
                                }
                                else
                                {
                                    MessageBox.Show("Пароли не совпадают. Пожалуйста, попробуйте еще раз.");
                                    return;
                                }
                            }

                            // Подтверждаем транзакцию
                            transaction.Commit();
                        }
                    }

                    MessageBox.Show("Данные успешно обновлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }
    }
}
