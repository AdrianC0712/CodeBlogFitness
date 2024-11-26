using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Va saluta aplicatia CodeBlogFitness!");
            
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Introduceti numele utilizatorului!");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Introduceti genul utilizatorului!");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Greutatea");
                var height = ParseDouble("inaltimea");
                
                userController.SetNewUserData(gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Introduceti anul nasterii (dd.MM.yyyy)!");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nu este corect formatul datei introduse!!!");
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
                    Console.WriteLine($"Format incorect {name}");
                }
            }  
        }
    }
}
