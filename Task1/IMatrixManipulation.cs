namespace Task1
{
    public interface IMatrixManipulation<T>
    {
        void AddMatrix(SquareMatrix<T> squareMatrix);
        void AddMatrix(SymmetricMatrix<T> squareMatrix);
        void AddMatrix(DiagMatrix<T> squareMatrix);
    }
}
