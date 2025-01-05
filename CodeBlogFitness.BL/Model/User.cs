using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Utilizator
    /// </summary>
    public class User
    {
        #region Parametrii utilizatorului
        /// <summary>
        /// Numele utilizatorului
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Genul utilizatorului
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Data nasterii utilizatorului
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Inaltimea utilizatorului
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Greutatea utilizatorului
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Crearea utilizatorului
        /// </summary>
        /// <param name="name">Numele utilizatorului</param>
        /// <param name="gender">Genul utilizatorului</param>
        /// <param name="birthDate">Data nasterii utilizatorului</param>
        /// <param name="weight">Greutatea utilizatorului</param>
        /// <param name="height">Inaltimea utilizatorului</param>
        /// <exception cref="ArgumentNullException"> Verificarea parametrilor daca sunt null</exception>
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Verificarea coditiilor
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Numele utilizatorului nu poate fi gol sau nulL!",nameof(name));
            }
            if (Gender == null)
            { 
                throw new ArgumentNullException("Genul nu poate fi null!",nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Data nasterii nu poate fi mai mica sau egal cu 01.01.1900 sau mai mare ca data de azi!",nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException("Greutatea nu poate fi mai mica sau egal cu 0!",nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Intaltimea nu poate fi mai mica sau egal cu 0!",nameof(height));
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
