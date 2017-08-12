using System;
using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Channel : IIdentifiable, IEnumerable<Message>
    {
        public Guid Id { get; }
        public IMessagesBuffer MessagesBuffer { get; set; }
        public bool IsBusy => MessagesBuffer.Count >= _messagesCount;

        private readonly int _messagesCount;

        protected Channel(int messagesCount)
        {
            Id = Guid.NewGuid();
            _messagesCount = messagesCount;
            MessagesBuffer = new LimitedMessagesesBuffer(messagesCount);
        }

        public IEnumerator<Message> GetEnumerator()
        {
            return MessagesBuffer.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
