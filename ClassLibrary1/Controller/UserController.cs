using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class UserController
    {
        //public User User { get; }

        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Utilizatoru nu poate fi null!", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null) 
            { 
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        private List<User> GetUsersData() 
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Тип или член устарел
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                { 
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        { 
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;    

            Save();
        }

        //Salvam datele utilizatorului
        public void Save()
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Тип или член устарел
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            { 
                formatter.Serialize(fs, Users);
            }
        }
        //Primim datele utilizatorului
 /*       public User Load() 
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Тип или член устарел
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return Users;
                }
                else 
                {
                    throw new FileLoadException("Nu a fost posibil de primit datele despre utilizator din fisier!", "users.dat");
                }
            }
        }
 */
    }
}
