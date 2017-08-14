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
        public bool IsBusy => MessagesBuffer.IsFilled;

        public Channel()
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new UnlimitedMessagesBuffer();
        }

        public Channel(int messagesCount)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new LimitedMessagesBuffer(messagesCount);
        }

        internal Channel(IMessagesBuffer messagesBuffer)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = messagesBuffer;
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
