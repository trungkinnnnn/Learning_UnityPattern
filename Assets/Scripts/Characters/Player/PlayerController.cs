using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public Animator Animator {  get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    private IPlayerState currentState;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        ChangeState(new PlayerIdleState());
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter(this);
    }

}
