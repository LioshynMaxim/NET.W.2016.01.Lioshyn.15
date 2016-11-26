using System;
using Task1.SomeMatrix;

namespace Task1.Manipulation
{
    public class Manipulation
    {
        /// <summary>
        /// Add two matrix.
        /// </summary>
        /// <typeparam name="T">Type matrix.</typeparam>
        /// <param name="squareMatrix">First matrix.</param>
        /// <param name="addSquareMatrix">Added matrix.</param>
        /// <returns>Summarize the matrix.</returns>
        /*
        public SquareMatrixClass<T> Add<T>(SquareMatrix<T> squareMatrix, SquareMatrix<T> addSquareMatrix)
        {
            if (addSquareMatrix == null || squareMatrix == null || squareMatrix.Order != addSquareMatrix.Order)
                throw new ArgumentException();

            for (int i = 0; i < squareMatrix.Order; i++)
            {
                for (int j = 0; j < squareMatrix.Order; j++)
                {
                    try
                    {
                        squareMatrix[i, j] += (dynamic)addSquareMatrix[i, j];
                    }
                    catch (Exception)
                    {
                        throw new AddMatrixException("Add Matrix exception.");
                    }
                }
            }

            return squareMatrix;
        }
        */
       
    }
}
