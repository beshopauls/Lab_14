using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_10;
using lab12;
using Lab_13;
namespace Lab_14
{
    public class Faculties
    {
        public Dictionary<Person, Student> FacultiesDictionary { get; set; }
        public string Name { get; set; }
        public Faculties(string name)
        {
            FacultiesDictionary = new Dictionary<Person, Student>();
            Name = name;
        }
    }

}
