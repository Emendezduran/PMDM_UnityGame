using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Velocidad del jugador
    public float speed;
    
    //cuenta de pickUps cojidos
    private int count;

    //Intensidad del salto
    public float jumpPower;
    
    //determina si el jugador esta saltando
    public bool jumping;
    
    //determina si el jugador esta en el suelo
    private bool isGrounded;
    
    //Texto de la puntuacion actual
    public Text countText;
    
    //Texto principal para el inicio y el final
    public Text winText;
    
    //determina cual es la distancia que se considera peligrosa
    public int distanciaPeligro;
    
    private Rigidbody rb;
    public GameObject reset;
    public Transform target;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        count = 0;
        SetText();
        winText.text = "RUN!";
        reset.gameObject.SetActive(false);
    }

    private void Update()
    {
        jumping = Input.GetButton("Jump");
        move();
    }
    
    void FixedUpdate()
    {
        danger();
        jump();
    }
    
    //metodo que trabaja las colisiones
    void OnTriggerEnter(Collider other)
    {
        //Lo que sucede cuando se cojen monedas
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            speed = speed + 0.5f;
            SetText();
        }

        //Lo que sucede si el enemigo te alcanza y no tienes todas las monedas
        if (other.gameObject.CompareTag("Enemy") && count < 12)
        {
            gameObject.SetActive(false);
            winText.text = "GAME OVER";
            reset.gameObject.SetActive(true);
        }

        //Lo que sucede si el enemigo te alcanza y tienes todas las monedas
        if (other.gameObject.CompareTag("Enemy") && count == 12)
        {
            other.gameObject.SetActive(false);
        }
    }
    
    //metodo que hace que el jugador se mueva
    void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed, ForceMode.Acceleration);
    }

    //metodo que evalua el peligro para controlar la animacion
    void danger()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= distanciaPeligro)
        {
            animator.SetBool("estaPeligroso", true);
        }
        else
        {
            animator.SetBool("estaPeligroso", false);
        }

    }

    //metodo que hace que el jugador salte
    void jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
        
        if (jumping && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
    
    //metodo que controla las diferentes salidas de los textos
    void SetText()
    {
        countText.text = count.ToString() + " Coins";
        if (count == 1)
        {
            winText.text = "Pick 12 coins to Win!";
        }

        if (count == 2)
        {
            winText.text = "More coins, More power";
        }

        if (count == 6)
        {
            winText.text = "";
        }

        if (count == 7)
        {
            winText.text = "";
        }

        if (count >= 12)
        {
            winText.text = "WINNER";
        }
    }
    
}
