using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerDirection
{
    Left,
    Right,
    Up,
    Down,
    Idle
}

public class PlayerState
{
    public Vector2 direction;
    public PlayerDirection directionType;
}

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float camSpeed = 2f;

    [SerializeField] private Animator[] animators;

    private PlayerInput playerInput;
    private InputAction movementAction;

    private Vector2 movement;
    private PlayerDirection playerState;

    private List<int> triggers;
    private int triggerN;
    private int triggerS;
    private int triggerE;
    private int triggerW;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        movementAction = playerInput.actions["Movement"];

        triggerN = Animator.StringToHash("walkN");
        triggerS = Animator.StringToHash("walkS");
        triggerE = Animator.StringToHash("walkE");
        triggerW = Animator.StringToHash("walkW");

        triggers = new List<int>
        {
            triggerN,
            triggerS,
            triggerE,
            triggerW
        };
    }

    //Simple function so the player's diagonal speed is the same
    private PlayerState CalculateDirection(Vector2 input)
    {
        Vector2 direction = new Vector2();
        PlayerDirection directionType = PlayerDirection.Idle;

        if (input.x != 0)
        {
            //Rounded because if you press up and right (for example) at the same time the resulting vector is (0.71, 0.71)
            direction.x = Mathf.RoundToInt(input.normalized.x);
            directionType = direction.x < 0 ? PlayerDirection.Left : PlayerDirection.Right;
        }

        if (input.y != 0)
        {
            direction.y = Mathf.RoundToInt(input.normalized.y);
            directionType = direction.y < 0 ? PlayerDirection.Down : PlayerDirection.Up;
        }

        PlayerState state = new PlayerState();
        state.direction = direction;
        state.directionType = directionType;

        return state;
    }

    private void Update()
    {
        movement = movementAction.ReadValue<Vector2>();

        PlayerState state = CalculateDirection(movement);
        MovePlayer(state.direction);
        ChangeAnim(state.directionType);
        MoveCamera();
    }

    private void MovePlayer(Vector2 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void EnableTrigger(int trigger, PlayerDirection directionType, Animator animator)
    {
        triggers.ForEach(t =>
        {
            if (animator.runtimeAnimatorController != null)
            {
                if (t == trigger)
                {
                    if (directionType != playerState)
                    {
                        animator.SetTrigger(t);
                    }
                }
                else
                {
                    animator.ResetTrigger(t);
                }
            }
        });
    }

    private void ChangeAnim(PlayerDirection directionType)
    {
        foreach (Animator anim in animators)
        {
            if (anim.runtimeAnimatorController != null)
            {
                if (directionType != playerState)
                {
                    anim.Play("idle");
                }

                switch (directionType)
                {
                    case PlayerDirection.Left:
                        EnableTrigger(triggerW, directionType, anim);
                        anim.SetBool("isIdle", false);
                        break;

                    case PlayerDirection.Right:
                        EnableTrigger(triggerE, directionType, anim);
                        anim.SetBool("isIdle", false);
                        break;

                    case PlayerDirection.Up:
                        EnableTrigger(triggerN, directionType, anim);
                        anim.SetBool("isIdle", false);
                        break;

                    case PlayerDirection.Down:
                        EnableTrigger(triggerS, directionType, anim);
                        anim.SetBool("isIdle", false);
                        break;

                    default:
                        EnableTrigger(-1, directionType, anim);
                        anim.SetBool("isIdle", true);
                        break;
                }
            }
        }

        playerState = directionType;
    }

    private void MoveCamera()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, -10);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPosition, Time.deltaTime * camSpeed);
    }
}
