using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtomat
{
    public partial class Avtomat : System.Windows.Forms.Form
    {
        List<Drinks> drinksList = new List<Drinks>();

        public Avtomat()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click_1(object sender, EventArgs e)
        {
            this.drinksList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (остаток от деления на 3)
                {
                    case 0: // если 0, то сок
                        this.drinksList.Add(Juice.Generate());
                        break;
                    case 1: // если 1, то газировка
                        this.drinksList.Add(Soda.Generate());
                        break;
                    case 2: // если 2, то алкоголь
                        this.drinksList.Add(Alco.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        // функция выводит информацию о количестве фруктов на форму
        private void ShowInfo()
        {
            //счетчики под каждый тип
            int juiceCount = 0;
            int sodaCount = 0;
            int alcoCount = 0;
            // пройдемся по всему списку
            foreach (var drink in this.drinksList)
            {
                if (drink is Juice)
                {
                    juiceCount += 1;
                }
                else if (drink is Soda)
                {
                    sodaCount += 1;
                }
                else if (drink is Alco)
                {
                    alcoCount += 1;
                }
            }
            // выводим все это надо на форму
            txtInfo.Text = "Сок\tГазировка\tАлкоголь";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t\t{2}", juiceCount, sodaCount, alcoCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.drinksList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                jpgBox.Image = Properties.Resources.gg;
                return;
            }

            // взяли первый напиток
            var drink = this.drinksList[0];
            this.drinksList.RemoveAt(0);

            //теперь предложим покупателю его фрукт
            txtOut.Text = drink.GetInfo();

            jpgBox.Image = drink.GetJPG();

            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}
