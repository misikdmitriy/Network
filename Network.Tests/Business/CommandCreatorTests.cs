using Moq;
using Network.Business.Services;
using Network.Business.Services.Interfaces;
using Network.Domain.Entities;
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

            _network = new Network();

            _network.NodesPairs.Add(new NodesPair
            {
                Channel = { }
            });
        }

        [Test]
        public void AcceptShouldAddEventHandlers()
        {
            Assert.Fail();
        }
    }
}
