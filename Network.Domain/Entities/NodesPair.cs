namespace Network.Domain.Entities
{
    /// <summary>
    /// Connected nodes
    /// </summary>
    public class NodesPair
    {
        /// <summary>
        /// Node #1
        /// </summary>
        public Node NodeFrom { get; }
        /// <summary>
        /// Node #2
        /// </summary>
        public Node NodeTo { get; }
        /// <summary>
        /// Channel between nodes
        /// </summary>
        public Channel Channel { get; }

        public Node[] Nodes => new[] {NodeFrom, NodeTo};

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nodeFrom">Node #1</param>
        /// <param name="nodeTo">Node #2</param>
        /// <param name="channel">Channel between nodes</param>
        public NodesPair(Node nodeFrom, Node nodeTo, Channel channel)
        {
            Channel = channel;
            NodeFrom = nodeFrom;
            NodeTo = nodeTo;
        }
    }
}
