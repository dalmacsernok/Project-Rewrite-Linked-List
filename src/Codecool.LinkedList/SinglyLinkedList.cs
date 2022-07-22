using System;
using System.Collections.Generic;

namespace Codecool.LinkedList
{
    /// <summary>
    /// Generic singly linked list implementation.
    /// </summary>
    public class SinglyLinkedList<T>
    {
        private Link _head;


        /// <summary>
        /// Gets the size of the list.
        /// </summary>
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Add a new element to the LinkedList.
        /// The new element is appended to the current last item.
        /// </summary>
        /// <param name="data">Value to be appended.</param>
        public void Add(T data)
        {
            Link newLink = new Link(data);
            if (_head == null)
            {
                _head = newLink;

            }
            else
            {
                Link actualItem = _head;
                while (actualItem.Next != null)
                {
                    actualItem = actualItem.Next;
                }
                actualItem.Next = newLink;
            }

            Size++;

        }

        /// <summary>
        /// Gives back a certain element at a requested index.
        /// </summary>
        /// <param name="index">Index of requested element.</param>
        /// <returns>Value of requested element.</returns>
        public T Get(int index)
        {
            int counter = 0;
            Link actualItem = _head;
            if (index >= Size && index != 0)
            {
                throw new IndexOutOfRangeException();
            }
            while (counter != index)
            {
                actualItem = actualItem.Next;
                counter++;
            }
            return actualItem.Data;

        }

        /// <summary>
        /// Inserts 'data' at 'index' into the list shifting elements if necessary.
        /// e.g. the result of inserting 42 at index 3 into [0, 1, 2, 3, 4] is [0, 1, 2, 42, 3, 4]
        /// </summary>
        /// <param name="index">Index of inserted element.</param>
        /// <param name="data">Value to be inserted.</param>
        public void Insert(int index, T data)
        {
            int counter = 0; 
            Link actualItem = _head;  
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index == 0)
                {
                    _head = new Link(data);
                    _head.Next = actualItem;
                    Size++;


                }
                while (counter < Size - 1)
                {
                    
                    if (index == Size)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        if (counter == index - 1)
                        {
                            Link temp = actualItem.Next;
                            actualItem.Next = new Link(data);
                            Link newLink = actualItem.Next;
                            newLink.Next = temp;
                            Size++;
                        }

                        actualItem = actualItem.Next;
                        counter++;
                    }

                }
            }

        }

        /// <summary>
        /// Deletes the element at 'index' from the list.
        /// e.g. the result of deleting index 2 from [0, 1, 2, 3, 4] is [0, 1, 3, 4]
        /// </summary>
        /// <param name="index">Index of element to be removed</param>
        public void Remove(int index)
        {
            if (index == 0)
            {
                _head = _head.Next;
                Size--;
                return;
            }

            var currentNode = _head;
            var counter = 0;
            while (counter < index - 1)
            {
                currentNode = currentNode.Next;
                ++counter;

                if (currentNode.Next == null)
                {
                    throw new IndexOutOfRangeException("Tried to remove an invalid item!");
                }
            }

            currentNode.Next = currentNode.Next.Next;
            Size--;
        }

        /// <summary>
        /// Gives back the first index of the given value in the list.
        /// </summary>
        /// <param name="value">Value to search.</param>
        /// <returns>First index of elements equals to given value.</returns>
        public int IndexOf(int value)
        {
            for (int i = 0; i < Size; i++)
            {
                if (Get(i).Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public int size()
        {
            if (Size == 0)
            {
                return Size;
            }
            else
            {
                return Size;
            }
        }

        /// <summary>
/// Gives back the string representation of the LinkedList
/// e.g. A LinkedList which contains the following elements: [2,5,543,21]
/// results the following string "[2, 5, 543, 21]"
/// </summary>
/// <returns>String representation of LinkedList</returns>
public override string ToString()
        {
            if (Size == 0)
            {
                return "[]";
            }
            else
            {
                string inserted = String.Empty;
                Link actualItem = _head;
                while (actualItem.Next != null)
                {
                    inserted += actualItem.Data + ", ";
                    actualItem = actualItem.Next;
                }

                inserted += actualItem.Data;

                return $"[{inserted}]";
            }
            
        }

        private class Link
        {
            /// <summary>
            /// Gets or sets the node data
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Gets or sets the next node reference
            /// </summary>
            public Link Next { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Link"/> class.
            /// </summary>
            /// <param name="data">Value to store</param>
            public Link(T data)
            {
                Data = data;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }
    }
}
