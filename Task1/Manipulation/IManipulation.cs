using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.SomeMatrix;

namespace Task1.Manipulation
{
    interface IManipulation
    {
        SquareMatrix<T> Add<T>(T[,] matrix, T[,] addSquareMatrix);
    }
}
