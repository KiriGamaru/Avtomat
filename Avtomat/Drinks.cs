using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// БУДТЕ ВНИМАТЕЛЬНЕЕ: ТУТ ДОЛЖЕН СТОЯТЬ ТОТ ЖЕ namespace что и в Program.cs
namespace WindowsFormsApp12
{
    public class Drinks {}



    //сок
    public class Juice : Drinks 
    {
        public int volume = 0;//объём
        public string fruit = "";//используемый фрукт
        public bool pulp = false;//наличие мякоти
    }

    //виды газировки
    public enum SodaType {kolla,sprite,fanta};
    //газировка
    public class Soda : Drinks
    {
        public int volume = 0;
        public int bubbles = 0;//количество пузыриков
        public SodaType type = SodaType.kolla;//вид
    }

    //тип алкоголя
    public enum AlcoType {beer, vodka};
    //алкоголь
    public class Alco : Drinks
    {
        public int volume = 0;
        public int strength = 0;//крепость
        public AlcoType type = AlcoType.beer;//тип
    }
}