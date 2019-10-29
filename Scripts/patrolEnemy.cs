using UnityEngine;
using UnityEngine.AI;

public class patrolEnemy : MonoBehaviour
{
    //controlador de agente que patrulla

    protected NavMeshAgent agent;
    private int destPoint;


    //lista de puntos que el agente va a seguir -> waypoints
    public Transform[] points;



    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }
    
    //metodo para que el enemigo patrulla camine al siguiente punto
    private void GotoNextPoint()
    {
        //retorna si no hay siguiente punto
        if (points.Length == 0)
            return;

        //establece nueva direccion del agente
        agent.destination = points[destPoint].position;

        //establece el siguiente punto
        destPoint = (destPoint + 1) % points.Length;
    }

    private void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}