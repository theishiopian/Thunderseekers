using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : NetworkBehaviour
{
    private void Awake()
    {
        EventBus.testEvent += Test;
        if(!IsLocalPlayer) EventBus.Invoke(EventBus.testEvent, NetworkObjectId, LogicalSide.SERVER);
    }

    private void Update()
    {
        if(IsLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            EventBus.Invoke(EventBus.testEvent, NetworkObjectId, LogicalSide.CLIENT);
        }
    }

    void Test(ulong ID, LogicalSide currentSide, LogicalSide sourceSide)
    {
        Debug.Log("Hello from the " + 
            currentSide.ToString() + 
            " version of Object " + 
            NetworkObjectId + 
            ". This event was called from Object " +
            ID +
            " from the side " +
            sourceSide.ToString());
    }
}
