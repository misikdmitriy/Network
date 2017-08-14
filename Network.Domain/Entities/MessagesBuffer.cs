using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    /// <summary>
    /// Message buffer
    /// </summary>
    public class MessagesBuffer : IMessagesBuffer
    {
        /// <summary>
        /// Indicates is buffer filled
        /// </summary>
        public virtual bool IsFilled => Count >= Size;
        /// <summary>
        /// Buffer size
        /// </summary>
        private int Size { get; }
        /// <summary>
        /// Real buffer
        /// </summary>
        private readonly List<Message> _messages;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MessagesBuffer()
        {
            Size = int.MaxValue;
            _messages = new List<Message>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Buffer size</param>
        public MessagesBuffer(int size)
        {
            Size = size;
            _messages = new List<Message>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Message> GetEnumerator()
        {
            return _messages.GetEnumerator();
        }

        public virtual void Add(Message item)
        {
            if (IsFilled)
            {
                return;
            }

            _messages.Add(item);
            OnMessageAdd?.Invoke(item);
        }

        public void Clear()
        {
            _messages.Clear();
            OnBufferCleared?.Invoke();
        }

        public bool Contains(Message item)
        {
            return _messages.Contains(item);
        }

        public void CopyTo(Message[] array, int arrayIndex)
        {
            _messages.CopyTo(array, arrayIndex);
        }

        public bool Remove(Message item)
        {
            var result = _messages.Remove(item);
            OnMessageRemoved?.Invoke(item);
            return result;
        }

        public int Count => _messages.Count;
        public bool IsReadOnly => false;
        public int IndexOf(Message item)
        {
            return _messages.IndexOf(item);
        }

        public virtual void Insert(int index, Message item)
        {
            if (IsFilled)
            {
                return;
            }

            _messages.Insert(index, item);
            OnMessageAdd?.Invoke(item);
        }

        public void RemoveAt(int index)
        {
            var removed = _messages[index];
            _messages.RemoveAt(index);
            OnMessageRemoved?.Invoke(removed);
        }

        public Message this[int index]
        {
            get { return _messages[index]; }
            set
            {
                var replaced = _messages[index];
                _messages[index] = value;

                OnMessageRemoved?.Invoke(replaced);
                OnMessageAdd?.Invoke(value);
            }
        }

        public event MessageAddedHandler OnMessageAdd;
        public event MessageRemovedHandler OnMessageRemoved;
        public event BufferCleared OnBufferCleared;
    }
}
