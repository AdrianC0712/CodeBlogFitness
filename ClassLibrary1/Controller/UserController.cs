﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            var gender = new Gender(genderName);

            User = new User(userName, gender, birdthDay, weight, height);

        }
        //Salvam datele utilizatorului
        public void Save()
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Тип или член устарел
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            { 
                formatter.Serialize(fs, User);
            }
        }
        //Primim datele utilizatorului
        public User Load() 
        {
#pragma warning disable SYSLIB0011 // Тип или член устарел
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Тип или член устарел
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    return User;
                }
                else 
                {
                    throw new FileLoadException("Nu a fost posibil de primit datele despre utilizator din fisier!", "users.dat");
                }
            }
        }
    }
}