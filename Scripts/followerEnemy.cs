using UnityEngine;

public class followerEnemy : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemy;
    private bool caught = false;
    
    void Start()
    {
        //Inicializacion del enemigo
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    //recibe la colision y en caso de ser con el player 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            caught = true;
        }
    }

    void Update()
    {
        if (!caught)
        {
            enemy.destination = jugador.position;
        }

        if (caught)
        {
            enemy.destination = this.transform.position;
        }
    }
}