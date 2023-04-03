using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveManager : MonoBehaviour
{

    [SerializeField] private int vitesse;
    [SerializeField] private int jumpForce;


    private Rigidbody2D rb;

    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 velocity = Vector2.zero;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();

        moveAction = inputs.actions.FindAction("Move");
        jumpAction = inputs.actions.FindAction("Jump");
    }

    private void FixedUpdate()
    {
        // deplacement
        Vector2 _moveValue = moveAction.ReadValue<Vector2>();
        velocity = _moveValue*vitesse*Time.fixedDeltaTime;
        rb.velocity = new Vector2(velocity[0], rb.velocity.y);

    }



    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered){
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
