using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    public class Gender
    {   // <summary>
        //  Genul utilizatorului
        // </summary>
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            { 
                throw new ArgumentNullException("Genul nu poate fi null!", nameof(name));  
            }

            Name = name;  
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
