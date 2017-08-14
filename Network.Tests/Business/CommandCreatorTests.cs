using System.Linq;
using Moq;
using Network.Business.Commands;
using Network.Business.Services;
using Network.Business.Services.Interfaces;
using Network.Domain.Entities;
using Network.Tests.Misc;
using NUnit.Framework;

namespace Network.Tests.Business
{
    using Network = Domain.Entities.Network;

    [TestFixture]
    public class CommandCreatorTests
    {
        private Mock<ICommandHandlerService> _commandHandlerServiceMock;
        private ICommandCreator _commandCreator;
        private Network _network;

        [SetUp]
        public void Setup()
        {
            _commandHandlerServiceMock = new Mock<ICommandHandlerService>();

            _commandCreator = new CommandCreator(_commandHandlerServiceMock.Object);

            _network = NetworkBuilder.Build();
        }

        [Test]
        public void AcceptShouldAddEventHandlersToNodes()
        {
            // Arrange
            var nodes = _network.NodesPairs
                .SelectMany(n => n.Nodes)
                .Distinct()
                .ToArray();

            // Act
            _commandCreator.Accept(_network);

            // Assert
            NetworkBuilder.NodeMessagesBufferMock.Raise(n => n.OnMessageAdd += null, Message.NullMessage);

            _commandHandlerServiceMock.Verify(n => n.HandleAddMessageToNodeCommand(It.IsAny<AddMessageToNodeCommand>()), Times.Exactly(nodes.Length));
        }

        [Test]
        [Ignore("Method isn't implemented")]
        public void AcceptShouldAddEventHandlersToChannels()
        {
            // Arrange
            var channels = _network.NodesPairs
                .Select(n => n.Channel)
                .ToArray();

            // Act
            _commandCreator.Accept(_network);

            // Assert
            NetworkBuilder.ChannelMessagesBufferMock.Raise(n => n.OnMessageAdd += null, Message.NullMessage);

            _commandHandlerServiceMock.Verify(n => n.HandleAddMessageToNodeCommand(It.IsAny<AddMessageToNodeCommand>()), Times.Exactly(channels.Length));
        }
    }
}
