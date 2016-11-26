using System;

namespace Task1.SomeMatrix
{
    public abstract class MatrixClass<T> 
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
        /// Event, then signals about change element.
        /// </summary>
        /// <param name="e">Event.</param>

        public virtual void OnElementChanges(MatrixEventArgs<T> e) => ElementChanges(this, e);

        #endregion



    }
}
