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

            Console.WriteLine("Introduce genul utilizatorului!");
            var gender = Console.ReadLine();

            Console.WriteLine("Introduceti data nasterii utilizatorului!");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti greutatea utilizatorului!");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti inaltimea utilizatorului!");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);

            userController.Save();
        }
    }
}
