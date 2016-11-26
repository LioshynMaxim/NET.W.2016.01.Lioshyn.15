namespace Task1.SomeMatrix
{
    class MatrixSymmetric<T> : SquareMatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Order matrix.</param>

        public MatrixSymmetric(int order) : base(order)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Given matrix.</param>

        public MatrixSymmetric(T[,] matrix) : base(matrix)
        {
            TransposeMatrix(matrix);
        }

        #endregion

        #region Main function

        /// <summary>
        /// Transpose getting matrix.
        /// </summary>
        /// <param name="sourceMatrix">Given matrix.</param>

        private void TransposeMatrix(T[,] sourceMatrix)
        {
            int size = sourceMatrix.GetLength(0);
            Matrix = new T[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Matrix[i, j] = sourceMatrix[j, i];
            }
        }

        #endregion

    }
}
