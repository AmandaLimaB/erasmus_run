using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; // Aqui vamos arrastar o Player no Unity
    public Vector3 distancia = new Vector3(0, 5, -10); // Distância atrás e acima

    void LateUpdate()
    {
        // A câmera assume a posição do jogador + a distância definida
        transform.position = alvo.position + distancia;
    }
}