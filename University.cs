using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{
    public class University
    {
        public List<Faculties> Faculties { get; set; }
        public University()
        {
            Faculties = new List<Faculties>();  
        }
    }
}
