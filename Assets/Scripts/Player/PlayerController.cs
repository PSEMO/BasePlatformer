using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private PlayerSO data;
    [SerializeField] private List<Transform> groundChecks;

    private InputSystem_Actions inputActions;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector3 respawnPos;

    public float moveInput = 0;
    public bool upInput = false;
    public bool dashInput = false;
    public bool interactInput = false;

    public bool isGrounded = true;
    
    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.AddCallbacks(this);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        CameraManager.Instance.AddTarget(transform, data.camDivisor);

        respawnPos = transform.position;
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        Events.OnPlayerDeath += Die;
        Events.OnCheckPointReached += SetRespawnPos;
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
        Events.OnPlayerDeath -= Die;
        Events.OnCheckPointReached -= SetRespawnPos;
    }

    void OnDestroy()
    {
        inputActions.Player.RemoveCallbacks(this);
        inputActions.Dispose();
        CameraManager.Instance.RemoveTarget(transform);
    }

    void Update()
    {
        isGrounded = IsOnGround();
    }

    private bool IsOnGround()
    {
        foreach (Transform check in groundChecks)
        {
            if (check == null) continue;

            RaycastHit2D hit = Physics2D.Raycast(check.position, Vector2.down, data.groundCheckDistance, data.groundLayer);

            if (hit.collider != null)
            {
                return true;
            }
        }

        return false;
    }

    private void Die()
    {
        transform.position = respawnPos;
        rb.linearVelocity = Vector2.zero;
    }

    private void SetRespawnPos(Vector3 pos)
    {
        respawnPos = pos;
    }

    //***INPUTS***
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
        Debug.Log(moveInput);
    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upInput = true;
        }
        else if (context.canceled)
        {
            upInput = false;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            dashInput = true;
        }
        else if (context.canceled)
        {
            dashInput = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactInput = true;
        }
        else if (context.canceled)
        {
            interactInput = false;
        }
    }
}