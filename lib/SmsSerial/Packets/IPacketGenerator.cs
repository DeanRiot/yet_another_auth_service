namespace Sms.Payload
{
    internal interface IPacketGenerator
    {
        string GetPacket(out int message_length);
    }
}
