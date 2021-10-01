using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This enum is used to determine what the state of the player is.
/// Should be mapped to networkObject.state (int)
/// </summary>
public enum PlayerState
{
    IDLE,//before game
    WALKING,//walking
    DRIVING,//driving
    DEAD,//dead, waiting to respawn
    RESPAWN//dropping in
}

/// <summary>
/// This class defines the player. Uses a network contract.
/// </summary>
public class Player : PlayerBehavior
{
    #region INSPECTOR
    public float walkSpeed = 1;
    public float driveSpeed = 1;
    public float turnSpeed = 1;
    public float lookSpeed = 1;
    #endregion

    #region PRIVATE
    private CharacterController controller;
    private new Transform camera;
    private CollisionFlags collisionInfo;
    private PlayerState state = PlayerState.IDLE;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Camera c = GetComponentInChildren<Camera>();
        camera = c.transform;

        //if not ours
        if(!networkObject.IsOwner)
        {
            Destroy(c);//remove camera
        }
    }

    //These are CLIENT ONLY
    //they have no value on the server
    Vector2 moveInput = new Vector2();
    Vector2 lookInput = new Vector2();

    // Update is called once per frame
    void Update()
    {
        if(networkObject.IsOwner && !networkObject.IsServer)
        {
            //OWNER CLIENT
            //TODO: make an if statement for keyboard vs controller
            BuildInputFromKeyboard();
            SyncTransform();
            return;
        }

        if(!networkObject.IsServer)
        {
            //REGULAR CLIENT
            SyncTransform();
            return;
        }

        if(networkObject.IsServer)
        {
            //SERVER

            //note: state check is done within methods
            DoRespawn();//NYI
            Walk();//partial
            Drive();//partial
            Aim();//NYI
            Shoot();//NYI
            return;
        }
    }

    #region SERVER METHODS

    /// <summary>
    /// This method is used by the server to move the mech in walking mode.
    /// </summary>
    private void Walk()
    {
        if(state == PlayerState.WALKING)
        {
            Vector3 move = transform.TransformDirection(networkObject.moveinput * walkSpeed);
            collisionInfo = controller.Move(move);

            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
    }

    /// <summary>
    /// This method is used by the server to rotate left and right
    /// </summary>
    private void Drive()
    {
        if(state == PlayerState.DRIVING)
        {
            transform.RotateAround(transform.position, Vector3.up, networkObject.moveinput.x * turnSpeed);

            Vector3 move = transform.TransformDirection(networkObject.moveinput.y * driveSpeed * Vector3.forward);
            collisionInfo = controller.Move(move);

            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
    }

    /// <summary>
    /// This method is used by the server to aim the camera/point defense
    /// </summary>
    private void Aim()
    {
        if(state != PlayerState.DEAD && state != PlayerState.RESPAWN && state != PlayerState.IDLE)
        {

        }
    }

    /// <summary>
    /// This method is used by the server to fire the weapons.
    /// </summary>
    private void Shoot()
    {
        if (state != PlayerState.DEAD && state != PlayerState.RESPAWN && state != PlayerState.IDLE)
        {

        }
    }

    private void DoRespawn()
    {
        if(state == PlayerState.RESPAWN)
        {
            //TODO
        }
    }

    #endregion

    #region CLIENT METHODS

    /// <summary>
    /// This method is used by clients to sync their transforms.
    /// </summary>
    private void SyncTransform()
    {
        transform.position = networkObject.position;
        transform.rotation = networkObject.rotation;
    }

    private void BuildInputFromKeyboard()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        networkObject.moveinput = moveInput;

        lookInput.x = Input.GetAxis("Mouse X");
        lookInput.y = Input.GetAxis("Mouse Y");

        networkObject.aim = lookInput;
    }

    #endregion
}
