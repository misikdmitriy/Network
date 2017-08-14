namespace Network.Domain.Entities
{
    public class NodesPair
    {
        public Node NodeFrom { get; }
        public Node NodeTo { get; }
        public Channel Channel { get; }

        public Node[] Nodes => new[] {NodeFrom, NodeTo};

        public NodesPair(Channel channel, Node nodeFrom, Node nodeTo)
        {
            Channel = channel;
            NodeFrom = nodeFrom;
            NodeTo = nodeTo;
        }
    }
}
