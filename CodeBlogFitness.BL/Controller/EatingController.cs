﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    public  class EatingController : ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }

        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        public Eating Eatings { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Utilizatorul nu poate fi gol!", nameof(user));

            Foods = GetAllFoods();
            Eatings = GetEatings();
        }

        private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eatings);
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eatings.Add(food, weight);
                Save();
            }
            else
            {
                Eatings.Add(product,weight);
                Save();
            }
        }
    }
}
