namespace Network.Domain.Entities
{
    public class LimitedMessageBuffer : UnlimitedMessageBuffer
    {
        private long Size { get; }

        public LimitedMessageBuffer(long size)
        {
            Size = size;
        }

        public override void Add(Message item)
        {
            if (Count >= Size)
            {
                return;
            }

            base.Add(item);
        }

        public override void Insert(int index, Message item)
        {
            if (Count >= Size)
            {
                return;
            }

            base.Insert(index, item);
        }
    }
}
