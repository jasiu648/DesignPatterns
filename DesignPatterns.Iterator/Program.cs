
BinarySearchTree<int> bst = new BinarySearchTree<int>();

bst.Insert(50);
bst.Insert(30);
bst.Insert(20);
bst.Insert(40);
bst.Insert(70);
bst.Insert(60);
bst.Insert(80);

Console.WriteLine("Inorder Traversal of the BST:");
bst.InOrderTraversal();

var iteratorBST = bst.CreateIterator();

while (iteratorBST.HasMore())
{
    Console.WriteLine(((Node<int>)iteratorBST.GetNext()).Value);
}