using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
* Задание №2
* 
* Используя Windows Forms, разработать игру «Угадай число». 
* Компьютер загадывает число от 1 до 100, а человек пытается его угадать 
* за минимальное число попыток. Для ввода данных от человека используется элемент TextBox.
* 
* Панов Алексей
*/
namespace Task_2
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            Reset();
            }

        int number;
        private void StartGame()
            {
            Random rnd = new Random();
            number = rnd.Next(0, 101);
            }

        private void Reset()
            {
            lblTryNumb.Text = "0";
            tbInput.Text = null;
            lblHelp.Text = "Угадай число\r\nот 1 до 100";
            StartGame();
            }

        private void btnReset_Click(object sender, EventArgs e)
            {
            Reset();
            }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
            {
            if(e.KeyCode == Keys.Enter)
                {
                if(!int.TryParse(tbInput.Text, out int n))
                    {
                    lblHelp.Text = "Мне бы число";
                    return;
                    }

                if(number == n)
                    lblHelp.Text = $"Угадал!!!\r\n Это {n}";
                else if(number > n)
                    lblHelp.Text = "Число больше";
                else
                    lblHelp.Text = "Число меньше";

                tbInput.Text = null;
                lblTryNumb.Text = (int.Parse(lblTryNumb.Text)+1).ToString();
                }
            }
        }
    }
