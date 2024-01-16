using System;
using System.Collections;
using System.Numerics;

namespace Datastructyres.Structyres {
    public class Item<T> {
        private T _value;

        private Item<T> _next;

        public T value { get => _value; set => _value = value; }

        public Item<T> next { get => _next; set => _next = value; }

        public Item()  {
            _value = default(T);
            _next = null;
        }

        public Item(T value) {
            _value = value;
            _next = null;
        }

        ~Item() {
            _next = null;
        }
    }


    internal class CustomLinkedList<T> {
        private int _length;

        private Item<T> _root;

        public CustomLinkedList() {
            _root = null;
        }

        ~CustomLinkedList() {
            _root = null;
        }

        public static CustomLinkedList<T> operator + (CustomLinkedList<T> list ,T value) {
            list.Add(value);

            return list;
        }

        public T this[int index] {
            get { 
                if(index > _length)
                    throw new IndexOutOfRangeException();

                Item<T> response = GetItemWithIndex(index);

                return response.value;
            }

            set {
                if (index > _length)
                    throw new IndexOutOfRangeException();

                Item<T> item = GetItemWithIndex(index);
                item.value = value;
            }
        }

        public override string ToString() {
            string response = "";

            Item<T> temp = _root;

            while (temp != null) {
                response += temp.value + " ";
                temp = temp.next;
            }

            return response;
        }

        public void Add(T value) {
            _length++;

            if(_root is null) {
                _root = new Item<T>(value);
                return;
            }

            Item<T> temp = _root;

            while(temp.next != null) {
                temp = temp.next;
            }

            temp.next = new Item<T>(value);
        }

        public void RemoveAt(int index) { 
            if(index > _length)
                throw new IndexOutOfRangeException();

            Item<T> lastItem = _root;
            Item<T> preLastItem = _root;

            for (int i = 0; i <= index; i++) {
                if(i == index-1) {
                    preLastItem = lastItem;
                }

                lastItem = lastItem.next;
            }

            preLastItem.next = lastItem;
        }

        public List<T> ToList() { 
            List<T> response = new List<T>();

            Item<T> temp = _root;

            while(temp != null) {
                response.Add(temp.value);
                temp = temp.next;
            }

            return response;
        }

        public void Clear() {
            _root = null;
            _length = 0;
        }

        private Item<T> GetItemWithIndex(int index) {
            Item<T> temp = _root;

            for (int i = 0; i < index; i++) {
                temp = temp.next;
            }

            return temp;
        }
    }
}
