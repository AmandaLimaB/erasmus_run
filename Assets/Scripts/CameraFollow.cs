using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; // Aqui vamos arrastar o Player no Unity
    public Vector3 distancia = new Vector3(0, 5, -10); // Distancia atras e acima

    void LateUpdate()
    {
        // A camera assume a posicao do jogador + a distancia definida
        transform.position = alvo.position + distancia;
    }
}