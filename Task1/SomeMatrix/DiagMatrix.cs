namespace Task1.SomeMatrix
{
    public class DiagMatrix<T> : SquareMatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Matrix order.</param>

        public DiagMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Square matrix.</param>

        public DiagMatrix(T[,] matrix) : base(matrix)
        {
            MatrixFilling(matrix);
        }

        #endregion

        #region Main function

        /// <summary>
        /// Set value matrix cell.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index row.</param>
        /// <param name="j">Index column.</param>

        public override void SetValue(T value, int i, int j)
        {
            if (i == j)
            {
                base.SetValue(value, i, j);
            }
        }

        /// <summary>
        /// Function then filling matrix given matrix.
        /// </summary>
        /// <param name="sourceMatrix">Given matrix.</param>

        public new void MatrixFilling(T[,] sourceMatrix)
        {
            int newSize = sourceMatrix.GetLength(0);
            Matrix = new T[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    Matrix[i, j] = (dynamic)0;
                }
            }
            for (int i = 0; i < newSize; i++)
                Matrix[i, i] = sourceMatrix[i, i];
        }

        #endregion


    }
}
