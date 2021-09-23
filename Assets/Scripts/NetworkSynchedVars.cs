using MLAPI;
using MLAPI.NetworkVariable.Collections;
using UnityEngine;

/// <summary>
/// this object is used as a container for any vars that need synching between client and server
/// </summary>
public class NetworkSynchedVars : NetworkBehaviour
{
    private NetworkDictionary<ulong, Vector2> movementInput = new NetworkDictionary<ulong, Vector2>();

    private static NetworkSynchedVars singleton;

    private void Awake()
    {
        singleton = this;
    }

    /// <summary>
    /// Used to set input for this Client
    /// Does nothing on the server
    /// </summary>
    /// <param name="input"></param>
    public static void SetInput(Vector2 input)
    {
        singleton.setInput(input);
    }

    /// <summary>
    /// used to get input for a specific netID.
    /// can be used from  either side.
    /// </summary>
    /// <param name="ID">The ID of the net object to get info for.</param>
    /// <returns></returns>
    public static Vector2 GetInput(ulong ID)
    {
        return singleton.movementInput[ID];
    }

    private void setInput(Vector2 input)
    {
        //redundant check probably uneeded, but i dont trust this thing
        if(IsClient || IsHost)
        {
            //the reason for this check is i need to make sure only the client ID of the
            //local player is used as a key. this is to prevent clients from sending inputs
            //for other players. you know, to prevent them from movingm or some other BS
            //since this is jsut a jam, we can bypass this if its a problem, though id prefer
            //not to
            movementInput[NetworkManager.Singleton.LocalClientId] = input;
        }
    } 
}
