using MLAPI.Serialization;
/// <summary>
/// This class caries data about a join event
/// </summary>
public class JoinSuccessEventData : AbstractEventData
{
    private string message;

    public string MESSAGE
    {
        get => message;
        private set => message = value;
    }

    public JoinSuccessEventData(string messageIn)
    {
        this.message = messageIn;
    }

    public override void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref message);
    }
}