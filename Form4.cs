using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFirstLessonWithButtons
{
    public partial class Form4 : Form
    {
        private Random random = new Random(); // Создаем экземпляр генератора случайных чисел

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MoveButtonToRandomPosition(); // При загрузке формы перемещаем кнопку в случайное положение
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundWhenClick(); // издаём бип при нажатии
            MoveButtonToRandomPosition(); // При клике на кнопку перемещаем ее в случайное положение
        }
        private void MoveButtonToRandomPosition()
        {
            int maxPositionX = ClientSize.Width - button1.Width; // Максимальная позиция по X, учитывая длину кнопки
            int maxPositionY = ClientSize.Height - button1.Height; // Максимальная позиция по Y, учитывая высоту кнопки

            int newPositionX = random.Next(maxPositionX); // Генерируем случайное значение X
            int newPositionY = random.Next(maxPositionY); // Генерируем случайное значение Y

            button1.Location = new Point(newPositionX, newPositionY); // Устанавливаем новое положение кнопки
        }
        private void SoundWhenClick()
        {
            Console.Beep(); // издаём бип
        }
    }
}
