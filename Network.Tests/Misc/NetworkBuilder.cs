using Moq;
using Network.Domain.Entities;
using Network.Domain.Entities.Interfaces;

namespace Network.Tests.Misc
{
    using Network = Domain.Entities.Network;

    public class NetworkBuilder
    {
        public static Mock<IMessagesBuffer> MessagesBufferMock { get; }
        private static IMessagesBuffer MessagesBuffer => MessagesBufferMock.Object;

        static NetworkBuilder()
        {
            MessagesBufferMock = new Mock<IMessagesBuffer>();
        }

        public static Network Build()
        {
            var network = new Network();

            var nodes = new[]
            {
                new Node(MessagesBuffer, MessagesBuffer),
                new Node(MessagesBuffer, MessagesBuffer),
                new Node(MessagesBuffer, MessagesBuffer),
            };

            var channels = new[]
            {
                new Channel(MessagesBuffer),
                new Channel(MessagesBuffer)
            };

            network.NodesPairs.Add(new NodesPair(channels[0], nodes[0], nodes[1]));
            network.NodesPairs.Add(new NodesPair(channels[1], nodes[1], nodes[2]));

            return network;
        }
    }
}
