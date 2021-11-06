using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtomat
{
    public class Drinks
    {
        public int volume = 0;//объём
        public static Random rnd = new Random();
        public virtual String GetInfo()
        {
            var str = String.Format("\nОбъём: {0}мл.", this.volume);
            return str;
        }
    }


    //сок
    public class Juice : Drinks 
    {
        public string fruit = "";//используемый фрукт
        public bool pulp = false;//наличие мякоти
        public override String GetInfo()
        {
            var str = "Я сок";
            str += base.GetInfo();
            str += String.Format("\nФрукт: {0}", this.fruit);
            str += String.Format("\nНаличие мякоти: {0}", this.pulp);
            return str;
        }

        // статический метод генерации случайного сока
        public static Juice Generate()
        {
            //список фруктов для сока
            string[] fruits = new string[] { "апельсин", "яблоко", "томат" };
            return new Juice
            {
                volume = 100 + rnd.Next() % 5 * 100, //объём от 100 до 500 миллилитров
                fruit = fruits[rnd.Next() % 3], //используемый фрукт
                pulp = rnd.Next() % 2 == 0 //наличие мякоти
            };
        }
    }

    //виды газировки
    public enum SodaType {kolla,sprite,fanta};
    //газировка
    public class Soda : Drinks
    {
        public int bubbles = 0;//количество пузыриков
        public SodaType type = SodaType.kolla;//вид
        public override String GetInfo()
        {
            var str = "Я газировка";
            str += base.GetInfo();
            str += String.Format("\nКоличество пузыриков: {0}", this.bubbles);
            str += String.Format("\nВид: {0}", this.type);
            return str;
        }

        public static Soda Generate()
        {
            return new Soda
            {
                volume = 100 + rnd.Next() % 5 * 100, //объём от 100 до 500 миллилитров
                bubbles = rnd.Next(10000,1000000), //количество пузыриков
                type = (SodaType)rnd.Next(3) //вид
            };
        }
    }

    //тип алкоголя
    public enum AlcoType {beer, cider };
    //алкоголь
    public class Alco : Drinks
    {
        public int strength = 0;//крепость
        public AlcoType type = AlcoType.beer;//тип
        public override String GetInfo()
        {
            var str = "Я алкоголь";
            str += base.GetInfo();
            str += String.Format("\nКрепость: {0}%", this.strength);
            str += String.Format("\nТип: {0}", this.type);
            return str;
        }
        public static Alco Generate()
        {
            return new Alco
            {
                volume = 100 + rnd.Next() % 5 * 100, //объём от 100 до 500 миллилитров
                strength = rnd.Next(1,8),
                type = (AlcoType)rnd.Next(2) //тип
            };
        }
    }
}