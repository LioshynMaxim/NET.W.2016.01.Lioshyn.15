using System;

namespace Task1.SomeMatrix
{
    public sealed class MatrixEventArgs<T> : EventArgs
    {
        private int Row
        {
            get
            {
                return Row;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int Column
        {
            get
            {
                return Column;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
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
