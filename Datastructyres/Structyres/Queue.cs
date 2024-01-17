using System;

namespace Datastructyres.Structyres {
    public class QueueNode<T> {
        private T _value;

        private QueueNode<T> _nextNode;

        public T value { 
            get => _value;
            set => _value = value;
        }

        public QueueNode<T> nextNode {
            get => _nextNode;
            set => _nextNode = value;
        }

        public QueueNode() {
            _value = default(T);
            _nextNode = null;
        }

        public QueueNode(T value) : base() {
            _value = value;
        }

        ~QueueNode() {
            _nextNode = null;
        }
    }

    internal class CustomQueue<T> where T : IComparable{
        private int _size;

        private QueueNode<T> _firstNode;

        public int size {
            get => _size;
        }

        public CustomQueue() {
            _firstNode = null;
            _size = 0;
        }

        public void Enqueue(T value) { 
            if (_firstNode is null) { 
                _firstNode = new QueueNode<T>(value);
                return;
            }

            QueueNode<T> tempNode = _firstNode;

            while(tempNode.nextNode != null) {
                tempNode = tempNode.nextNode;
            }

            tempNode.nextNode = new QueueNode<T>(value);
        }

        public T Dequeue() {
            T result = _firstNode.value;

            _firstNode = _firstNode.nextNode;

            return result;
        }

        public QueueNode<T> Peak() => _firstNode;

        public bool Contains(T value) {
            QueueNode<T> tempNode = _firstNode;

            do {
                if (tempNode.value.CompareTo(value) == 0)
                    return true;
            } while(tempNode.nextNode is not null);

            return false;
        }
    }
}
