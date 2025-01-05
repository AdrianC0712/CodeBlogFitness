using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birdtDay, double weight, double height )
        {
            var gender = new Gender(genderName);
            User user = new User(userName, gender, birdtDay, weight, height);
            User = user ?? throw new ArgumentNullException("Utilizatorul nu poate fi null!",nameof(user));
        }
        /// <summary>
        /// Salvam datele utilizatorului
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);    
            }
        }
        /// <summary>
        /// Primim datele utilizatorului
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException">Exceptie in cazul in care nu primim date despre utilizator</exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: ce facem daca nu primim utilizatorul
            }
        }
    }
}
