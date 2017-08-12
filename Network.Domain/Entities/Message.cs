using System;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Message : IIdentifiable
    {
        public Guid Id { get; }
        public object Content { get; set; }
        public Node Sender { get; set; }
        public Node Receiver { get; set; }

        public Message()
        {
            Id = Guid.NewGuid();
        }
    }
}
