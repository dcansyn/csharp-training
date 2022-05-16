using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTraining.C9.Models
{
    public record Person(string FirstName, string LastName, string[] PhoneNumbers)
    {
        public string Status { get; set; }
    }
}
