using MLAPI.Serialization;
/// <summary>
/// This class caries data about a join event
/// </summary>
public class PreJoinEventData : AbstractEventData
{
    private int index;

    public int INDEX
    {
        get => index;
        private set => index = value;
    }

    public PreJoinEventData(int index)
    {
        this.index = index;
    }

    public override void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref index);
    }
}