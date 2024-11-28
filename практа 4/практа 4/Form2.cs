using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace практа_4
{
    public partial class Form2 : Form
    {
        private DateTime targetDate;
        private Timer timer; // Создаем экземпляр таймера

        public Form2()
        {
            InitializeComponent();
            targetDate = new DateTime(2024, 12, 1); // Установка целевой даты

            timer = new Timer(); // Инициализация таймера
            timer.Interval = 1000; // Интервал в миллисекундах (1000 мс = 1 секунда)
            timer.Tick += Timer1_Tick; // Подписка на событие Tick
            timer.Start(); // Запуск таймера
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan timeRemaining = targetDate - DateTime.Now; // Вычисление оставшегося времени

            if (timeRemaining.TotalSeconds > 0)
            {
                // Обновление текста Label с оставшимся временем
                label1.Text = string.Format("Осталось времени: {0:D2} дней {1:D2} часов {2:D2} минут {3:D2} секунд",
                    timeRemaining.Days, timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
            }
            else
            {
                label1.Text = "Время истекло!";
                timer.Stop(); // Остановка таймера
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            reg form = new reg();
            form.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }
    }
}
