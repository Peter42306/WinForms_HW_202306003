using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFirstLessonWithButtons
{
    public partial class Form6 : Form
    {
        DateTime newDateTimeToWait;
        public Form6()
        {
            InitializeComponent();

            // Устанавливаем дату и время, до которых мы будем ждать
            newDateTimeToWait = new DateTime(2023, 12, 31, 23, 59, 59);

            // Запускаем таймер 
            timer1.Start();
        }

        // Обработчик события таймера, срабатывает каждый раз, когда проходит указанный интервал времени
        // В нашем случае 1000 мс или 1 секунда выставлено в timer1 Properties
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Вычисляем оставшееся время до новой даты и времени
            TimeSpan timeRemained = newDateTimeToWait - DateTime.Now;

            // Отображаем на форме фиксированное время, до которого мы ждем
            label1.Text = $"Fixed time we wait: {newDateTimeToWait.ToString()}";

            // Отображаем оставшееся время в секундах
            string secondsRemained = Math.Floor(timeRemained.TotalSeconds).ToString();
            label2.Text = $"Remained time in seconds: {secondsRemained}";

            // Отображаем оставшееся время в часах
            string hoursRemained = Math.Floor(timeRemained.TotalHours).ToString();
            label3.Text = $"Remained time in hours: {hoursRemained}";

            // Отображаем оставшееся время в днях
            string daysRemained =Math.Floor(timeRemained.TotalDays).ToString();
            label4.Text = $"Remained time in days: {daysRemained}";            
        }

        // Обработчик события нажатия на button1
        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Обработчик события клика по label1
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
