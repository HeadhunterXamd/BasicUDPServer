namespace UnityServerBasics.Network.Serialization
{
    public interface ISerializer
    {
        byte[] Serialize(object serializer);

        object Deserialize(byte[] data);
    }
}
