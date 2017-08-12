namespace Network.Domain.Entities
{
    public class LimitedMessagesesBuffer : UnlimitedMessagesBuffer
    {
        private long Size { get; }

        public LimitedMessagesesBuffer(long size)
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
