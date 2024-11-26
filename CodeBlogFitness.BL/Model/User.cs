using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class User
    {
        public String Name { get; }   
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; } 
        public double Height { get; set; }
        
        public User( string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Verificarea datelor daca nu sunt nulle
            if (string.IsNullOrEmpty(name))
            { 
                throw new ArgumentNullException("Numele utilizatorului nu poate fi null!", nameof(name));
            }

            if (gender == null) 
            {
                throw new ArgumentNullException("Numele utilizatorului nu poate fi null!", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Data nu poate fi mai mica ca 01.01.1990 sau nu poate fi data de azi!", nameof(birthDate));
            }

            if (weight <= 0) 
            {
                throw new ArgumentNullException ("Greutatea nu poate fi mai mica ca 0!", nameof(weight)); 
            }

            if (height <= 0)
            { 
                throw new ArgumentNullException("Inaltimea nu poate fi mai mica ca 0!", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender; 
            BirthDate = birthDate;
            Weight = weight; 
            Height = height;

        }
        public override string ToString() 
        { 
            return Name;    
        }
    }
}
