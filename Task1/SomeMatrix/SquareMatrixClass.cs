using System;

namespace Task1.SomeMatrix
{
    public class SquareMatrixClass<T> : MatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Order matrix.</param>

        public SquareMatrixClass(int order)
        {
            if (order <= 0)
                throw new ArgumentException();

            Matrix = new T[order, order];
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Square matrix.</param>

        public SquareMatrixClass(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new SquareMatrixException("Not square matrix :)))");

            MatrixFilling(matrix);
            Order = matrix.GetLength(0);
        }

        #endregion

        #region override function

        /// <summary>
        /// Set value matrix cell.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index row.</param>
        /// <param name="j">Index column.</param>

        public override void SetValue(T value, int i, int j) => Matrix[i, j] = value;

        #endregion

        #region main function

        /// <summary>
        /// Function then filling matrix given matrix.
        /// </summary>
        /// <param name="sourceMatrix">Given matrix.</param>

        public void MatrixFilling(T[,] sourceMatrix)
        {
            int newSize = sourceMatrix.GetLength(0);
            Matrix = new T[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                    Matrix[i, j] = sourceMatrix[i, j];
            }
        }

        #endregion


    }
}
