﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        public UserController(string userName )
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Numele utilizatorului nu paote fi gol!", nameof(userName));
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

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        { 
            //TODO verificare
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Primim lista utilizatorilor
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException">Exceptie in cazul in care nu primim date despre utilizator</exception>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();

        }
        /// <summary>
        /// Salvam datele utilizatorului
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}
