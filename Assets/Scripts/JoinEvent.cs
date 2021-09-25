using MLAPI.Serialization;
/// <summary>
/// This struct caries data about a join event
/// </summary>
public struct JoinEvent : INetworkSerializable
{
    private int index;

    public int INDEX
    {
        get => index;
        private set => index = value;
    }

    public JoinEvent(int index)
    {
        this.index = index;
    }

    public void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref index);
    }
}