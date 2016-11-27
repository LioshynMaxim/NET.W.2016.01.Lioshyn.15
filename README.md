# NET.W.2016.01.Lioshyn.15

1. Create generalized classes to represent a square, symmetrical and diagonal matrices (symmetric matrix - a square matrix, which coincides with the transposed thereto; diagonal matrix - a square matrix whose main diagonal elements is known to have a default element type). Describe to create a class event that occurs when you change the matrix element with indices (i, j). Provide the ability to extend the functionality of the class hierarchy by adding the possibility of operation of addition of two matrices of any type. Develop unit-tests.

2. Develop a generic collection classes BinarySearchTree (binary search tree). To provide for the possibility of using plug-in interface for the realization of the order relation. Implement the three methods of tree traversal: direct (preorder), transverse (inorder), reverse (postorder): used to implement an iterator block (yield). Test developed by the class, using the following types:

* System.Int32 (to use the default comparison and plug comparator);
* System.String (to use the default comparison and plug comparator);
* custom class Book, for objects which implemented the order relation (to use the default comparison and plug comparator);
* custom Point structure for objects which have not implemented the order relation (used connected comparator).
