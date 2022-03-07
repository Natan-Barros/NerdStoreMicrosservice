﻿namespace NSE.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AgreggateId { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
