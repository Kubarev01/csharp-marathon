using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace практа_4
{
    public partial class Form4 : Form
    {
        private int userId;

        public Form4(int userid)
        {
            InitializeComponent();
            this.userId = userid; // Сохраняем userId для дальнейшего использования
            LoadUserName();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadUserName()
        {
            string connectionString = "Server=U315-S7\\SQLEXPRESS07;Initial Catalog=marathon;User ID=egor;Password=egor;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL-запрос для получения first_name по userId
                    string query = "SELECT first_name FROM USERS WHERE id = @userId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId); // Добавление параметра userId

                        // Выполнение запроса и получение first_name
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string firstName = result.ToString(); // Преобразуем результат в строку
                            label1.Text ="Здравствуйте, "+firstName; // Устанавливаем текст в label1
                        }
                        else
                        {
                            label1.Text = "Имя не найдено"; // Если имя не найдено
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("+79525391889 - заместитель управляющего по марафоном Салаги Д.Н.");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Можно оставить пустым или добавить функционал при нажатии на label1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Можно добавить функционал для кнопки 1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(userId);
            this.Hide();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.ShowDialog();
        }
    }
}