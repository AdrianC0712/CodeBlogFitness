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

            Console.WriteLine("Introduceti genul utilizatorului!");
            var gender = Console.ReadLine();

            Console.WriteLine("Introduceti data nasterii!");
            var birdthDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti greutatea utilizatorului!");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti inaltimea utilizatorului!");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birdthDay, weight, height);

            userController.Save();

            Console.ReadLine();
        }
    }
}
