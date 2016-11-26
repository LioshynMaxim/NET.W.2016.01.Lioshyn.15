using System;

namespace Task1
{
    public abstract class CommonMatrixClass<T>
    {
        #region Fields

        public T[,] Matrix { get; set; }
        public int Order { get; set; }
        private event EventHandler<MatrixEventArgs<T>> ElementChanges = delegate { };

        public T this[int i, int j]
        {
            get
            {
                if (!Check(i, j))
                {
                    throw new IndexOutOfRangeException();
                }
                return Matrix[i, j];
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (!Check(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                T oldvalue = Matrix[i, j];
                SetValue(value, i, j);
                OnElementChanges(new MatrixEventArgs<T>(i, j, oldvalue, Matrix[i, j]));
            }
        }

        #endregion

        #region Main function

        /// <summary>
        /// Check index matrix for exception.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Return true, if index consist of matrix.</returns>

        public bool Check(int i, int j) => (i <= 0) || (j <= 0) || (i > Matrix.GetLength(0)) || (j > Matrix.GetLength(1));

        /// <summary>
        /// Set value, then can element of matrix.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        public abstract void SetValue(T value, int i, int j);

        /// <summary>
        /// Override Accept for operation.
        /// </summary>
        /// <param name="matrixManipulation">Parametr of matrix manipulation.</param>

        public abstract void Accept(IMatrixManipulation<T> matrixManipulation);

        /// <summary>
        /// Event, then signals about change element.
        /// </summary>
        /// <param name="e">Event.</param>

        public virtual void OnElementChanges(MatrixEventArgs<T> e) => ElementChanges(this, e);

        #endregion
    }

    public class SquareMatrix<T> : CommonMatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Order matrix.</param>

        public SquareMatrix(int order)
        {
            if (order <= 0)
                throw new ArgumentException();

            Matrix = new T[order, order];
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Square matrix.</param>

        public SquareMatrix(T[,] matrix)
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

        /// <summary>
        /// Override Accept for operation.
        /// </summary>
        /// <param name="matrixManipulation">Parametr of matrix manipulation.</param>

        public override void Accept(IMatrixManipulation<T> matrixManipulation) => matrixManipulation.AddMatrix(this);

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

    public class SymmetricMatrix<T> : CommonMatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Order matrix.</param>

        public SymmetricMatrix(int order)
        {
            if (order <= 0)
                throw new ArgumentException();

            Matrix = new T[order, order];
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Given matrix.</param>

        public SymmetricMatrix(T[,] matrix)
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

        /// <summary>
        /// Set value matrix cell.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="i">Index row.</param>
        /// <param name="j">Index column.</param>

        public override void SetValue(T value, int i, int j) => Matrix[i, j] = value;

        /// <summary>
        /// Override Accept for operation.
        /// </summary>
        /// <param name="matrixManipulation">Parametr of matrix manipulation.</param>

        public override void Accept(IMatrixManipulation<T> matrixManipulation) => matrixManipulation.AddMatrix(this);
    }

    public class DiagMatrix<T> : CommonMatrixClass<T>
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="order">Matrix order.</param>

        public DiagMatrix(int order)
        {
            if (order <= 0)
                throw new ArgumentException();

            Matrix = new T[order, order];
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="matrix">Square matrix.</param>

        public DiagMatrix(T[,] matrix)
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
                SetValue(value, i, j);
            }
        }

        /// <summary>
        /// Override Accept for operation.
        /// </summary>
        /// <param name="matrixManipulation">Parametr of matrix manipulation.</param>

        public override void Accept(IMatrixManipulation<T> matrixManipulation) => matrixManipulation.AddMatrix(this);

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
                {
                    Matrix[i, j] = (dynamic)0;
                }
            }
            for (int i = 0; i < newSize; i++)
                Matrix[i, i] = sourceMatrix[i, i];
        }

        #endregion
    }
    
    public class MatrixEventArgs<T> : EventArgs
    {
        private int Row { get; set; }
        private int Column { get; set; }
        public T OldValue { get; }
        public T NewValue { get; }

        public MatrixEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
