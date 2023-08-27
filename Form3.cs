using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ДЗ от 2023 06 03
// Задание 1
// работа с мышкой: 
// 1) реализовать приложение, которое выглядит так же как,
// задание -рисование кнопками.exe

namespace WinFormsFirstLessonWithButtons
{
    public partial class Form3 : Form
    {
        // Поля для работы с кнопкой и координатами кнопки
        private Button newButton;
        private Point startPointForNewButton;
        private bool isResizingInProgress = false;

        // Создание экземпляра Random для генерации случайных чисел при выводе уцета кнопки
        Random random = new Random();

        // Счетчик созданных кнопок
        int countOfButtons = 0;

        public Form3()
        {
            InitializeComponent();
        }

        // Обработчик события загрузки формы
        private void Form3_Load(object sender, EventArgs e)
        {
            // Обработчики событий мыши
            this.MouseDown += Form3_MouseDown; // нажатие
            this.MouseMove += Form3_MouseMove; // ведение по форме
            this.MouseUp += Form3_MouseUp; // отпускаем
        }

        // Обработчик события отпускания кнопки мыши
        private void Form3_MouseUp(object? sender, MouseEventArgs e)
        {
            if (newButton != null) // Проверяем, была ли создана новая кнопка
            {
                isResizingInProgress = false; // Завершаем процесс изменения размера кнопки
                newButton = null; // Обнуляем ссылку на созданную кнопку
            }
        }

        // Обработчик события перемещения мыши
        private void Form3_MouseMove(object? sender, MouseEventArgs e)
        {
            if (newButton != null)
            {
                if (!isResizingInProgress)
                {
                    // Вычисляем новые размеры кнопки на основе координат
                    int buttonWidth = e.X - startPointForNewButton.X;
                    int buttonHeight = e.Y - startPointForNewButton.Y;
                    newButton.Size = new Size(buttonWidth, buttonHeight);
                }
            }
        }

        // Обработчик события нажатия кнопки мыши
        private void Form3_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // проверка, нажата ли левая клавиша мыши
            {                
                newButton = CreateNewButton(); // Создаем новую кнопку 
                startPointForNewButton = e.Location; //сохраняем координаты мыши при нажатии 
                newButton.Location = startPointForNewButton; // устанавливаем координаты для новой кнопки
                this.Controls.Add(newButton); // добавляем кнопку на форму
                countOfButtons++; // увеличиваем счётчик кнопок
            }
        }

        // Метод для создания новой кнопки
        private Button CreateNewButton()
        {
            Button button = new Button();

            // Добавляем обработчики событий для созданной кнопки
            button.MouseDown += Button_MouseDown;
            button.MouseUp += Button_MouseUp;

            // Устанавливаем текст на кнопке
            button.Text = (countOfButtons + 1).ToString();

            // Генерируем случайный цвет для фона кнопки
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            button.BackColor = randomColor;

            return button;
        }

        // Обработчик события отпускания кнопки мыши на созданной кнопке
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // проверяем отпущена ли кнопка
            {
                isResizingInProgress = true; // если да, идёт процесс изменения размера кнопки
                startPointForNewButton = e.Location; // устанавливаются координаты новой кнопки
            }
        }

        // Обработчик события нажатия кнопки мыши на созданной кнопке
        private void Button_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // проверяем, нажатали левыя кнопка мыши
            {
                isResizingInProgress = false; // если да, заканчивается процесс изменения размера кнопки
            }
        }
    }
}
