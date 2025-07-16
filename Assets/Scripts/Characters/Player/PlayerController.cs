using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public StackStateMachine<PlayerController> stackStateMachine { get; private set; }    

    public Animator Animator {  get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    // State
    private PlayerIdleState idleState;
    private PlayerJumState jumState;
    private PlayerAttackState attackState;


    private void Awake()
    {
        Animator = GetComponent<Animator>();
        PlayerInput = GetComponent<PlayerInput>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        stackStateMachine = new StackStateMachine<PlayerController>(this);
        idleState = new PlayerIdleState();
        jumState = new PlayerJumState();
        attackState = new PlayerAttackState();


        stackStateMachine.PushState(idleState);
        

        stackStateMachine.AddTransition(new Transition<PlayerController>(
            jumState,
            controller => controller.PlayerInput.JumpPressed
            ));


        stackStateMachine.AddTransition(new Transition<PlayerController>(
            attackState,
            controller => controller.PlayerInput.AttactPressed
            ));


    }

    private void Update()
    {
        stackStateMachine.Update();   
    }

   

}
