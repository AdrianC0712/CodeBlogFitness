using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class Gender
    {
        /// <summary>
        /// Genul persoanei
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Se creaza un nou gen
        /// </summary>
        /// <param name="name"> Numele genului </param>
        /// <exception cref="ArgumentNullException"> nu poate fi nul, returnam exceptie</exception>
        public Gender(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Numele genul nu poate fi spatiu sau null!", nameof(name));
            }

            Name = name;    
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
