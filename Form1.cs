using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Оконное_приложение_2_2
{
  public partial class Form1 : Form
  {
    //Добавляем экземпляр класса Random, он нам понадобиться для получения слуйчаной буквы.
    Random random = new Random();
    Stats stats = new Stats();
    public Form1()
    {
      InitializeComponent();
      timer1.Enabled = true; //Делаем таймер активным
      timer1.Start(); //Запускаем таймер
    }
    private void timer1_Tick(object sender, EventArgs e)
        {
      listBox1.Items.Add((Keys)random.Next(65, 90));
      if (listBox1.Items.Count>7)
      {
        listBox1.Items.Clear();
        listBox1.Items.Add("Конец.");
        timer1.Stop();
      }
      }

    private void listBox1_KeyDown(object sender, KeyEventArgs e)
    {
      //Если пользователь правильно нажимает клавиши, то буквы удаляются, а скорость их появления
     // увеличивается.
if (listBox1.Items.Contains(e.KeyCode)) //Проверка на правильность нажатия.
      {
        listBox1.Items.Remove(e.KeyCode); //удаление буквы из listBox`а
        listBox1.Refresh();
        if (timer1.Interval > 400) timer1.Interval -= 10;
        if (timer1.Interval > 250) timer1.Interval -= 7;
        if (timer1.Interval > 100) timer1.Interval -= 2;
        difficultyProgressBar.Value = 800 - timer1.Interval;//Заполнение ProgressBar`а
        stats.Update(true); //Обновляем статистику.
      }
      else
      {
        stats.Update(false);
      }
      correctLabel.Text = "Correct: " + stats.Correct;
      missedLabel.Text = "Missed " + stats.Missed;
      totalLabel.Text = "Total " + stats.Total;
      accuracyLabel.Text = "Accuracy: " + stats.Accuracy + "%";
    }
  }
}
