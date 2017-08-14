namespace Network.Domain.Entities
{
    public class LimitedMessagesBuffer : UnlimitedMessagesBuffer
    {
        private long Size { get; }
        public override bool IsFilled => Count >= Size;

        public LimitedMessagesBuffer(long size)
        {
            Size = size;
        }

        public override void Add(Message item)
        {
            if (IsFilled)
            {
                return;
            }

            base.Add(item);
        }

        public override void Insert(int index, Message item)
        {
            if (IsFilled)
            {
                return;
            }

            base.Insert(index, item);
        }
    }
}
