using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_of_criminals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.Work();
        }
    }

    class Controller
    {
        private Database _database;

        public Controller()
        {
            _database = new Database(new List<Criminal>() { new Criminal("Салман Бетырович Радуев", "чеченец", 173, 64, true), new Criminal("Али Мусаевич Тазиев", "чеченец", 173, 64, false), new Criminal("Али Мусаевич Тазиев", "чеченец", 173, 64, false), new Criminal("Джордж флойд", "негр", 180, 78, false), new Criminal("Александр Владимирович Козачинский", "русский", 176, 72, true) });
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                int growth = ReadInt("Введите рост: ");
                int weight = ReadInt("Введите вес: ");

                Console.Write("Введите национальность: ");

                string nationality = Console.ReadLine();

                List<Criminal> criminals = _database.TakeCriminals(growth, weight, nationality);

                Console.Clear();

                if (criminals.Count > 0)
                    foreach (var criminal in criminals)
                    {
                        Console.WriteLine(criminal.FullName);
                    }
                else
                    Console.WriteLine("Преступник не найден в базе данных");

                Console.ReadKey();
                Console.Clear();
            }
        }

        private int ReadInt(string output)
        {
            int result = 0;
            bool isNumber = false;

            while(isNumber == false)
            {
                Console.Write(output);

                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                    isNumber = true;
                else
                    Console.WriteLine("Некоректное число");   
            }

            return result;
        }
    }

    class Database
    {
        private List<Criminal> _criminals;

        public Database(List<Criminal> criminals)
        {
            _criminals = criminals;
        }

        public List<Criminal> TakeCriminals(int growth, int weight, string nationality, bool isGuarded = false)
        {
            var coincidesCriminals = _criminals.Where(criminal => criminal.Growth == growth && criminal.Weight == weight && criminal.Nationality == nationality && criminal.IsGuarded == isGuarded).ToList();

            return coincidesCriminals;
        }
    }       


    class Criminal
    {
        public string FullName { get; private set; }
        public string Nationality { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
        public bool IsGuarded { get; private set; }

        public Criminal(string fullName, string nationality, int growht, int weight, bool isGuarded)
        {
            FullName = fullName;
            Nationality = nationality;
            Growth = growht;
            Weight = weight;
            IsGuarded = isGuarded;
        }
    }
}
