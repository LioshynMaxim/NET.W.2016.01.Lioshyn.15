using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.SomeMatrix;

namespace Task1.Manipulation
{
    public class Added : IManipulation
    {
        public SquareMatrix<T> Add<T>(T[,] matrix, T[,] addSquareMatrix)
        {
            if (addSquareMatrix == null || matrix == null)
                throw new ArgumentException();

            var finishMatrix = new SquareMatrix<T>(matrix);

            finishMatrix.MatrixFilling(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    try
                    {
                        finishMatrix[i, j] += (dynamic)matrix[i, j] + (dynamic)addSquareMatrix[i, j];
                    }
                    catch (Exception)
                    {
                        throw new AddMatrixException("Add Matrix exception.");
                    }

                }
            }

            return finishMatrix;

        }


    }
}
