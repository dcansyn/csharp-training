using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTraining.C8.Models
{
    // unmanaged-constructed-types
    public struct Coordinate<T> where T : unmanaged
    {
        public T X;
        public T Y;
    }
}
