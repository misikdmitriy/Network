using Moq;
using Network.Domain.Entities;
using Network.Domain.Entities.Interfaces;

namespace Network.Tests.Misc
{
    using Network = Domain.Entities.Network;

    public class NetworkBuilder
    {
        public static Mock<IMessagesBuffer> NodeMessagesBufferMock { get; }
        private static IMessagesBuffer NodeMessagesBuffer => NodeMessagesBufferMock.Object;

        public static Mock<IMessagesBuffer> ChannelMessagesBufferMock { get; }
        private static IMessagesBuffer ChannelMessagesBuffer => ChannelMessagesBufferMock.Object;

        static NetworkBuilder()
        {
            NodeMessagesBufferMock = new Mock<IMessagesBuffer>();
            ChannelMessagesBufferMock = new Mock<IMessagesBuffer>();
        }

        public static Network Build()
        {
            var network = new Network();

            var nodes = new[]
            {
                new Node(NodeMessagesBuffer, NodeMessagesBuffer),
                new Node(NodeMessagesBuffer, NodeMessagesBuffer),
                new Node(NodeMessagesBuffer, NodeMessagesBuffer),
            };

            var channels = new[]
            {
                new Channel(ChannelMessagesBuffer),
                new Channel(ChannelMessagesBuffer)
            };

            network.NodesPairs.Add(new NodesPair(channels[0], nodes[0], nodes[1]));
            network.NodesPairs.Add(new NodesPair(channels[1], nodes[1], nodes[2]));

            return network;
        }
    }
}
