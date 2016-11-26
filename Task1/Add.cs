using System;

namespace Task1
{
    public class Add<T> : IMatrixManipulation<T>
    {
        public SquareMatrix<T> SquareMatrix { get; private set; }
        
        public void AddMatrix(SquareMatrix<T> squareMatrix)
        {
            if (squareMatrix == null)
                throw new ArgumentException();

            SquareMatrix = new SquareMatrix<T>(squareMatrix.Order);

            for (int i = 0; i < squareMatrix.Order; i++)
            {
                for (int j = 0; j < squareMatrix.Order; j++)
                {
                    try
                    {
                        SquareMatrix[i, j] += (dynamic)squareMatrix[i, j];
                    }
                    catch (Exception)
                    {
                        throw new AddMatrixException("AddMatrix Matrix exception.");
                    }
                }
            }
        }

        public void AddMatrix(SymmetricMatrix<T> squareMatrix)
        {
            throw new NotImplementedException();
        }

        public void AddMatrix(DiagMatrix<T> squareMatrix)
        {
            throw new NotImplementedException();
        }
    }

    public static class ExtensionsMethodMatrix
    {
        public static SquareMatrix<T> GetAdd<T>(this SquareMatrix<T> squareMatrix)
        {
            var visitor = new Add<T>();
            squareMatrix.Accept(visitor);
            return visitor.SquareMatrix;
        }
    }
}
