using Datastructyres.Structyres;

BinaryTree<int> binTree = new BinaryTree<int>();

for (int i = 0; i < 10; i++) { 
    binTree.Add(new Random().Next(-10, 10));
}

foreach(var item in binTree.ToList()) {  
    Console.WriteLine(item);
}