using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class OneWayChannelMessageBuffer : IMessagesBuffer
    {
        public IEnumerator<Message> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Message item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Message item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Message[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Message item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(Message item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, Message item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public Message this[int index]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public event MessageAddedHandler OnMessageAdd;
        public event MessageRemovedHandler OnMessageRemoved;
        public event BufferCleared OnBufferCleared;
    }
}
