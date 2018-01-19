namespace UnityServerBasics.Network.Serialization
{
    public interface INetworkSerializer
    {
        byte[] Serialize(NetworkMessage serializer);

        NetworkMessage Deserialize(byte[] data);
    }
}
