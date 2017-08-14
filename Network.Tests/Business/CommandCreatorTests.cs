using System.Linq;
using Moq;
using Network.Business.Services;
using Network.Business.Services.Interfaces;
using Network.Tests.Misc;
using NUnit.Framework;

namespace Network.Tests.Business
{
    using Network = Domain.Entities.Network;

    [TestFixture]
    public class CommandCreatorTests
    {
        private Mock<CommandHandlerService> _commandHandlerServiceMock;
        private ICommandCreator _commandCreator;
        private Network _network;

        [SetUp]
        public void Setup()
        {
            _commandHandlerServiceMock = new Mock<CommandHandlerService>();

            _commandCreator = new CommandCreator(_commandHandlerServiceMock.Object);

            _network = NetworkBuilder.Build();
        }

        [Test]
        public void AcceptShouldAddEventHandlers()
        {
            // Arrange
            // Act
            _commandCreator.Accept(_network);

            // Assert
            foreach (var node in _network.NodesPairs.SelectMany(n => n.Nodes))
            {
                // ToDo: test that event has subscribers
                //NetworkBuilder.MessagesBufferMock.Verify(m => m.OnMessageAdd);
                Assert.Fail();
            }
        }
    }
}
