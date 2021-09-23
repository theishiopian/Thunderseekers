using MLAPI;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This component stores its transform data from the server/host and syncs it on the client
/// </summary>
public class NetworkedTransform : NetworkBehaviour
{
    NetworkVariable<Vector3> syncPos = new NetworkVariable<Vector3>();
    NetworkVariable<Quaternion> syncRot = new NetworkVariable<Quaternion>();

    private void FixedUpdate()
    {
        if(IsClient && !IsHost)
        {
            transform.position = syncPos.Value;
            transform.rotation = syncRot.Value;
        }
        else if(IsServer || IsHost)
        {
            syncPos.Value = transform.position;
            syncRot.Value = transform.rotation;
        }
    }

    public void SetPosition(Vector3 position)
    {
        if(!IsClient)
        {
            transform.position = position;
        }
    }

    public void SetRotation(Quaternion rotation)
    {
        if (!IsClient)
        {
            transform.rotation = rotation;
        }
    }
}
