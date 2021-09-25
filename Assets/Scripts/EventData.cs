using MLAPI.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventData : INetworkSerializable
{
    public virtual void NetworkSerialize(NetworkSerializer serializer)
    {
    }
}
