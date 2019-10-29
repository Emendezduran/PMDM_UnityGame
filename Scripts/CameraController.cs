using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //diferencia entre la posicion de la camara y la del jugador
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate()
    {
        //La camara se mueve con el jugador manteniendo la distancia definida en offset
        transform.position = player.transform.position + offset;

    }
    
}