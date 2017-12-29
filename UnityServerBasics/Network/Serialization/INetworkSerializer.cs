namespace UnityServerBasics.Network.Serialization
{
    public interface INetworkSerializer
    {
        byte[] Serialize(INetworkSerializer serializer);

        NetworkMessage Deserialize(byte[] data);
    }
}
