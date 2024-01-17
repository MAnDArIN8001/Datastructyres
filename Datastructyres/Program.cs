using Datastructyres.Structyres;

Random randomizer = new Random();

BinaryTree<int> binTree = new BinaryTree<int>();

for (int i = 0; i < 10; i++) { 
    binTree.Add(randomizer.Next(-10, 10));
}

foreach(var item in binTree.ToList()) {  
    Console.WriteLine(item);
}

CustomQueue<float> queue = new CustomQueue<float>();

for (int i = 0; i < 10; i++) {
    queue.Enqueue(randomizer.Next(-10, 10));
}
