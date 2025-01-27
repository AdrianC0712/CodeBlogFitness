using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CodeBlogFitness");
            Console.WriteLine("Introduceti numele utilizatorului!");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Introduceti genul:");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("Greutatea");
                double height = ParseDouble("Inlatimea");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Selecti optiunea dorita!");
            Console.WriteLine("E - introduceti mincarea servita!");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eatings.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine(); 
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Introduceti numele produsului: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calorii");
            var prots = ParseDouble("proteine");
            var fats = ParseDouble("grasimi");
            var carbs = ParseDouble("carbohitrati");

            var weight = ParseDouble("Greutatea portiei");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight : weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Introduceti data nasterii:");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Tipul datei este incorect!");
                }
            }
            return birthDate;   
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Introduceti {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Tipul {name} este incorect!");
                }
            }
        }
    }
}
