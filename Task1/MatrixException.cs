using System;

namespace Task1
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }

        public MatrixException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class SquareMatrixException : MatrixException
    {
        public SquareMatrixException(string message) : base(message) { }
    }

    public class AddMatrixException : MatrixException
    {
        public AddMatrixException(string message) : base(message)
        {
        }

        public AddMatrixException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class MultiplicationMatrixException : MatrixException
    {
        public MultiplicationMatrixException(string message) : base(message)
        {
        }

        public MultiplicationMatrixException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
