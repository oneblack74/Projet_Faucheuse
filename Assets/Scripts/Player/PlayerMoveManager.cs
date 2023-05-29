//Script d'Axel

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveManager : MonoBehaviour
{

    [SerializeField] private int vitesse;
    [SerializeField] private int jumpForce;

    [SerializeField] private bool estAuSol;

    
    private Transform verifierSolGauche;
    private Transform verifierSolDroit;

    private Rigidbody2D rb;

    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 velocity = Vector2.zero;

    private int dir;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();


        moveAction = inputs.actions.FindAction("Move");
        jumpAction = inputs.actions.FindAction("Jump");

        dir = 1;

        verifierSolGauche = GameObject.Find("VerifierSolGauche").GetComponent<Transform>();
        verifierSolDroit = GameObject.Find("VerifierSolDroit").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            // deplacement
            Vector2 _moveValue = moveAction.ReadValue<Vector2>();
            velocity = _moveValue * vitesse * Time.fixedDeltaTime;
            rb.velocity = new Vector2(velocity[0], rb.velocity.y);

            if (_moveValue.x > 0)
            {
                dir = 1;
            }
            else if (_moveValue.x < 0)
            {
                dir = -1;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            estAuSol = Physics2D.OverlapArea(verifierSolGauche.position, verifierSolDroit.position, LayerMask.GetMask("Sol"));

            if (jumpAction.triggered && estAuSol)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

            if (dir == 1 && GetComponent<SpriteRenderer>().flipX == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dir == -1 && GetComponent<SpriteRenderer>().flipX == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public virtual int getDir {
        get { return dir; }
    }

}
