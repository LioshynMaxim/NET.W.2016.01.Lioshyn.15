using NUnit.Framework;
using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture()]
    public class CommonMatrixClassTests
    {
        int[,] first = new int[,] { {1,2,3}, { 1, 2, 3 }, { 1, 2, 3 } };
        int[,] addInts = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        int[,] finishInts = new int[,] { { 2, 2, 3 }, { 1, 3, 3 }, { 1, 2, 4 } };

        [Test()]
        public void CheckTest()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(first);
            SquareMatrix<int> addMatrix = new SquareMatrix<int>(addInts);
            matrix.GetAdd();
            Assert.AreEqual(matrix,finishInts);
        }
    }
}