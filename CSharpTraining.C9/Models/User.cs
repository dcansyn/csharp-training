using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTraining.C9.Models
{
    // positional-syntax-for-property-definition
    public record User(string Name, int Year, string Text);

    /*public record User
    {
        public string Name { get; init; } = default!;
        public int Year { get; init; } = default!;
        public string Text { get; init; } = default!;

        public User(string name, int year, string text)
        {
            Name = name;
            Year = year;
            Text = text;
        }
    }*/


    /*public record User
    {
        public string Name { get; init; } = default!;
        public int Year { get; init; } = default!;
        public string Text { get; init; } = default!;
    }*/
}
