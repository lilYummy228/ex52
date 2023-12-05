using System;
using System.Collections.Generic;
using System.Linq;

namespace ex52
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Detective detective = new Detective();
            List<Criminal> criminals = new List<Criminal>
            {
                new Criminal("Ашот", false, 169, 68, "АРМЕНИЯ"),
                new Criminal("Петр", false, 180, 88, "РОССИЯ"),
                new Criminal("Герман", true, 157, 101, "ГЕРМАНИЯ"),
                new Criminal("Жанна", true, 154, 57, "ФРАНЦИЯ"),
                new Criminal("Бенджамин", false, 170, 118, "ВЕЛИКОБРИТАНИЯ"),
                new Criminal("Руслан", true, 189, 92, "ГРУЗИЯ"),
            };

            int height = detective.FindValue("Введите рост преступника в см: "); ;
            int weight = detective.FindValue("Введите вес преступника в кг: ");
            string nationality = detective.FindNationality("Введите страну национальности преступника: ");

            detective.ShowInfo(height, weight, nationality);

            var allSuspects = criminals.Where(criminal => criminal.IsUnderGuard == false && height == criminal.Height && weight == criminal.Weight 
            && nationality.ToUpper() == criminal.Nationality).ToList();

            detective.ShowAllSuspects(allSuspects);
        }
    }

    class Criminal
    {
        public Criminal(string name, bool isUnderGuard, int height, int weight, string nationality)
        {
            Name = name;
            IsUnderGuard = isUnderGuard;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; private set; }
        public bool IsUnderGuard { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
    }

    class Detective
    {
        public int FindValue(string request)
        {
            while (true)
            {
                Console.Write(request);

                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Неверный ввод. Попробуйте еще раз...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public string FindNationality(string request)
        {
            Console.Write(request);
            string nationality = Console.ReadLine();

            return nationality;
        }

        public void ShowInfo(int height, int weight, string nationality)
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Введенные данные: Рост: {height} см. Вес: {weight} кг. Страна: {nationality}");
            Console.SetCursorPosition(0, 0);
        }

        public void ShowAllSuspects(List<Criminal> allSuspects)
        {
            Console.WriteLine("Найденные в базе преступники: ");

            foreach (var criminal in allSuspects)
            {
                Console.WriteLine(criminal.Name);
            }

            Console.ReadKey(false);
        }
    }
}
