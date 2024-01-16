using System;

namespace Datastructyres.Structyres {
    public class Node<T> where T : struct, IComparable<T> {
        private T _value;

        private Node<T> _leftNode;
        private Node<T> _rightNode;

        public T value {
            get => _value;
            set => _value = value;
        }

        public Node<T> leftNode {
            get => _leftNode;
            set => _leftNode = value;
        }
        public Node<T> rightNode {
            get => _rightNode;
            set => _rightNode = value;
        }

        public Node() {
            _value = default(T);
            _rightNode = _leftNode = null;
        }

        public Node(T value) : base() {
            _value = value;
        }

        ~Node() {
            _rightNode = _leftNode = null;
        }
    }

    internal class BinaryTree<T> where T : struct, IComparable<T> { 
        private int _size;

        private Node<T> _root;

        public BinaryTree() {
            _root = null;
        }

        ~BinaryTree() {
            _root = null;
        }

        public void Add(T value) { 
            if(_root is null) {
                _root = new Node<T>(value);
                return;
            }

            Node<T> temp = _root;

            do {
                int compareResult = value.CompareTo(temp.value);

                if(temp.rightNode == null && compareResult >= 0) {
                    temp.rightNode = new Node<T>(value);
                    break;
                } else if(temp.leftNode == null && compareResult == -1) {
                    temp.leftNode = new Node<T>(value);
                    break;
                }

                temp = compareResult == 1 ? temp.rightNode : temp.leftNode;
            } while(true);
        }

        public bool IsExist(T value) {
            Node<T> temp = _root;

            while(temp != null) {
                int compareResult = value.CompareTo(temp.value);

                if (compareResult == 0)
                    return true;

                temp = compareResult == 1 ? temp.rightNode : temp.leftNode;
            }

            return false;
        }

        public void OutputTree() {
            OutputNode(_root);
        }

        private void OutputNode(Node<T> node) { 
            if(node is not null) {
                OutputNode(node.leftNode);
                Console.Write(node.value + " ");
                OutputNode(node.rightNode);
            }
        }
    }   
}
