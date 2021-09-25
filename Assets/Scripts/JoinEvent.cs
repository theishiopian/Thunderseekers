using MLAPI.Serialization;
/// <summary>
/// This class caries data about a join event
/// </summary>
public class JoinEventData : EventData
{
    private int index;

    public int INDEX
    {
        get => index;
        private set => index = value;
    }

    public JoinEventData(int index)
    {
        this.index = index;
    }

    public override void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref index);
    }
}