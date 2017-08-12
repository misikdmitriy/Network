using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class UnlimitedMessageBuffer : IMessagesBuffer
    {
        private readonly List<Message> Messages;

        public UnlimitedMessageBuffer()
        {
            Messages = new List<Message>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Message> GetEnumerator()
        {
            return Messages.GetEnumerator();
        }

        public virtual void Add(Message item)
        {
            Messages.Add(item);
            OnMessageAdd?.Invoke(item);
        }

        public void Clear()
        {
            Messages.Clear();
            OnBufferCleared?.Invoke();
        }

        public bool Contains(Message item)
        {
            return Messages.Contains(item);
        }

        public void CopyTo(Message[] array, int arrayIndex)
        {
            Messages.CopyTo(array, arrayIndex);
        }

        public bool Remove(Message item)
        {
            var result = Messages.Remove(item);
            OnMessageRemoved?.Invoke(item);
            return result;
        }

        public int Count => Messages.Count;
        public bool IsReadOnly => false;
        public int IndexOf(Message item)
        {
            return Messages.IndexOf(item);
        }

        public virtual void Insert(int index, Message item)
        {
            Messages.Insert(index, item);
            OnMessageAdd?.Invoke(item);
        }

        public void RemoveAt(int index)
        {
            var removed = Messages[index];
            Messages.RemoveAt(index);
            OnMessageRemoved?.Invoke(removed);
        }

        public Message this[int index]
        {
            get { return Messages[index]; }
            set
            {
                var replaced = Messages[index];
                Messages[index] = value;

                OnMessageRemoved?.Invoke(replaced);
                OnMessageAdd?.Invoke(value);
            }
        }

        public event MessageAddedHandler OnMessageAdd;
        public event MessageRemovedHandler OnMessageRemoved;
        public event BufferCleared OnBufferCleared;
    }
}
