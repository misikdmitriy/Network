using System.Linq;
using Network.Domain.Entities;
using Network.Domain.Entities.Interfaces;

namespace Network.Business.Postprocessors
{
    using Network = Domain.Entities.Network;

    public class MessagePostrpocessor
    {
        public IMessagesBuffer MessagesBuffer { get; }

        public MessagePostrpocessor()
        {
            MessagesBuffer = new MessagesBuffer();
        }

        public void Accept(Network network)
        {
            var nodes = network.NodesPairs.SelectMany(n => n.Nodes).Distinct();

            foreach (var node in nodes)
            {
                node.ReceivedMessages.OnMessageAdd += added => OnAddMessageToNode(node, added);
            }
        }

        private void OnAddMessageToNode(Node node, Message added)
        {
            node.ReceivedMessages.Remove(added);
            MessagesBuffer.Add(added);
        }
    }
}
