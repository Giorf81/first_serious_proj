using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace first_serious_proj
{
    internal class Program
    {

        //public string userName; string userSurname; byte age; string[] PetsName; string[] Colors;
        static void Main(string[] args)
        {
            var anketa = User();

            DataGive(anketa);
            
        }


        static (string userName, string userSurname, byte age, string[] PetsName, string[] Colors) User()
        {
            (string userName, string userSurname, byte age, string[] PetsName, string[] Colors) anketa = new();
            string[] PetsName;
            string[] Colors;
            string age;
            byte NumAge;
            byte NumColors;
            byte NumPets;
            Console.WriteLine("Ваше имя?");
            anketa.userName = Console.ReadLine();
            Console.WriteLine("Ваша фамилия?");
            anketa.userSurname = Console.ReadLine();
            do
            {
                Console.WriteLine("ваш возраст?");
                age = Console.ReadLine();
            }

            while (CheckCorrect(age, out NumAge));

            anketa.age = NumAge;


            Console.WriteLine("Есть ли у вас питомец?(формат ответа: Да/Нет)");
            if (Console.ReadLine() == "Да")
            {
                do
                {
                    Console.WriteLine("Сколько у вас питомцев?");
                    age = Console.ReadLine();
                }

                while (CheckCorrect(age, out NumPets));


                anketa.PetsName = NameOfPets(NumPets);
            }
            else
            {
                anketa.PetsName = Array.Empty<string>();
            }

            
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                age = Console.ReadLine();
            }
            while (CheckCorrect(age, out NumColors));
            anketa.Colors = FavColors(NumColors);
            

            return anketa;
        }


        static string[] NameOfPets(int number)
        {
            string[] PetsName = new string[number];
            Console.WriteLine("Имя одного из ваших питомцев?");
            for (int i = 0; i < number; i++)
            {
                PetsName[i] = Console.ReadLine();
            }
            return PetsName;
        }

        static string[] FavColors(int number)
        {
            string[] Colors = new string[number];
            Console.WriteLine("Какие ваши любимые цвета?");
            for (int i = 0; i < number; i++)
            {
                Colors[i] = Console.ReadLine();
            }
            return Colors;
        }

        static bool CheckCorrect(string num, out byte trueNum)
        {
            if (byte.TryParse(num, out byte JustNum))
            {
                if(JustNum > 0)
                {
                    trueNum = JustNum;
                    return false;
                }
            }
            {
                trueNum = 0;
                return true;
            }
        }
        
        static void DataGive((string UserName, string UserSurname, byte Age, string[] PetsName, string[] Colors) anketaData)
        {
            Console.WriteLine($"Ваше имя: {anketaData.UserName}");
            Console.WriteLine($"Ваша фамилия: {anketaData.UserSurname}");
            Console.WriteLine($"Ваш возраст: {anketaData.Age}");
            foreach (var pets in anketaData.PetsName)
            {
                Console.WriteLine($"Имя одного из ваших питомцев: {pets}");
            }
            foreach (var color in anketaData.Colors)
            {
                Console.WriteLine($"Один из ваших любимых цветов: {color}");
            }
            
        }
    }
}
