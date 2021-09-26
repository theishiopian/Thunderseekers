using MLAPI.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEventData : INetworkSerializable
{
    public virtual void NetworkSerialize(NetworkSerializer serializer)
    {
    }
}
