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
* Задание №1
* 
* а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
* б) Добавить меню и команду «Играть». При нажатии появляется сообщение, 
*    какое число должен получить игрок. Игрок должен постараться получить 
*    это число за минимальное количество ходов.
* в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
* 
* Панов Алексей
*/
namespace Task_1
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            Reset();
            }

        int x;
        List<int> backNumber = new List<int>();

        private void btnCommand1_Click(object sender, EventArgs e)
            {
            int temp = (int.Parse(lblNumber.Text) + 1);
            lblNumber.Text = temp.ToString();
            lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
            backNumber.Add(temp);
            }

        private void btnCommand2_Click(object sender, EventArgs e)
            {
            int temp = (int.Parse(lblNumber.Text) * 2);
            lblNumber.Text = temp.ToString();
            lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
            backNumber.Add(temp);
            }
        private void btnCommand3_Click(object sender, EventArgs e)
            {
            int temp = (int.Parse(lblNumber.Text) - 1);
            if(temp<0) return;

            lblNumber.Text = temp.ToString();
            lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
            backNumber.Add(temp);
            }

        private void btnCommand4_Click(object sender, EventArgs e)
            {
            int temp = (int.Parse(lblNumber.Text) / 2);
            if(temp <= 0) return;

            lblNumber.Text = temp.ToString();
            lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
            backNumber.Add(temp);
            }
        private void btnRevert_Click(object sender, EventArgs e)
            {
            if(backNumber.Count==0||backNumber.Count-1==0)
                {
                return;
                }
            backNumber.Remove(backNumber[backNumber.Count - 1]);
            lblNumber.Text = backNumber[backNumber.Count - 1].ToString();
            lblCount.Text = (int.Parse(lblCount.Text) + 1).ToString();
            }

        private void btnReset_Click(object sender, EventArgs e)
            {
            Reset();
            }

        private void Reset()
            {
            lblNumber.Text = "1";
            lblCount.Text = "0";
            timer1.Enabled = false;
            lblNeed.Visible = false;
            lblWinNumber.Visible = false;
            btnRevert.Visible = false;
            timer1.Enabled = false;

            backNumber.Clear();
            }

        private void btnStart_Click(object sender, EventArgs e)
            {
            x = StartGame();
            timer1.Enabled = true;
            }

        private int StartGame()
            {
            Reset();

            Random rnd = new Random();
            int x = rnd.Next(0, 10001);
            MessageBox.Show($"Вам нужно в минимальное количество ходов получить число {x}", "Условие");
            lblNeed.Visible = true;
            lblWinNumber.Text = x.ToString();
            lblWinNumber.Visible = true;
            btnRevert.Visible = true;
            return x;
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            if(int.Parse(lblNumber.Text) == x)
                {
                MessageBox.Show($"Поздравляю, вы получили {x} за {int.Parse(lblCount.Text)} ходов", "Победа");
                Reset();
                }
            }

        
        }
    }
