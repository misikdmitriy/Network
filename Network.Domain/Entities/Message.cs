using System;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    /// <summary>
    /// Object used in network for communication
    /// </summary>
    public class Message : IIdentifiable
    {
        public Guid Id { get; }
        /// <summary>
        /// Message size
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// Sender node
        /// </summary>
        public Node Sender { get; }
        /// <summary>
        /// Receiver node
        /// </summary>
        public Node Receiver { get; }

        /// <summary>
        /// Message used for test purposes
        /// </summary>
        internal static readonly Message NullMessage = new Message(null, null, 0);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender">Sender node</param>
        /// <param name="receiver">Receiver node</param>
        /// <param name="size">Size of the message</param>
        public Message(Node sender, Node receiver, int size)
        {
            Id = Guid.NewGuid();
            Size = size;
            Sender = sender;
            Receiver = receiver;
        }
    }
}
